using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdFun.Core.model.options
{
   public  class AddRewardsOptions
    {
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public int projectId { get; set; }
    }
}
