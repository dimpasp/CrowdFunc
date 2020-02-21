using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrowdFun.Core.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrowdFun.Core.data;
using CrowdFun.Core.model;
using CrowFun.Extensions;

namespace CrowFun.web.Controllers {
    public class ProjectController : Controller
        {
        private CrowdFunDbContext context_;
        private CrowdFun.Core.model.services.IProjectServices project_;
        public ProjectController(
           CrowdFunDbContext context,
           CrowdFun.Core.model.services.IProjectServices project)
        {
            context_ = context;
            project_ = project;
        }

        public async Task<IActionResult> Index()
        {
            var t = await context_
                .Set<Project>()
                .Take(100)
                .ToListAsync();

            return View(t);
        }

        public IActionResult List()
        {
            var ProjectList = context_
                .Set<Project>()
                .Select(c => new { c.Tittle, c.id,c.Photos})
                .Take(100)
                .ToListAsync();

            return Json(ProjectList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
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

        [HttpPost]
        public async Task<IActionResult> CreateProject(
           [FromBody]   CrowdFun.Core.model.options.AddProjects options)
        {
            var result = await project_.CreateProjectAsync(
                options);

            return result.AsStatusResult();
        }


    }
}
