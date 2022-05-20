using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class NewRepository : GenericRepository<New>, INewRepository
    {
        public List<New> GetListByCategoryID(int id)
        {
            using var c = new Context();
            return c.Set<New>().Where(x => x.CategoryID == id).ToList();
        }

        public List<New> GetListByUserID(int id)
        {
            using var c = new Context();
            return c.Set<New>().Where(x => x.UserID == id).ToList();
        }
    }
}
