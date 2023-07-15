using DirectoryApp.Controllers;
using EntityLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public class ApplicationUserUnitTest
    {
        [Test]
        public void AppUserAddUnitTest()
        {
            var userCont = new UserController();
            var user = new EntityLayer.Models.User
            {
                Name = "Test",
                Company = "Test",
                Surname = "Test",
                //alanlardan biri boş gönderilirse fail sonuc alınır
            };
            var result = userCont.Create(user);
            if (result.Value.ToString() == "1")
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();

            }
        }
    }
}
