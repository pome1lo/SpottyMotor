using BlazorServerWebUI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BlazorServerWebUI.Controllers
{
    [Route("catalog/")]
    [ApiController]
    public class CurrentCarController : Controller
    {

        [HttpGet]
        [Route("car/{carId:int}")]
        public async Task<ViewResult> CurrentCar(int? carId)
        {
            HttpClient httpClient = new HttpClient();
            try
            {
                var car = await httpClient.GetFromJsonAsync<CarViewModel?>($"http://apigateway/api/Car/{carId}");
                Console.WriteLine("LIKE LIKE LIKE LIKE LIKE", ConsoleColor.Green);
                return View(car);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, ConsoleColor.Red);
                return View();
            }
        }
    }
}
