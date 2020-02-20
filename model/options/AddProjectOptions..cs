using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdFun.Core.model.options {
   public  class AddProjects {
        public string ProjectTitle { get; set; }

        public string Description { get; set; }
        public bool UpdateStatus { get; set; }
        public string Photos { get; set; }
        public string Video { get; set; }
        public int Id { get; set; }
        public ProjectsCategory Project_Category { get; set; }

    }
}
