﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsBlog2.Models
{
    public class UserUpdateVM
    {
        public string FirstName {get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
    }
}
