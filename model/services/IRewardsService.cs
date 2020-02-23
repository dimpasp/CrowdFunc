using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CrowdFun.Core.model.options;

namespace CrowdFun.Core.model.services
{
    public interface IRewardsService
    {
        Task<ApiResult<Reward>> GetRewardByIdAsync(int id,UpdateReward options);
        Task<ApiResult<Reward>> UpdateRewardServiceAsync(int id, UpdateReward options);
        Task<ApiResult<Reward>> CreateRewards(AddRewardsOptions options);
    }
}
