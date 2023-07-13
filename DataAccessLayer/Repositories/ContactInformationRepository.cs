using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class ContactInformationRepository : IContactInformationDal
    {
        DatabaseContext con=new DatabaseContext();
        public void AddContractInformation(ContactInformation contact)
        {
            con.Add(contact);
            con.SaveChanges();
        }

        public List<ContactInformation> AllContractInformationList()
        {
           return con.ContactInformations.ToList(); 
        }

        public void DeleteContractInformation(ContactInformation contact)
        {
           con.Remove(contact);
            con.SaveChanges();
        }

        public ContactInformation GetById(int id)
        {
          return con.ContactInformations.Where(u=>u.Id==id).FirstOrDefault();
        }

        public void UpdateUContractInformation(ContactInformation contact)
        {
           con.Update(contact);
        }
    }
}
