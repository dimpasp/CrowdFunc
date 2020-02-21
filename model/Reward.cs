using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdFun.Core.model
{
        public class Reward
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public decimal Value { get; set; }
            public Backers backers { get; set; }
            public Project project { get; set; }
            public ICollection<BackerReward> Backer { get; set; }
            public Reward()
            {
                Backer = new List<BackerReward>();
            }
        }
}
