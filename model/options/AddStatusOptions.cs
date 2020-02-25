using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdFun.Core.model.options
{
    public class AddStatusOptions
    {
        public int Id { get; set; }
        
        public Project project { get; set; }
        
        public int ProjectId { get; set; }
       
        public String comments { get; set; }
    }
}
