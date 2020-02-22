using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdFun.Core.model
{
    public class Creator
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public DateTimeOffset UserDateCreated { get; set; }
        public decimal TotalCost { get; set; }
        
        // Navigation Property
        public List<Project> Projects { get; set; }

        public Creator()
        {
            UserDateCreated = DateTimeOffset.Now;
        }

    }
}
