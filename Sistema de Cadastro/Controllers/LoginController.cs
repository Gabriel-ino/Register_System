using Microsoft.AspNetCore.Mvc;
using Sistema_de_Cadastro.Models;
using Sistema_de_Cadastro.Repository;

namespace Sistema_de_Cadastro.Controllers
{
    public class LoginController : Controller
    {

        private readonly IUserRepository _userRepository;

        public LoginController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TryLogin(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserModel? getModelFromDB = _userRepository.GetByLogin(loginModel.Login);

                    if (getModelFromDB != null)
                    {
                        if (getModelFromDB.VerifyPassword(loginModel.Password))
                        {
                            return RedirectToAction("Index", "Home");
                        }

                        TempData["ErrorMessage"] = "Invalid user's data";

                    }
                    TempData["ErrorMessage"] = "Invalid user's data";

                }

                return  View("Index");
    
        }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Something went wrong\nDetails: {ex}";
                return RedirectToAction("Index");

            }
        }
    }

    
}
