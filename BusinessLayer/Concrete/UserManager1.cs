using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserManager1 : IUserService
    {
        IUserRepository _userRepository;

        public UserManager1(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void TAdd(UserPerson t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(UserPerson t)
        {
            throw new NotImplementedException();
        }

        public UserPerson TGetByID(int id)
        {
            return _userRepository.GetByID(id);
        }

        public List<UserPerson> TGetList()
        {
            return _userRepository.GetList();
        }

        public List<UserPerson> TGetListByWhere(string p)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(UserPerson t)
        {
            throw new NotImplementedException();
        }
    }
}
