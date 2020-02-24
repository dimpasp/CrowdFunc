using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrowdFun.Core.model.options;
using Microsoft.EntityFrameworkCore;

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
                Price=options.Amount,
                Title = options.Description

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

        public Task<ApiResult<Reward>> GetRewardByIdAsync(int id, UpdateReward options)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResult<Reward>> UpdateRewardServiceAsync(int id, UpdateReward options)
        {
            if (id < 1) {
                return new ApiResult<Reward>(
                   StatusCode.BadRequest, $"not valid {id}");
            }

            var result = await context_
                        .Set<Reward>()
                        .Where(t => t.ProjectId == id)
                        .SingleOrDefaultAsync();

            if (result == null) {
                return new ApiResult<Reward>(
                     StatusCode.NotFound, $"this {result} dont exist");
            }

            return ApiResult<Reward>.CreateSuccess(result);
        }
    }  }
