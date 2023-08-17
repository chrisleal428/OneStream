using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace OneStream.Controllers
{
    public class FrontEndAPIController : ApiController
    { 
        private static readonly HttpClient client = new HttpClient();

        [System.Web.Http.HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                string api2Response = await CallBackendApiAsync("https://localhost:44390/api/Api2/get");
                string api3Response = await CallBackendApiAsync("https://localhost:44390/api/Api3/get");

                return Ok(new { api2Response, api3Response });
            }
            catch (Exception ex)
            {
                // Log the exception and return an appropriate error message
                return InternalServerError(ex); // Or return a custom error message
            }
        }

        [System.Web.Http.HttpPost]
        public async Task<IHttpActionResult> Post()
        {
            try
            {
                string api2Response = await CallBackendApiAsync("https://localhost:44390/api/Api2/post", HttpMethod.Post);
                string api3Response = await CallBackendApiAsync("https://localhost:44390/api/Api3/post", HttpMethod.Post);

                return Ok(new { api2Response, api3Response });
            }
            catch (Exception ex)
            {
                // Log the exception and return an appropriate error message
                return InternalServerError(ex); // Or return a custom error message
            }
        }

        private async Task<string> CallBackendApiAsync(string url, HttpMethod method = null)
        {
            HttpResponseMessage response = method == HttpMethod.Post ? await client.PostAsync(url, null) : await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
