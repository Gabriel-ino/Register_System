using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_de_Cadastro.Models;
using Sistema_de_Cadastro.Repository;

namespace Sistema_de_Cadastro.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IActionResult Index()
        {
            List<UserModel> users = _userRepository.GetAll();
            return View(users);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _userRepository.Add(model);
                    TempData["SuccessMessage"] = "Successful contact creation";
                    return RedirectToAction("Index");
                }
                return View(model);
            }catch(Exception ex)
            {
                TempData["ErrorMessage"] = $"Contact creation was failed, try again\nDetails: {ex}";
                return RedirectToAction("Index");
            }
        }

    }
}
