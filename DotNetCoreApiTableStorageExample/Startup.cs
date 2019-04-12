using DotNetCoreApiTableStorageExample.Configurations;
using DotNetCoreApiTableStorageExample.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace DotNetCoreApiTableStorageExample
{
    public class Startup
    {
        private IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.Configure<StorageConfiguration>(Configuration.GetSection("Storage"));
            services.AddSingleton<CloudTableClient>(provider =>
            {
                var azureConnectionString = provider.GetService<IOptions<StorageConfiguration>>().Value
                    .AzureStorageConnectionString;
                var storageAccount = CloudStorageAccount.Parse(azureConnectionString);
                var tableClient = storageAccount.CreateCloudTableClient(new TableClientConfiguration());
                return tableClient;
            });
            services.AddScoped<IMessageRepository, MessageRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
