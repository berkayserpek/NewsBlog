using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewsBlog2.Models
{
    //[Validator(typeof(UserValidator))]
    public class UserRegisterVM
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime Birthday { get; set; }
    }
}
