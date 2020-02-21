using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdFun.Core.model.options
{
    public class SearchRewardsOptions
    {
        public int id { get; set; }     
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public Project project { get; set; }
    }
}
