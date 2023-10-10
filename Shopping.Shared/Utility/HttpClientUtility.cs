using Newtonsoft.Json;
using System.Text;

namespace Shopping.Shared
{
    public static class HttpClientUtility
    {
        //public static async Task<HttpResponseDTO> PostAsync(string url, object body, Type type)
        public static void Post(string url, object body)
        {
            //var responseData = new HttpResponseDTO();
            using (var client = new HttpClient())
            {
                var data = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8);

                var request = new HttpRequestMessage(HttpMethod.Post, url)
                {
                    Content = data
                };

                //request.Headers.Add("Content-Type", "application/json");
                request.Headers.Add("Correlation-Id", Guid.NewGuid().ToString());

                //var response = await client.SendAsync(request);
                client.SendAsync(request);

                //if (response.IsSuccessStatusCode)
                //{
                //    var content = await response.Content.ReadAsStringAsync();
                //    responseData.Status = true;
                //    responseData.Content = JsonConvert.DeserializeObject<Type>(content);

                //    return responseData;
                //}
                //else
                //{
                //    return responseData;
                //}
            }
        }
    }
}
