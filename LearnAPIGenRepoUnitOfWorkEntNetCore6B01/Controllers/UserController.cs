using LearnAPIGenRepoUnitOfWorkEntNetCore6B01.Interfaces;
using LearnAPIGenRepoUnitOfWorkEntNetCore6B01.Models;
using LearnAPIGenRepoUnitOfWorkEntNetCore6B01.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnAPIGenRepoUnitOfWorkEntNetCore6B01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public IUnitOfWork UnitOfWork { get; }

        /*[HttpGet]
        public async Task<IActionResult> GetListUsers() 
        { 
            var users = await UnitOfWork.UserRepository.GetAllUserAsync();
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewUser(User user)
        {
            UnitOfWork.UserRepository.Add(user);
            await UnitOfWork.SaveAsync();
            return Ok(user);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            UnitOfWork.UserRepository.Remove(userId);
            await UnitOfWork.SaveAsync();
            return Ok("Delete Successfuly!");
        }*/

        [HttpGet]
        public IActionResult GetUsets()
        {
            var users = UnitOfWork.UserRepository.GetAll();
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewUser(User user)
        {
            UnitOfWork.UserRepository.Add(user);
            await UnitOfWork.SaveAsync();
            return Ok(user);
        }

        [HttpDelete("Delete/{id}")]
        public ActionResult DeleteUser(int userId)
        {
            User user = new User();
            user = UnitOfWork.UserRepository.Find(u => u.Uid== userId).FirstOrDefault();
            UnitOfWork.UserRepository.Remove(user);
            UnitOfWork.SaveAsync();
            return Ok("Delete User Successfully!");
        }
    }
}
