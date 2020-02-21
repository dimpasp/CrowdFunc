using System.Linq;
using System.Threading.Tasks;
using CrowdFun.Core.model.options;
namespace CrowdFun.Core.model.services
{
    public interface ICreatorService
    {
        Task<ApiResult<Creator>> CreateNewCreatorAsync(AddNewCreatorOptions options);

        Task<bool> UpdateProjectCreator(int id, UpdateCreator options);
        Creator SearchCreatorById(int Id);
        IQueryable<Creator> SearchCreator(SearchCreatorOptions options);

    }
}

