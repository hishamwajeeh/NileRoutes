using Microsoft.AspNetCore.Mvc;
using NileRoute.UI.Models;
using NileRoute.UI.Models.Dto;

namespace NileRoute.UI.Controllers
{
    public class RegionsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public RegionsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<RegionDto> response = new List<RegionDto>();

            try
            {
                var client = _httpClientFactory.CreateClient();

                var httpResponse = await client.GetAsync("https://localhost:7272/api/regions");

                httpResponse.EnsureSuccessStatusCode();

                response.AddRange(await httpResponse.Content.ReadFromJsonAsync<IEnumerable<RegionDto>>());

            }
            catch (Exception ex)
            {
            }

            return View(response);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddRegionViewModel model)
        {
            var client = _httpClientFactory.CreateClient();

            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://localhost:7272/api/regions"),
                Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(model), System.Text.Encoding.UTF8, "application/json")
            };

            var httpResponseMessage = await client.SendAsync(httpRequestMessage);
            httpResponseMessage.EnsureSuccessStatusCode();

            var response = await httpResponseMessage.Content.ReadFromJsonAsync<RegionDto>();

            if (response != null)
            {
                return RedirectToAction("Index", "Regions");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var client = _httpClientFactory.CreateClient();

            var httpResponse = await client.GetFromJsonAsync<RegionDto>($"https://localhost:7272/api/regions/{id.ToString()}");

            if(httpResponse != null)
            {
                return View(httpResponse);
            }

            return View(null);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RegionDto request)
        {
            var client = _httpClientFactory.CreateClient();

            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri($"https://localhost:7272/api/regions/{request.Id}"),
                Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(request), System.Text.Encoding.UTF8, "application/json")
            };

            var httpResponseMessage = await client.SendAsync(httpRequestMessage);
            httpResponseMessage.EnsureSuccessStatusCode();

            var response = await httpResponseMessage.Content.ReadFromJsonAsync<RegionDto>();
            if (response != null)
            {
                return RedirectToAction("Index", "Regions");
            }
            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(RegionDto request)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();

                var httpResponseMessage = await client.DeleteAsync($"https://localhost:7272/api/regions/{request.Id}");

                httpResponseMessage.EnsureSuccessStatusCode();

                return RedirectToAction("Index", "Regions");
            }
            catch (Exception ex)
            {
            }
            return View("Edit");
        }
    }
}
