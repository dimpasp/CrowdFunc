﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdFun.Core.model
{
   public  class BackerReward
    {
        public int RewardId { get; set; }
        public int BackerId { get; set; }
        public Backer Backer { get; set; }
        public Reward Reward { get; set; }
    }
}
