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
    public class NewManager : INewService
    {
        INewRepository _newRepository;

        public NewManager(INewRepository newRepository)
        {
            _newRepository = newRepository;
        }

        public List<New> GetListByUserID(int id)
        {
            return _newRepository.GetListByUserID(id);
        }

        public void TAdd(New t)
        {
            _newRepository.Insert(t);
        }

        public void TDelete(New t)
        {
            _newRepository.Delete(t);
        }

        public New TGetByID(int id)
        {
            return _newRepository.GetByID(id);
        }

        public List<New> TGetList()
        {
            return _newRepository.GetList();
        }

        public List<New> TGetListByWhere(string p)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(New t)
        {
            _newRepository.Update(t);
        }
    }
}
