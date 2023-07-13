using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Repositories;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Management
{
    public class ContactInformationManagement : IContactInformationService
    {
        IContactInformationDal _contact;

        public ContactInformationManagement(IContactInformationDal contact)
        {
            _contact = contact;
        }

        public void AddContact(ContactInformation contact)
        {
            _contact.Add(contact);
        }

        public void DeleteContact(ContactInformation contact)
        {
            _contact.Delete(contact);
        }

        public List<ContactInformation> GetAllContact()
        {
            return _contact.GetList();
        }

        public ContactInformation GetContactById(int id)
        {
            return _contact.GetById(id);
        }

        public void UpdateContact(ContactInformation contact)
        {
            _contact.Update(contact);
        }
    }
}
