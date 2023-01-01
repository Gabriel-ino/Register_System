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

        public IActionResult Edit(int id)
        {
            UserModel userModel = _userRepository.GetById(id);
            return View(userModel);
        }

        public IActionResult VerifyDelete(int id)
        {
            UserModel userModel = _userRepository.GetById(id);
            return View(userModel);
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

        public IActionResult Delete(int id)
        {
            try
            {
                bool verifyDelete = _userRepository.Delete(id);
                if (verifyDelete)
                {
                    TempData["SuccessMessage"] = "Successfully deleted user!";
                }
                else
                {
                    TempData["ErrorMessage"] = "Something went wrong";
                }

                return RedirectToAction("Index");

            } catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Something went wrong\nDetails: {ex}";
                return RedirectToAction("Index");
            }

        }

        public IActionResult Change(EditUserModel toUpdateUser)
        {
            try
            {
                UserModel? userWithPasword = null;
                UserModel onDatabaseUser = _userRepository.GetById(toUpdateUser.Id);
                if (ModelState.IsValid)
                {
                    userWithPasword = new UserModel()
                    {
                        Id = toUpdateUser.Id,
                        Name = toUpdateUser.Name,
                        Email = toUpdateUser.Email,
                        Login = toUpdateUser.Login,
                        profile = toUpdateUser.profile,
                        Password = onDatabaseUser.Password,
                    };
                    _userRepository.Update(userWithPasword);
                    TempData["SuccessMessage"] = "Updated Successfully";
                    
                    return RedirectToAction("Index");
                }
                return View(userWithPasword);

            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Something went wrong\nDetails: {ex}";
                return RedirectToAction("Index");
            }
        }

    }
}
