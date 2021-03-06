﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdFun.Core.model.options
{
   public class UpdateCreator
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public int? Id { get; set; }
        public string Email { get; set; }
        public decimal TotalCost { get; set; }
        public ICollection<Reward> Rewards { get; set; }
    }
}
