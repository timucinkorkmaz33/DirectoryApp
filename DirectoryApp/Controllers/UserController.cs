using BusinessLayer.Management;
using DataAccessLayer.EntityFramework;
using EntityLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DirectoryApp.Controllers
{
    public class UserController : Controller
    {
        UserManagement userMan = new UserManagement(new EFUserRepository());
        ContactInformationManagement contactMan = new ContactInformationManagement(new EFContactRepository());

        public IActionResult Index()
        {

            return View();
        }
        public JsonResult DataGetir()
        {
            var list = userMan.GetAllUsers();
            return Json(list);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public JsonResult Create(User user)
        {
            var Users=userMan.GetAllUsers();
            if (Users.Count() == 0)
            {
                user.Id = 1;
            }
            else
            {
                
                user.Id = Users.Max(u=>u.Id) + 1;

            }
            userMan.AddUser(user);
            return Json(1);
        }

        public IActionResult Edit(int id)
        {

            var User = userMan.GetUserById(id);
            if (User == null)
            {
                return NotFound();
            }
            return View(User);
        }

        [HttpPost]
        public JsonResult Edit(User user)
        {
          
            userMan.UpdateUser(user);
            return Json(1);
        }




        public ActionResult Delete(int id)
        {

            var user = userMan.GetUserById(id);
            if (user != null)
            {
              userMan.DeleteUser(user);
                var thisUserContact = contactMan.GetAllContact().Where(u => u.UserId == id);
                if (thisUserContact.Count() > 0)
                {
                    foreach (var item in thisUserContact)
                    {
                        contactMan.DeleteContact(item);
                    }
                }
            }
         
            return RedirectToAction(nameof(Index));
        }

    }
}
