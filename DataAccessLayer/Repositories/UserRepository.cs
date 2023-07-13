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
    public class UserRepository : IUserDal
    {
        DatabaseContext con = new DatabaseContext();
        public void AddUser(User user)
        {
            con.Add(user);
            con.SaveChanges();
        }

        public List<User> AllUserList()
        {
            return con.Users.ToList();
        }

        public void DeleteUser(User user)
        {
            con.Remove(user);
            con.SaveChanges();
        }

        public User GetById(int id)
        {
            return con.Users.Where(u => u.Id == id).FirstOrDefault();
        }

        public void UpdateUser(User user)
        {
           con.Update(user);
            con.SaveChanges();
        }

     
    }
}
