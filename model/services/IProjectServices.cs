using System.Linq;
using System.Threading.Tasks;
using System;
using CrowdFun.Core.model.options;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CrowdFun.Core.model.services {
     public interface IProjectServices
     {
        IQueryable<Project> SearchProject(SearchProjects options,int id);
        IQueryable<Project> SearchProjectByCategory(ProjectsCategory options);
        Project GettingProject(int projectId, int backerId, int rewardId);

        public int GetProjectById(string title);
        Task<ApiResult<Project>> CreateProjectAsync(int Id,AddProjects  options);
        
    }
}

       

    
       

      

       