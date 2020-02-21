﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdFun.Core.model.options
{
    public class AddNewBackerOptions
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int? Id { get; set; }
        public string Password { get; set; }
        public decimal Donate { get; set; }
    }
}
