using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrowdFun.Core.model.options;

namespace CrowdFun.Core.model.services
{
   public interface IBackerService
    {
        Task<ApiResult< Backer>> AddBackerNewAsync(AddNewBackerOptions options);                                                                //Model.Options.CreateCustomerOptions options);

        public bool UpdateBacker(int id, UpdateBacker options);

        Backer SearchBackerId(int id);

        public IQueryable<Backer> SearchBacker(SearchBaker options);
    }
}






