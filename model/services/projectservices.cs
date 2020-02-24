using System;
using System.Collections.Generic;
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
            var new_project = new Project()
            {
                CreatorId = 3,
                budget = options.Budget,
                Description = options.Description,
                Tittle = options.ProjectTitle,
                DateCreated = DateTime.Now,
                Deadline = DateTime.Now.AddDays(20)
            };

            new_project.Rewards.AddRange(options.Rewards);
            context_.Add(new_project);
            try {
                await context_.SaveChangesAsync();
            } catch(Exception e) {
                Console.WriteLine(e);
            }

            //if(new_project.id != 0) {

            //    if (options.Rewards != null && options.Rewards.Count() != 0) {

            //        options.Rewards.ForEach(r => r.ProjectId = new_project.id);

            //        context_.AddRange(options.Rewards);
            //        context_.SaveChanges();

            //    }
            //}
            
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

            if (updproject.Percentage == 0)
                updproject.IsAvaliable = false;
            else
                updproject.IsAvaliable = true;


            context_.Update(updproject);
            try {
                await context_.SaveChangesAsync();
            } catch (Exception ex) {
                return false;
            }
            return true;
        }

        public async Task<Project> getProjectById(int id)
        {
            return await  context_.Projects.SingleOrDefaultAsync(s => s.id == id); 
        }

        public async Task<List<Project>> GetAvailableProjects()
        {
            return await context_.Projects.ToListAsync();
        }
    }
}
