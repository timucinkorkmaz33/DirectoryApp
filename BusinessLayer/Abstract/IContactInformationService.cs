using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContactInformationService
    {
        void AddContact(ContactInformation contact);
        void UpdateContact(ContactInformation contact);
        void DeleteContact(ContactInformation contact);
        List<ContactInformation> GetAllContact();
        ContactInformation GetContactById(int id);
    }
}
