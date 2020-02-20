using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrowdFun.Core.model.options;

namespace CrowdFun.Core.model.services
{
   public interface IBackerService
    {
        bool AddBackerNew(AddNewBackerOptions options);

        bool UpdateBacker(int id, UpdateBacker options);

        IQueryable<Backers> SearchBacker(SearchBaker options);

        IQueryable<Project> SearchProject(SearchProgramme options,int id);

    }
}
