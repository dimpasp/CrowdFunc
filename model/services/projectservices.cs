using System;
using System.Linq;
using System.Threading.Tasks;
using CrowdFun.Core.model.options;

namespace CrowdFun.Core.model.services
{
    public class ProjectServices : IProjectServices
    {

        private readonly data.CrowdFunDbContext context_;
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
            //var user = users.SearchUser(new Model.Options.User.SearchUserOptions()
            //{
            //    UserId = userId
            //}).SingleOrDefault();

            //if (user == null) {
            //    return false;
            //}

            var new_project = new Project()
            //{
            //    ProjectUser = user,
            //    ProjectDescription = options.ProjectDescription,
            //    ProjectTitle = options.ProjectTitle,
            //    ProjectFinancialGoal = options.ProjectFinancialGoal,
            //    ProjectCategory = options.ProjectCategory,
            //    ProjectDateExpiring = options.ProjectDateExpiring,
            //    ProjectCapitalAcquired = options.ProjectCapitalAcquired
           ; //};
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
        public IQueryable<Project> SearchProject(SearchProjects options)
        {
            var project_ = context_
                .Set<Project>()
                .AsQueryable();

            if (options == null) {
                return null;
            }

            if (!string.IsNullOrWhiteSpace(options.Title)) {
                project_ = project_.Where(p =>
                    p.Tittle== options.Title);
            }

            if (options.Id <= 0) {
                project_ = project_.Where(p =>
                    p.id == options.Id);
            }

            //if (options.BrowseByCategory != 0) {
            //    query = query.Where(p =>
            //       p. == options.BrowseByCategory);
            //}

            return project_;
        }

        public bool UpdateProject(int id, UpdateProjectsOptions options)
        {
            var project = GetProjectById(id);
            if ((options == null)||
                (project == null)){
                return false;
            }

            if (!string.IsNullOrWhiteSpace
                (options.ProjectTitle)) {
                project.Tittle = options.ProjectTitle;
            }
            if (!string.IsNullOrWhiteSpace
                (options.Description)) {
                project.Description = options.Description;
            }

            return true;
        }

        public Project GetProjectById(int id)
        {
            if (id == 0) {
                return null;
            }
            return context_
                .Set<Project>()
                .SingleOrDefault(p => p.id == id);
        }
    }
}
