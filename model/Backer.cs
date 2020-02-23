using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CrowdFun.Core.model
{
    public class Backer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
      
        public string Password { get; set; }
        public decimal Donate { get; set; }

        // Navigation Property
        public List<Reward> Rewards { get; set; }
 
    }
}
