using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdFun.Core.model
{
    public class Project
    {
        public int id { set; get; }
        public string Tittle { get; set; }
        public string Description { get; set; }
        public string Photos { get; set; }
        public decimal budget { get; set; }       
        public string Videos{ get; set; }   
        public DateTime DateCreated { get; set; }
        public DateTime Deadline { get; set; }
        public int Percentage { get; set; }
        public bool IsAvaliable { get; set; }

        // Navigation Property
        public int CreatorId { get; set; }
        public Creator Creator { get; set; }

        // Navigation property
        public List<Reward> Rewards { get; set; }

        //public ICollection<string> Media { get; set; }

        public Project()
        {
            DateCreated = DateTime.Today;
            Deadline = DateTime.Today.AddDays(25);
            //Media = new List<string>();
            //Rewards= new List<Reward>();
            //Status = new List<Status>();
        }
    }
}

