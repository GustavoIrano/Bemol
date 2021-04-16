using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace bemol.Business.Extensions
{
    public static class HttpClientExtension
    {
        public static StringContent GetStringContent<T>(this T obj)
        {
            return new StringContent(JsonSerializer.Serialize(obj), Encoding.UTF8, "application/json");
        }

        public async static Task<T> DeserealizeResponse<T>(this HttpResponseMessage httpResponseMessage)
        {
            try
            {
                if (httpResponseMessage.Content.ReadAsByteArrayAsync().GetAwaiter().GetResult().Length <= 0)
                    return default;

                var result = JsonSerializer.Deserialize<T>(await httpResponseMessage.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
