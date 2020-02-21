using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdFun.Core.model
{
    public class Creator
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Id { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public ICollection<Project> Project_ { get; set; }
        public ICollection<Reward> Rewards_ { get; set; }
        public DateTimeOffset UserDateCreated { get; set; }

        public Creator()
        {
            UserDateCreated = DateTimeOffset.Now;
        }

    }
}
