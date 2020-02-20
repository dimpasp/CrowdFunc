using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrowdFun.Core.model.options;

namespace CrowdFun.Core.model.services
{
    public class BackerServices : IBackerService

    {
        private readonly data.CrowdFunDbContext context_;
        public bool AddBackerNew(AddNewBackerOptions options)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Backers> SearchBacker(SearchBaker options)
        {
            var backer_ = context_
                .Set<Backers>()
                .AsQueryable();


            if (options == null) {
                return null;
            }

            if (!string.IsNullOrWhiteSpace(options.Email)) {
                backer_ = backer_.Where(c =>
                    c.Email == options.Email);
            }
            if (!string.IsNullOrWhiteSpace(options.Id)) {
                backer_ = backer_.Where(c =>
                    c.Id == options.Id);
            }

            if (!string.IsNullOrWhiteSpace(options.FirstName)) {
                backer_ = backer_.Where(c =>
                    c.FirstName == options.FirstName);
            }

            if (!string.IsNullOrWhiteSpace(options.LastName)) {
                backer_ = backer_.Where(c =>
                    c.LastName == options.LastName);
            }
          
            return backer_;
        }

        public IQueryable<Project> SearchProject(SearchProgramme options,int id)
        {
            var project_ = context_
               .Set<Project>()
               .AsQueryable();

            if (id < 0) {
                return null;
            }
            if (!string.IsNullOrWhiteSpace(options.Title)) {
                project_ = project_.Where(c =>
                    c.Tittle==options.Title);
            }
          
            return project_;
        }

        public bool UpdateBacker(int id, UpdateBacker options)
        {
            throw new NotImplementedException();
        }
    }
}
