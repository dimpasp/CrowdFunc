using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrowdFun.Core.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrowdFun.Core.model;
using CrowFun.Extensions;
using CrowdFun.Core.model.services;
using CrowdFun.Core.model.options;
using Newtonsoft.Json;

namespace CrowFun.web.Controllers {
    public class ProjectController : Controller
        {
        private IProjectServices project_;

        public ProjectController(CrowdFunDbContext context)
        {
            project_ = new ProjectServices(context);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var availableProjects = await project_.GetAvailableProjects();

            return View(availableProjects);
        }

        [HttpGet("project/creationview")]
        public async Task<IActionResult> CreationView()
        {
            return View();
        }

        [HttpGet("project/create")]
        public async Task<object> CreateProject(string name, string description, decimal budget)
        {
            try {
                await project_.CreateProjectAsync(new AddProjects { 
                
                    Budget = budget,
                    Description = description,
                    ProjectTitle = name  
                });
                return true;

            } catch (Exception) {
                return false;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(
                         CrowdFundWeb.Models.CreateProjectViewModel model)
        {
            var result = await project_.CreateProjectAsync(
                model?.Create);

            if (result == null) {
                model.ErrorText = " Something went wrong";

                return View(model);
            }

            return Ok();
        }

        public class Post
        {
            public string ProjectTitle { get; set; }
            public string Description { get; set; }
        }

    }
}
