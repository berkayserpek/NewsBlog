﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface INewRepository : IGenericRepository<New>
    {
        List<New> GetListByUserID(int id);
        List<New> GetListByCategoryID(int id);
    }
}
