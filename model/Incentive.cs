using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdFun.Core.model
{
    public class Incentive
    {
        public int BackerId { get; set; }
        public Backer BackerUser { get; set; }

        public int RewardId { get; set; }
        public Reward Reward { get; set; }
    }
}
