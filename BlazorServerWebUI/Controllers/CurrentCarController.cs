using BlazorServerWebUI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;
using TokenHandlerModels.Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorServerWebUI.Controllers
{
    [Route("catalog/")]
    [ApiController]
    public class CurrentCarController : Controller
    {

        [HttpGet]
        [Route("car/{carId:int}")]
        public async Task<ViewResult> GetCurrentCarPage(int carId)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                var car = await httpClient.GetFromJsonAsync<CarViewModel?>($"http://apigateway/api/Car/{carId}");
                return View(car);
            }
            catch (Exception ex)
            {
                    Console.WriteLine(ex.Message);
                return View(new CarViewModel());
            }
        }
    }
}
