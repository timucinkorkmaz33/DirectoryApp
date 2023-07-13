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
    public class UserManagement : IUserService
    {
        IUserDal _userDal;

        public UserManagement(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void AddUser(User user)
        {

            if (user.Name != "" && user.Surname != "" && user.Company != "")
            {
                user.IsActive = true;
                _userDal.Add(user);
            }
            else
            {
                //Hata Döndür
            }
        }

        public void DeleteUser(User user)
        {
            if (user.Id>0)
            {
                //Normal işlemde silinebilir fakat ben isactive durumunu 0 yapacam
                //efUser.Delete(user);
                user.IsActive = false;
                _userDal.Update(user);
            }
            else
            {
                //Hata Döndür
            }
        }

        public List<User> GetAllUsers()
        {
           return _userDal.GetList();
        }

        public User GetUserById(int id)
        {
            return _userDal.GetById(id);
        }

        public void UpdateUser(User user)
        {
            if (user.Id >0)
            {

                _userDal.Update(user);
            }
            else
            {
                //Hata Döndür
            }
        }
    }
}
