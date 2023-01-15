using LearnAPIGenRepoUnitOfWorkEntNetCore6B01.Interfaces;
using LearnAPIGenRepoUnitOfWorkEntNetCore6B01.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnAPIGenRepoUnitOfWorkEntNetCore6B01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        public CarController(IUnitOfWork UOW)
        {
            this.UOW = UOW;
        }

        public IUnitOfWork UOW { get; }

        [HttpGet]
        public IActionResult GetCars()
        {
            var cars = UOW.CarRepository.GetAll();
            return Ok(cars);
        }

        [HttpPost("AddCar")]
        public async Task<IActionResult> AddCar(Car car)
        {
            UOW.CarRepository.Add(car);
            await UOW.SaveAsync();
            return Ok(car);
        }

        [HttpDelete("Delete/{id}")]
        public ActionResult DeleteCar(int carId)
        {
            Car car = new Car();
            car = UOW.CarRepository.Find(c => c.CarId == carId).FirstOrDefault();
            UOW.CarRepository.Remove(car);
            UOW.SaveAsync();
            return Ok("Delete Car Successfully!");
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateCar([FromRoute] int CarId, [FromBody] Car model)
        {
            var car = UOW.CarRepository.Find(c => c.CarId==CarId).FirstOrDefault();
            car.PlateNo = model.PlateNo;
            car.Description = model.Description;
            await UOW.SaveAsync();
            return Ok(car);

        }
    }
}
