using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrowdFun.Core.model.options;

namespace CrowdFun.Core.model.services
{
    public class RewardsService : IRewardsService
    {
        private readonly data.CrowdFunDbContext context_;
        public RewardsService(data.CrowdFunDbContext ctx)
        {
            context_ = ctx ?? throw new ArgumentNullException(nameof(ctx));
        }

        public async Task<ApiResult<Reward>> CreateRewards(AddRewardsOptions options)
        {
            if (options == null) {
                return new ApiResult<Reward>(
                    StatusCode.BadRequest, "Null options");
            }

            if (string.IsNullOrWhiteSpace(options.Description)) {
                return new ApiResult<Reward>(
                    StatusCode.BadRequest, "Null Description");
            }

            if (options.Amount < 0.0M) {
                return new ApiResult<Reward>(
                    StatusCode.BadRequest, "Invalid reward amount");
            }

            if (options.projectId < 0) {
                return new ApiResult<Reward>(
                    StatusCode.BadRequest, "Invalid projectId");
            }


            var reward = new Reward()
            {
                Value = options.Amount,
                Description = options.Description,


            };

            await context_.AddAsync(reward);

            try {
                await context_.SaveChangesAsync();
                Console.WriteLine("ok reward");
            } catch (Exception ex) {
                Console.WriteLine("fail add reward");
                Console.WriteLine(ex);
                return new ApiResult<Reward>(
                    StatusCode.InternalServerError, "Could not save reward");
            }

            return ApiResult<Reward>.CreateSuccess(reward);
        }
        public Reward SearchRewardById(int id)
        {
            if (id <= 0) {
                return null;
            }
            return context_
                .Set<Reward>()               
                .SingleOrDefault(s => s.project.id == id);


        }

    }
}