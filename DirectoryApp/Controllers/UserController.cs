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
        public IActionResult Index()
        {

            return View();
        }
        public JsonResult DataGetir()
        {
            var list = userMan.GetAllUsers().Where(u=>u.IsActive==true);
            return Json(list);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public JsonResult Create(User user)
        {
            var maxId=userMan.GetAllUsers().Max(u=>u.Id);
            user.Id = maxId+1;
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
            }
         
            return RedirectToAction(nameof(Index));
        }

    }
}
