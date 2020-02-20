using System.Linq;
using System.Threading.Tasks;
using System;
using CrowdFun.Core.model.options;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CrowdFun.Core.model.services {
     public interface IProjectServices
     {
        IQueryable<Project> SearchProject(SearchProgramme options);
        IQueryable<Project> SearchProjectByCategory(ProjectsCategory options);
        bool BuyProject(int projectId, int backerId, int rewardId);

        public int GetProjectId(string title);

        bool UpdateCustomerProject(int id, UpdateProjectsOptions options);
        bool ChangeProjectStatus(int Id,StatusCode Status);
        Project CreateProject(int Id,AddProjects  options);
    }
}

       

    
       

      

       