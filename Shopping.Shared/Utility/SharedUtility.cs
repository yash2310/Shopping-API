using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Headers;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Shopping.Shared
{
    public static class SharedUtility
    {
        public static string GetCorrelationId(HttpContent content)
        {
            var item = content.Headers.GetValues("Correlation").FirstOrDefault();

            if (string.IsNullOrEmpty(item))
            {
                item = Guid.NewGuid().ToString();
            }

            return item;
        }

        public static Guid GetUniqueId(Guid id)
        {
            if(id == Guid.Empty)
            {
                id = Guid.NewGuid();
            }

            return id;
        }
    }
}
