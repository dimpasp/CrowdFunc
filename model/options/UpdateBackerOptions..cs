using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdFun.Core.model.options
{
    public class UpdateBacker
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public int Id { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public decimal NewDonate { get; set; }
    }
}
