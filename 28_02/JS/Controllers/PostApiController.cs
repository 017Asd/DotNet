using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace JS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostApiController : ControllerBase
    {
        private readonly HttpClient _httpClient = new HttpClient();

        [HttpGet]
        public async Task<IActionResult> GetTodos()
        {
            var response = await _httpClient.GetAsync(
                "https://jsonplaceholder.typicode.com/todos");

            if (!response.IsSuccessStatusCode)
                return BadRequest("Error fetching todos");

            var data = await response.Content.ReadAsStringAsync();
            return Content(data, "application/json");
        }
    }
}