using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CrowdFun.Core.data;
using CrowdFun.Core.model;
using CrowdFun.Core.model.options;
using CrowdFun.Core.model.services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CrowFun.web.Controllers
{
    public class ProjectController : Controller
        {
        private readonly IRewardsService incentives_;
        private IProjectServices project_;

        public ProjectController(CrowdFunDbContext context)
        {
            project_ = new ProjectServices(context);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var availableProjects = await project_.GetAvailableProjects();

            return View("List", availableProjects);
        }

        [HttpGet("project/createUpdate")]
        public async Task<IActionResult> CreateUpdate()
        {
            return View("ProjectForm");
        }

        [HttpGet("project/details/{id}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            var project = await project_.getProjectById(id);

            return View("Details", project.Data);
        }
        public IActionResult ListPopular()
        {
            return View();
        }
        [HttpGet("project/getbyid/{id}")]
        public async Task<IActionResult> GetProjectById(int id)
        {
            var project = await project_.getProjectById(id);

            return Json(project.Data,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
        }

        [HttpPost("project/create")]
        public async Task<object> CreateProject(string name, string description, decimal budget,
            [FromBody]List<Reward> rewards)
        {

          
            try {
                var prjectResult = await project_.CreateProjectAsync(new AddProjects {

                    Budget = budget,
                    Description = description,
                    ProjectTitle = name,
                    Rewards = rewards
                });

                return true;

            } catch (Exception) {
                return false;
            }
        }
        [HttpPost("project/AddProjectIncentive/{projectId}")]
        public IActionResult AddProjectIncentive(int projectId,
         [FromBody] AddRewardsOptions options)
        {
            return Ok();
        }
    }
}

