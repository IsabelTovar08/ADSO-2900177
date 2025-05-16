using Entity.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PublicGateway : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private const string BaseApiUrl = "https://jsonplaceholder.typicode.com/users";

        public PublicGateway(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        private HttpClient CreateClient() => _httpClientFactory.CreateClient();

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await CreateClient().GetAsync(BaseApiUrl);

            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode, "Error al obtener usuarios desde API A");

            var content = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<List<User>>(content);

            return Ok(users);
        }

       
    }
}
