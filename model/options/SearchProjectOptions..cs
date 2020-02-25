using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdFun.Core.model.options
{
    public class SearchProjects
    {
        
        public int Id { get; set; }
       
        public string Title { get; set; }
        public string Email{ get; set; }
        public StatusCode Status { get; set; }
        public ProjectsCategory BrowseByCategory{ get; set; }
        public decimal budget { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime Deadline { get; set; }
    }
}


