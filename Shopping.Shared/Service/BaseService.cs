using Microsoft.Azure.Cosmos;

namespace Shopping.Shared.Service
{
    public class BaseService
    {

        public PartitionKey PartitionKey(string id)
        {
            var pk = new PartitionKey(id);

            return pk;
        }
    }
}
