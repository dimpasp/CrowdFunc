using System;
using System.Collections.Generic;
using System.Text;
using CrowdFun.Core.model;
using CrowdFun.Core.model.options;
using CrowdFun.Core.model;
namespace CrowdFun.model.services
{
    public interface IRewardService
    {
        Reward CreateReward(int id,AddRewardOptions options);

        Reward SearchRewardById(int id);

    }
}
