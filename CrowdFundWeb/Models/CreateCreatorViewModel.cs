using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundWeb.Models {
    public class CreateCreatorViewModel
    {
        public CrowdFun.Core.model.options.AddNewCreatorOptions Create { get; set; }
        public string ErrorText { get; set; }
    }
}
