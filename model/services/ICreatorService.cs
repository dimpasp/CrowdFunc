using System.Linq;
using System.Threading.Tasks;
using CrowdFun.Core.model.options;
namespace CrowdFun.Core.model.services
{
    public interface ICreatorService
    {
        Task<ApiResult<Creator>> CreateNewCreatorAsync(AddNewCreatorOptions options);

        public IQueryable<Creator> SearchCreator(SearchProjects options);

        bool AddReward(int Id, Reward reward);
        public bool UpdateCreator(int id, UpdateBacker options);
        Creator SearchCreatorId(int Id);

    }
}

