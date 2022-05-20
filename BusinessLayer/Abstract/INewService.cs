﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface INewService : IGenericService<New>
    {
        List<New> GetListByUserID(int id);
        List<New> GetListByCategoryID(int id);

    }
}
