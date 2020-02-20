using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrowdFun.Core.model.options;

namespace CrowdFun.Core.model.services
{
    public class CreatorServices : ICreatorService
    {
        public bool AddCreator(AddNewCreatorOptions options)
        {
            throw new NotImplementedException();
        }

        public bool AddReward(int ownerId, Reward reward)
        {
            throw new NotImplementedException();
        }

        public Creator CreateNewCreator(AddNewCreatorOptions options)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Creator> SearchCreator(SearchProgramme options)
        {
            throw new NotImplementedException();
        }

        public ICollection<Creator> SearchCreator_(SearchProject options)
        {
            throw new NotImplementedException();
        }

        public Creator SearchOwnerById(int ownerId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCreator_(int id, UpdateCreator options)
        {
            throw new NotImplementedException();
        }

        public bool UpdateOwner(int id, UpdateCreator options)
        {
            throw new NotImplementedException();
        }
    }
}
