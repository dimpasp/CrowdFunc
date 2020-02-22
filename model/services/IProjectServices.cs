using System.Linq;
using System.Threading.Tasks;
using System;
using CrowdFun.Core.model.options;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;

namespace CrowdFun.Core.model.services {
     public interface IProjectServices
     {
        IQueryable<Project> SearchProject(SearchProjects options);
        Task<bool> UpdateProject(int id, UpdateProjectsOptions options);
        Task<ApiResult<Project>> CreateProjectAsync(AddProjects  options);
        //Task<bool> UpdateStatus(int id,bool value);
        Task<List<Project>> GetAvailableProjects();

     }
}














