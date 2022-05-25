using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsBlog2.Areas.Admin.Models
{
    public class UserUpdateVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Status { get; set; }
    }
}
