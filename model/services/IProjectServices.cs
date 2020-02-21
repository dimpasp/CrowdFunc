using System.Linq;
using System.Threading.Tasks;
using System;
using CrowdFun.Core.model.options;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CrowdFun.Core.model.services {
     public interface IProjectServices
     {
        IQueryable<Project> SearchProject(SearchProjects options);
      bool UpdateProject(int id,UpdateProjectsOptions options); 

        public Project GetProjectById(int id);
        Task<ApiResult<Project>> CreateProjectAsync(AddProjects  options); 
        

    }
}














