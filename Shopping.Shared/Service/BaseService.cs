using Microsoft.Azure.Cosmos;

namespace Shopping.Shared.Service
{
    public class BaseService
    {

        public PartitionKey PartitionKey(Guid id)
        {
            var pk = new PartitionKey(id.ToString());

            return pk;
        }

        public PartitionKey PartitionKey(string id)
        {
            var pk = new PartitionKey(id);

            return pk;
        }
    }
}
