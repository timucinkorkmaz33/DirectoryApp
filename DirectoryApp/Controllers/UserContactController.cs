using BusinessLayer.Management;
using DataAccessLayer.EntityFramework;
using DirectoryApp.Models;
using EntityLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DirectoryApp.Controllers
{
    public class UserContactController : Controller
    {
       
        ContactInformationManagement contactMan = new ContactInformationManagement(new EFContactRepository());
        UserManagement userMan = new UserManagement(new EFUserRepository());
        public IActionResult Index()
        {

            return View();
        }
        public JsonResult DataGetir()
        {
            var list = contactMan.GetAllContact();
            List<UserInformationViewModel> vMList = new List<UserInformationViewModel>();
            foreach (var item in list)
            {
                var user=userMan.GetUserById(item.UserId);
                UserInformationViewModel vM = new UserInformationViewModel();
                vM.Id=item.Id;
                vM.UserId = item.UserId;
                vM.Email = item.Mail;
                vM.Phone = item.Phone;
                vM.Location = item.Location;
                vM.Information = item.Information;
                vM.NameSurname = user.Name + " " + user.Surname;
                vMList.Add(vM);

            }
            return Json(vMList);
        }

        public IActionResult Create()
        {
            ViewBag.UserList = userMan.GetAllUsers();
            return View();
        }


        [HttpPost]
        public JsonResult Create(ContactInformation contact)
        {
            var Allcontact = contactMan.GetAllContact();
            if (Allcontact.Count == 0)
            {
                contact.Id = 1;
            }
            else
            {
                contact.Id = Allcontact.Max(u=>u.Id) + 1;
            }
           
            contactMan.AddContact(contact);
            return Json(1);
        }

        public IActionResult Edit(int id)
        {
            ViewBag.UserList = userMan.GetAllUsers();
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
