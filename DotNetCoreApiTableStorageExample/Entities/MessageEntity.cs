using Microsoft.Azure.Cosmos.Table;

namespace DotNetCoreApiTableStorageExample.Entities
{
    public class MessageEntity : TableEntity
    {
        public string Id => PartitionKey;
        public string SubId => RowKey;
        public string Message { get; set; }
    }
}
