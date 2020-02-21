﻿using System.Linq;
using CrowdFun.Core.model.options;
namespace CrowdFun.Core.model.services
{
    public interface ICreatorService
    {
        Creator CreateNewCreator(AddNewCreatorOptions options);

        public IQueryable<Creator> SearchCreator(SearchProjects options);

        bool AddReward(int ownerId, Reward reward);

    }
}