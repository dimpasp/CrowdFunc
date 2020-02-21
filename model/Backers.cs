using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdFun.Core.model
{
    public class Backers
    {
        List<string> rewards = new List<string>();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Id { get; set; }
        public string Password { get; set; }
        public ICollection<Project> GettingProject { get; set; }
        public ICollection<BackerReward> RewardsProject { get; set; }
        public Backers()
        {
            GettingProject = new List<Project>();
            RewardsProject = new List<BackerReward>();
        }

    }
}
