using Microsoft.AspNetCore.Mvc;

namespace Sistema_de_Cadastro.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
