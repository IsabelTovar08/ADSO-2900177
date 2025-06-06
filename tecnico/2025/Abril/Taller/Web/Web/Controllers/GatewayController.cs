﻿using System.Text;
using Entity.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class GatewayController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private const string BaseApiUrl = "https://localhost:7090/api/UserPublic";

        public GatewayController(IHttpClientFactory httpClientFactory)
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

        [HttpPost("guardar-user")]
        public async Task<IActionResult> SaveUser([FromBody] List<User> users)
        {
            var content = new StringContent(JsonConvert.SerializeObject(users), Encoding.UTF8, "application/json");
            var response = await CreateClient().PostAsync(BaseApiUrl, content);

            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode, "Error al guardar en API B");

            return Ok("Datos guardados con éxito.");
        }

        [HttpPut("actualizar-user")]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {
            if (user == null || user.Id <= 0)
                return BadRequest("Usuario inválido o sin ID.");

            var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            var response = await CreateClient().PutAsync($"{BaseApiUrl}", content);

            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode, "Error al actualizar el usuario en API B");

            return Ok("Usuario actualizado correctamente.");
        }

        [HttpDelete("eliminar-user/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var response = await CreateClient().DeleteAsync($"{BaseApiUrl}/{id}");

            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode, "Error al eliminar el usuario en API B");

            return Ok("Usuario eliminado correctamente.");
        }
    }

}



