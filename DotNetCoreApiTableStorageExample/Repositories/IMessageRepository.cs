using System.Threading.Tasks;
using DotNetCoreApiTableStorageExample.Entities;

namespace DotNetCoreApiTableStorageExample.Repositories
{
    public interface IMessageRepository
    {
        Task<MessageEntity> GetRecord(string partitionKey, string rowKey);
    }
}
