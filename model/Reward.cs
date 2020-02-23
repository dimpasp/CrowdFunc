using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdFun.Core.model
{
    public class Reward
    { // nav properties
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public int BackerId { get; set; }
        public Backer Backer { get; set; }

        public int Percentage { get; set; }

        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
