using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdFun.Core.model.options {
   public class UpdateProjectsOptions {
        public string ProjectTitle { get; set; }

        public string Description { get; set; }
        public bool UpdateStatus { get; set; }
        public decimal ProjectGoal { get; set; }
        //public StatusCode Status { get; set; }
        public ProjectsCategory ProjectCategory { get; set; }
    }
}
