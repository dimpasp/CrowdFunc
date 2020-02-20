using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdFun.Core.model.options {
    public class TrendyProjects 
    {
        public int Id { get; set; }
        public Project Project { get; set; }
        public decimal TotalPrice { get; set; }
        public string Description { get; set; }
    }
}
