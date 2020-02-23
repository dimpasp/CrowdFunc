using System;
using System.Threading.Tasks;
using CrowdFun.Core.data;
using CrowdFun.Core.model.options;
using CrowdFun.Core.model.services;
using Microsoft.AspNetCore.Mvc;

namespace CrowFun.web.Controllers
{
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
            Console.WriteLine( project.id);
            return View("Details", project);
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

       

    }
}

