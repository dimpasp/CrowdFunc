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
        private readonly IProjectServices projects;
        private readonly IBackerService backers;
        private readonly IRewardsService rewards;
        private readonly data.CrowdFunDbContext context_;
        public RewardsService(data.CrowdFunDbContext ctx, IBackerService bckr, IRewardsService rws)
        {
            context_ = ctx ?? throw new ArgumentNullException(nameof(ctx));
            backers = bckr ?? throw new ArgumentNullException(nameof(bckr));
            rewards = rws ?? throw new ArgumentNullException(nameof(rws));
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
                Price = options.Amount,
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

        public async Task<ApiResult<IQueryable<Reward>>> GetRewardByIdAsync(int id)
        {
            if (id <= 0) {
                return new ApiResult<IQueryable<Reward>>(
              StatusCode.BadRequest,
              "Project id cannot be equal to or less than 0");
            }
            var reward = context_.Set<Reward>().Where(r => r.Id == id);

            return ApiResult<IQueryable<Reward>>.CreateSuccess(context_
                .Set<Reward>()
                .AsQueryable());

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

        public async Task<ApiResult<BackerReward>> AddBackerToReward(int rewardId, int backerId)
        {
            if (rewardId <= 0) {
                return new ApiResult<BackerReward>(
                    StatusCode.BadRequest,
                    "Incentive id cannot be equal to or less than 0");
            }

            if (backerId <= 0) {
                return new ApiResult<BackerReward>(
                    StatusCode.BadRequest,
                    "Backer id cannot be equal to or less than 0");
            }

            var backer = backers.SearchBackerId(backerId);
            var reward = await rewards.GetRewardByIdAsync(rewardId);

            var backerReward = new BackerReward()
            {
                Backer = backer,
                Reward = reward.Data.SingleOrDefault()
            };
            context_.Add(backerReward);
            var success = false;

            try {
                success = await context_.SaveChangesAsync() > 0;
            } catch (Exception ex) {
                return new ApiResult<BackerReward>(
                    StatusCode.InternalServerError, $"{ex}");
            }
            if (success) {
                return ApiResult<BackerReward>.CreateSuccess(null);
            } else {
                return new ApiResult<BackerReward>(
                    StatusCode.InternalServerError, $"Something went wrong, backer not added");
            }
        }
    }
}
