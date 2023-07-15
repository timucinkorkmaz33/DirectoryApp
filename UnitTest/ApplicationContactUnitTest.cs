using DirectoryApp.Controllers;
using EntityLayer.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public class ApplicationContactUnitTest
    {
        [Test]
        public void ContactEditGetElementUnitTest()
        {
            var ContactCont = new UserContactController();

            var contact = new ContactInformation()
            {
                Id = 1,
                Information = "Test",
                Location = "Test",
                Mail = "Test",
                UserId = 1,
            };
            //Güncelleme sayfasından Id gelmez yada eşit olmaz ise fail dönüş sağlanır.
            //Bazı kontroller view sayfasında yapılmıştır. Bunlar unitTest örnekleri olması için yazılmıştır.
            var Id = 1;
            var result = ContactCont.Edit(Id,contact);
            if (result.Value.ToString() =="1")
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
