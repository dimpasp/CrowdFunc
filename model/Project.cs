using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdFun.Core.model
{
    public class Project
    {
        //thelei douleia
        public int id { set; get; }
        public string Tittle { get; set; }

        public string Description { get; set; }
        public string Photos { get; set; }
        public string Videos{ get; set; }
        public bool UpdateStatus { get;  set; }
        public ICollection<Project> Projects { get; set; }
        public ICollection<Reward> Rewards { get; set; }

        public Project()
        {
            Projects = new List<Project>();
            Rewards = new List<Reward>();
        }
    }

}

