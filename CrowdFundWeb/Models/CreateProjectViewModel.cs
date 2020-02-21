using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundWeb.Models {
    public class CreateProjectViewModel
    {
        public CrowdFun.Core.model.options.AddProjects Create { get; set; }
        public string ErrorText { get; set; }
    }
}
