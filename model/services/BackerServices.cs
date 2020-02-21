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
        public Backers AddBackerNew(AddNewBackerOptions options)
        {
            if (options == null) {
                return null;
            }

            if (string.IsNullOrWhiteSpace(options.FirstName) ||
                string.IsNullOrWhiteSpace(options.LastName) ||
                string.IsNullOrWhiteSpace(options.Email) ||
                string.IsNullOrWhiteSpace(options.Id)||
                string.IsNullOrWhiteSpace(options.Password)){
                return null;
            }
            var backer = new Backers()
            {
                FirstName = options.FirstName,
                LastName = options.LastName,
                Id = options.Id,
                Password = options.Password,
                Email = options.Email         
            };
            context_.Add(backer);
            return backer;
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

        public Backers SearchBackerId(int id)
        {
            var backer_ = context_
               .Set<Backers>();
               //.SingleOrDefault(s => s.Id==id);

            if (id < 0) {
                return null;
            }

           return backer_;
        }

        public bool UpdateBacker(int id, UpdateBacker options)
        { 
            var backer = SearchBackerId(id);
            if ((id <= 0)|| (options == null)) {
                return false;
            }
           

            //thelei douleia
            return false;
        }
    }
}
