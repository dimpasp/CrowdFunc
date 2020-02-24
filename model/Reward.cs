using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CrowdFun.Core.model
{
    public class Reward
    {
        [Key]
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Title { get; set; }

        public int Percentage { get; set; }

        // nav property 
        public int ProjectId { get; set; }
        public Project Project { get; set; }

    }
}
