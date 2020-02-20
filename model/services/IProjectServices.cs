using System.Linq;
using System.Threading.Tasks;
using System;
using CrowdFun.Core.model.options;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CrowdFun.Core.model.services {
     public interface IProjectServices
     {
        IQueryable<Project> SearchProject(SearchProgramme options,int id);
        IQueryable<Project> SearchProjectByCategory(ProjectsCategory options);
        Project GettingProject(int projectId, int backerId, int rewardId);

        public int GetProjectById(string title);

        bool ChangeProjectStatus(int Id,StatusCode Status);
        Project CreateProject(int Id,AddProjects  options);
    }
}

       

    
       

      

       