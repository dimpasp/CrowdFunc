using System;
using System.Threading.Tasks;
using CrowdFun.Core.data;
using CrowdFun.Core.model.services;


namespace CrowdfundCore
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var context = new CrowdFunDbContext();
            context.Database.EnsureCreated();

            var BackerService = new BackerServices(context);
            var ProjectService = new ProjectServices(context);
            var RewardService = new RewardsService(context);

        }
        //var context = new CrowdFun.Core.data.CrowdFunDbContext();
        //context.Database.EnsureCreated();

        //var BackerService = new BackerServices(context);
        //var ProjectService = new ProjectServices(context);

        //BackerService.AddBacker(new Services.Options.AddBackerOptions
        //{
        //    Firstname = "Georgios",
        //    Lastname = "kotsidis",
        //    Donate = 2000,
        //    Email = "gggg@gmail.com",
        //    Phone = "69999999"
        //});
        //BackerService.UpdateBackerOptions(1, new Services.Options.UpdateBackerOptions
        //{
        //    Firstname = "dim",
        //    Lastname = "pasp",
        //    NewDonate = 1000,
        //    Email = "gggg@yahoo.gr",
        //    Phone = "666666666"
        //});

        //ProjectService.CreateProject(new Services.Options.AddProjectOptions
        //{
        //    Budget = 1500,
        //    Title = "Proj2ect 1",
        //    Description = "Des2cription1",


        //});
        //ProjectService.UpdateProject(1, new Services.Options.UpdateProjectOptions
        //{
        //    Budget = 1500,
        //    Title = "Project 1",
        //    Description = "Description1",
        //});

    }
}
