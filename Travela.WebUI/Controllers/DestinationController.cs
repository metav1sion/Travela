using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Travela.WebUI.Dtos;

namespace Travela.WebUI.Controllers
{
    public class DestinationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DestinationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> DestinationList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7251/api/Destination");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultDestinationDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateDestination()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDestination(CreateDestinationDto p)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(p);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7251/api/Destination", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("DestinationList");
            }
            return View();
        }

        public async Task<IActionResult> DeleteDestiantion(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync($"https://localhost:7251/api/Destination?id={id}");
            return RedirectToAction("DestinationList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateDestination(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7251/api/Destination/GetDestination/{id}");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateDestinationDto>(jsonData);

            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDestination(UpdateDestinationDto p)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(p);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            await client.PutAsync("https://localhost:7251/api/Destination", stringContent);

            return RedirectToAction("DestinationList");
        }
    }
}
