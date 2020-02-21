using System;
using System.Linq;
using System.Threading.Tasks;
using CrowdFun.Core.model.options;

namespace CrowdFun.Core.model.services
{
    public class ProjectServices : IProjectServices
    {

        private readonly data.CrowdFunDbContext context_;
        public Project GettingProject(int projectId, int backerId, int rewardId)
        {
            throw new NotImplementedException();
        }


        public async Task<ApiResult<Project>> CreateProjectAsync(int Id, AddProjects options)
        {
            if (options == null || options.Project_Category<=0) {
                return new ApiResult<Project>(
                   StatusCode.BadRequest, "Null options");
            }

            if (string.IsNullOrWhiteSpace(options.ProjectTitle) ||
              string.IsNullOrWhiteSpace(options.Description)) {
                return new ApiResult<Project>(
                   StatusCode.BadRequest, "Null options");
            }
            var new_project = new Project()
            {
            };
            context_.Add(new_project);
            try {
                await context_.SaveChangesAsync();
            } catch (Exception ex) {
                return new ApiResult<Project>(
                    StatusCode.InternalServerError, "Could not save creator");
            }

            return new ApiResult<Project>()
            {
                ErrorCode = StatusCode.Ok,
                Data = new_project
            };
        }

        public int GetProjectById(string title)
        {
            if (string.IsNullOrWhiteSpace(title)) {
                return 0;
            }
            var project_ = context_
                .Set<Project>()
                .AsQueryable();

            project_ = project_.Where(c =>
                     c.Tittle == title);

            var returnProject = project_.SingleOrDefault();
            if (returnProject == null) {
                return 0;
            } else {
                return returnProject.id;
            }

        }

        public IQueryable<Project> SearchProject(SearchProjects options,int id)
        {
            var project_ = context_
             .Set<Project>()
             .AsQueryable();

            if (options ==null || id<0) {
                return null;   
            }else if (string.IsNullOrWhiteSpace(options.Title)) {
                return null;
            }else if (!string.IsNullOrWhiteSpace(options.Title)) {
                project_ = project_.Where(t=>t.Tittle==options.Title);
            } 
            return project_;
        }    
        public IQueryable<Project> SearchProjectByCategory(ProjectsCategory options)
        {
            var project_ = context_
              .Set<Project>()
              .AsQueryable();

            if (options != 0) {
                //project_ = project_.Where(p=>p.ProjectsCategory==cate);
            }
            return project_;
        }   
    }
}
