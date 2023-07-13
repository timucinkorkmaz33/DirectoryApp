using BusinessLayer.Management;
using DataAccessLayer.EntityFramework;
using EntityLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DirectoryApp.Controllers
{
    public class UserContactController : Controller
    {
        ContactInformationManagement contactMan = new ContactInformationManagement(new EFContactRepository());
        public IActionResult Index()
        {

            return View();
        }
        public JsonResult DataGetir()
        {
            var list = contactMan.GetAllContact();
            return Json(list);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public JsonResult Create(ContactInformation contact)
        {
            var maxId = contactMan.GetAllContact().Max(u => u.Id);
            contact.Id = maxId + 1;
            contactMan.AddContact(contact);
            return Json(1);
        }

        public IActionResult Edit(int id)
        {

            var contact = contactMan.GetContactById(id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }

        [HttpPost]
        public JsonResult Edit(int id, ContactInformation contact)
        {

            contactMan.UpdateContact(contact);
            return Json(1);
        }




        public ActionResult Delete(int id)
        {

            var contact = contactMan.GetContactById(id);
            if (contact != null)
            {
                contactMan.DeleteContact(contact);
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
