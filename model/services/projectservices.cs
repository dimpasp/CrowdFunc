using System;
using System.Linq;
using System.Threading.Tasks;
using CrowdFun.Core.model.options;
using Microsoft.EntityFrameworkCore;

namespace CrowdFun.Core.model.services
{
    public class ProjectServices : IProjectServices
    {

        private readonly data.CrowdFunDbContext context_;
        public ProjectServices(data.CrowdFunDbContext ctx)
        {
            context_ = ctx ?? throw new ArgumentNullException(nameof(ctx));
        }
        public async Task<ApiResult<Project>> CreateProjectAsync( AddProjects options)
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
            if (options.Budget < 0) {
                return new ApiResult<Project>(
                    StatusCode.BadRequest, "Invalid project budget");
            }
            if (options.Creator == null) {
                return new ApiResult<Project>(
                    StatusCode.BadRequest, "Null creator");
            }


            var new_project = new Project()
            {              
                budget = options.Budget,
                Description = options.Description,
                Tittle = options.ProjectTitle,
                ProjectCreator = options.Creator,
                Photos = options.Photos,
                Videos = options.Video,
                Rewards = options.Rewards
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
            return project_;
        }

        public async Task<bool> UpdateProject(int id, UpdateProjectsOptions options)
        {
            var updproject = await context_.Set<Project>()
                .SingleOrDefaultAsync(p => p.id == id);

            if (updproject == null) {
                return false;
            }

            if (updproject.Description != null) {
                updproject.Description = options.Description;
            }

            if (updproject.budget > 0) {
                updproject.budget = options.Budget;
            }

            if (updproject.Tittle != null) {
                updproject.Tittle = options.ProjectTitle;
            }

            if (updproject.Photos != null) {
                updproject.Photos = options.Photo;
            }

            if (updproject.Videos != null) {
                updproject.Videos= options.Video;
            }

            context_.Update(updproject);
            try {
                await context_.SaveChangesAsync();
            } catch (Exception ex) {
                return false;
            }
            return true;
        }

        public async Task<ApiResult<Project>> getProjectById(int id)
        {
            if (id <= 0) {
                return new ApiResult<Project>(
                        StatusCode.BadRequest, "Null id");
            }
            var project = await context_.Set<Project>().SingleOrDefaultAsync(s => s.id == id);
            if (project == null) {
                return new ApiResult<Project>(
                        StatusCode.NotFound, "Backer not found"); ;
            }
            var api = new ApiResult<Project>();
            api.Data = project;
            api.ErrorCode = StatusCode.Ok;
            return api;
        }
    }
}
