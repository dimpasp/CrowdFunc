using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdFun.Core.model
{
    public class Project
    {
  
        public int id { set; get; }
        public string Tittle { get; set; }
        public Creator ProjectCreator { get; set; }
        public string Description { get; set; }
        public string Photos { get; set; }
        public decimal budget { get; set; }       
        public string Videos{ get; set; }   
        public bool UpdateStatus { get;  set; }
        public ICollection<Project> Projects { get; set; }
        public ICollection<Status> Status { get; set; }
        public ICollection<Reward> Rewards { get; set; }
        public DateTime DateCreated { get; set; }
        public ICollection<string> Media { get; set; }
        public DateTime Deadline { get; set; }

        public Project()
        {
            DateCreated = DateTime.Today;
            Deadline = DateTime.Today.AddDays(25);
            Media = new List<string>();
            Rewards= new List<Reward>();
            Status = new List<Status>();
        }
    }
}

