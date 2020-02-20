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
            public float Value { get; set; }
            public Backers backers { get; set; }
            public ICollection<BackerReward> Backre { get; set; }
            public Reward()
            {
                Backre = new List<BackerReward>();
            }
        }
}
