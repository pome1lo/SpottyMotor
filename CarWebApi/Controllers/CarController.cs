using CarWebApi.Database;
using CarWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly CarDbContext _context;

        public CarController(CarDbContext Context)
        {
            _context = Context;
        }

        [HttpGet]
        public ActionResult<List<Car>> GetCars()
        {
            return _context.Cars.Include(x => x.Category)
                .Include(x => x.Characteristics).ThenInclude(x => x.Transmission)
                .Include(x => x.Characteristics).ThenInclude(x => x.CarBody).ToList();
        }

        [HttpGet("{carId}")]
        public ActionResult<Car?> GetCarById(int carId)
        {
            return GetCars().Value?.Find(x => x.Id == carId);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Car car)
        {
            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(Car car)
        {
            _context.Cars.Update(car);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{carId:int}")]
        public async Task<ActionResult> Delete(int carId)
        {
            var car = GetCarById(carId).Value;
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
