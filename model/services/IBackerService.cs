using System;
using System.Collections.Generic;
using System.Text;
using CrowdFun.Core.model.options;

namespace CrowdFun.Core.model.services
{
   public interface IBackerService
    {
        bool AddBackerNew(AddNewBackerOptions options);

        bool UpdateBacker(int id, UpdateBacker options);

        ICollection<Backers> SearchBacker(SearchBaker options);

        ICollection<Project> SelectProject(int projectid);

    }
}
