using System.Linq;
using System.Threading.Tasks;
using CrowdFun.Core.model.options;

namespace CrowdFun.Core.model.services
{
    public interface IRewardsService
    {
        Task<ApiResult<IQueryable<Reward>>> GetRewardByIdAsync(int projectId);
        Task<ApiResult<Reward>> UpdateRewardServiceAsync(int id, UpdateReward options);
        Task<ApiResult<Reward>> CreateRewards(AddRewardsOptions options);
        Task<ApiResult<BackerReward>> AddBackerToReward(int projectId, int incentiveId);
    }
}
