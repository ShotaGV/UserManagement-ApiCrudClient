using ApiCrudClient.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCrudClient.Controllers
{
    public class UserController : Controller
    {

        private readonly APIGateway apiGateway;
        public UserController(APIGateway ApiGateway)
        {
            this.apiGateway = ApiGateway;
        }
        public IActionResult Index()
        {
            List<User> users;
            users = apiGateway.ListUsers();
            return View(users);
        }
        [HttpGet]
        public IActionResult Create()
        {
            User user = new User();
            return View(user);
        }
        [HttpPost]
        public IActionResult Create(User user)
        {
            apiGateway.CreateUser(user);
            return RedirectToAction("index");
        }
        public IActionResult Detail(int ID) 
        {
            User user = new User();
            user = apiGateway.GetUser(ID);
            return View(user);
        }
        [HttpGet]
        public IActionResult Edit(int ID)
        {
            User user;
            user = apiGateway.GetUser(ID);
            return View(user);
        }
        [HttpPost]
        public IActionResult Edit(User user)    
        {
            apiGateway.UpdateUser(user);
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Delete(int ID)
        {
            User user;
            user = apiGateway.GetUser(ID);
            return View(user);
        }
        [HttpPost]
        public IActionResult Delete(User user)  
        {
            apiGateway.DeleteUser(user.ID);
            return RedirectToAction("index");
        }
    }
}

