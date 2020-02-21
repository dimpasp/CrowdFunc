using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrowdFun.Core.model.options;

namespace CrowdFun.Core.model.services
{
    public class CreatorServices : ICreatorService
    {
        private readonly data.CrowdFunDbContext context_;
    
        public bool AddReward(int ownerId, Reward reward)
        {
            throw new NotImplementedException();
        }

        public Creator CreateNewCreator(AddNewCreatorOptions options)
        {
            //kai enan elegxo na kanw gia an uparxei
            if (options == null) {
                return null;
            }
            if (string.IsNullOrWhiteSpace(options.Password) ||
              string.IsNullOrWhiteSpace(options.Email)||
              string.IsNullOrWhiteSpace(options.FirstName)||
              string.IsNullOrWhiteSpace(options.LastName)) {
                return null;
            }
            var new_Creator = new Creator()
            {
                FirstName = options.FirstName,
                LastName = options.LastName,
                Email = options.Email,
                Password=options.Password          
            };
            context_.Add(new_Creator);
            try {
                context_.SaveChanges();
            } catch (Exception ex) {

                throw new Exception("you have wrong");
            }

            return new_Creator;
        }
             
        public IQueryable<Creator> SearchCreator(SearchProjects options)
        {
            var Creator_ = context_
           .Set<Creator>()
           .AsQueryable();

            if (options == null) {
                return null;
            } else if (string.IsNullOrWhiteSpace(options.Title)) {
                return null;
            }
            return Creator_;
        }
        public IQueryable<Creator> SearchOwnerById(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateBacker(int id, UpdateBacker options)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCreator_(int id, UpdateCreator options)
        {
            throw new NotImplementedException();
        }
    }
}
