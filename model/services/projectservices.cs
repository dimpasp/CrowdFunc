using System;
using System.Linq;
using CrowdFun.Core.model.options;

namespace CrowdFun.Core.model.services
{
    public class ProjectServices : IProjectServices

    {
        private readonly data.CrowdFunDbContext context_;
        public bool BuyProject(int projectId, int backerId, int rewardId)
        {
            throw new NotImplementedException();
        }

        public bool ChangeProjectStatus(int Id, StatusCode Status)
        {
            throw new NotImplementedException();
        }

        public Project CreateProject(int Id, AddProjects options)
        {
            throw new NotImplementedException();
        }

        public int GetProjectId(string title)
        {
            if (string.IsNullOrWhiteSpace(title)) {
                return 0;
            }
            var query = context_
                .Set<Project>()
                .AsQueryable();

            query = query.Where(c =>
                    c.Tittle == title);

            var project = query.SingleOrDefault();
            if (project == null) {
                return 0;
            } else {
                return project.id;
            }
        }

        public IQueryable<Project> SearchProject(SearchProgramme options)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Project> SearchProjectByCategory(ProjectsCategory options)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCustomerProject(int id, UpdateProjectsOptions options)
        {
            throw new NotImplementedException();
        }
    }
}