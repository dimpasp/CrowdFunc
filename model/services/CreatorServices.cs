using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using CrowdFun.Core.model.options;

namespace CrowdFun.Core.model.services
{
    public class CreatorServices : ICreatorService
    {
        private readonly data.CrowdFunDbContext context_;
    
        public bool AddReward(int Id, Reward reward)
        {
            if (reward == null) {
                return false;
            }           
            var creator = SearchCreatorId(Id);
           // creator.Reward.Add(reward);
            return true;
        }

        public async Task<ApiResult<Creator>> CreateNewCreatorAsync(AddNewCreatorOptions options)
        {
            //kai enan elegxo na kanw gia an uparxei
            if (options == null) {
                return new ApiResult<Creator>(
                    StatusCode.BadRequest, "Null options");
            }
            if (string.IsNullOrWhiteSpace(options.Password) ||
              string.IsNullOrWhiteSpace(options.Email)||
              string.IsNullOrWhiteSpace(options.FirstName)||
              string.IsNullOrWhiteSpace(options.LastName)) {
                return new ApiResult<Creator>(
                    StatusCode.BadRequest, "Null options");
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
               await context_.SaveChangesAsync();
            } catch (Exception ex) {
                return new ApiResult<Creator>(
                    StatusCode.InternalServerError, "Could not save creator");
            }

            return new ApiResult<Creator>()
            {
                ErrorCode = StatusCode.Ok,
                Data = new_Creator
            };
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

        public Creator SearchCreatorId(int Id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCreator(int id, UpdateBacker options)
        {
            var creator = SearchCreatorId(id);
            var built = false;
            if ((id<0)||
                (options == null)) {
                return false;
            }
            if (!string.IsNullOrWhiteSpace(options.FirstName)) {
                creator.FirstName = options.FirstName;
            }
            if (!string.IsNullOrWhiteSpace(options.LastName)) {
                creator.LastName = options.LastName;
            }
            if (!string.IsNullOrWhiteSpace(options.Password)) {
                creator.Password = options.Password;
            }
            try {
                built = context_.SaveChanges() > 0;
            } catch (Exception ex) {
            }
            return built;
        }
    }
}
