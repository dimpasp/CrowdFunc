using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrowdFun.Core.model.options;

namespace CrowdFun.Core.model.services
{
   public interface IBackerService
    {
        Backers AddBackerNew(AddNewBackerOptions options);

        public bool UpdateBacker(int id, UpdateBacker options);

        Backers SearchBackerId(int id);

        public IQueryable<Backers> SearchBacker(SearchBaker options);


    }
}






