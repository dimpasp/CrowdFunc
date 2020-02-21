using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdFun.Core.model.options
{
    public class SearchProjects
    {
        
        public int Id { get; set; }
        //Browse by ttitle
        public string Title { get; set; }
        public StatusCode Status { get; set; }
        //browse by category
        public ProjectsCategory BrowseByCategory{ get; set; }

    }
}


