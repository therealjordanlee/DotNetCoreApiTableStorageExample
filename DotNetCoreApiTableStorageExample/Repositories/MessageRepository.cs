using System.Threading.Tasks;
using DotNetCoreApiTableStorageExample.Entities;
using Microsoft.Azure.Cosmos.Table;

namespace DotNetCoreApiTableStorageExample.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly CloudTable _table;

        public MessageRepository(CloudTableClient tableClient)
        {
            _table = tableClient.GetTableReference("Message");
        }

        public async Task<MessageEntity> GetRecord(string partitionKey, string rowKey)
        {
            await _table.CreateIfNotExistsAsync();
            TableOperation retrieveOperation = TableOperation.Retrieve<MessageEntity>(partitionKey, rowKey);
            TableResult result = await _table.ExecuteAsync(retrieveOperation);
            return result.Result as MessageEntity;
        }
    }
}
