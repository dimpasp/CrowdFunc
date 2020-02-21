using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundWeb.Models {
    public class CreateBackerViewModel
    {
        public CrowdFun.Core.model.options.AddNewBackerOptions AddOptions { get; set; }
        public string ErrorText { get; set; }
    }
}
