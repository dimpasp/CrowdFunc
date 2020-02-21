using System.Linq;
using System.Threading.Tasks;
using CrowdFun.Core.model.options;
namespace CrowdFun.Core.model.services
{
    public interface ICreatorService
    {
        Creator CreateNewCreator(AddNewCreatorOptions options);      

        public bool UpdateCreator(int id, UpdateBacker options);
        Creator SearchCreatorById(int Id);
        IQueryable<Creator> SearchCreator(SearchCreatorOptions options);

    }
}

