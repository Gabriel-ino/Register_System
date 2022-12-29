using Microsoft.AspNetCore.Mvc;
using Sistema_de_Cadastro.Models;
using Sistema_de_Cadastro.Repository;

namespace Sistema_de_Cadastro.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;
        public ContactController(IContactRepository contactRepository) {
            _contactRepository = contactRepository;
        }
        public IActionResult Index()
        {
            List<ModelContact> contacts = _contactRepository.getAll();
            return View(contacts);
        }

        public IActionResult Create()
        {
            return View();
        }


        public IActionResult Edit(int id)
        {
            ModelContact m_contact = _contactRepository.GetById(id);
            return View(m_contact);
        }

        public IActionResult VerifyDelete(int id)
        {
            ModelContact m_contact = _contactRepository.GetById(id);
            return View(m_contact);
        }

        public IActionResult Delete(int id)
        {
            try
            {
                bool verifyDelete = _contactRepository.Delete(id);

                if(verifyDelete)
                {
                    TempData["SuccessMessage"] = "Successfully deleted contact!";
                }
                else
                {
                    TempData["ErrorMessage"] = "Something went wrong";
                }

                return RedirectToAction("Index");

            }catch(Exception ex)
            {
                TempData["ErrorMessage"] = $"Exception: {ex}";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Create(ModelContact paramContact)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _contactRepository.Add(paramContact);
                    TempData["SuccessMessage"] = "Successful contact creation";
                    return RedirectToAction("Index");

                }
                return View(paramContact);
            }catch(Exception ex)
            {
                TempData["ErrorMessage"] = $"Contact creation was failed, try again\nDetails: {ex}";
                return RedirectToAction("Index");
            }

            
            
        }

        [HttpPost]
        public IActionResult Change(ModelContact paramContact)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    TempData["SuccessMessage"] = $"Contact successfuly changed";
                    _contactRepository.Update(paramContact);
                    return RedirectToAction("Index");
                }

                return View("Edit", paramContact);

            }catch(Exception ex)
            {
                TempData["ErrorMessage"] = $"Something went wrong: {ex}";
                return RedirectToAction("Index");
            }
        }

    }
}
