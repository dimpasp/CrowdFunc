using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrowdFun.Core.data;
using CrowdFun.Core.model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrowFun.web.Controllers {
    public class CreatorControler:Controller
    {
        private CrowdFunDbContext context_;
        private CrowdFun.Core.model.services.ICreatorService creator_;
        public CreatorController(
           CrowdFunDbContext context,
           CrowdFun.Core.model.services.CreatorServices creator)
        {
            context_ = context;
            creator_ = creator;
        }

        public async Task<IActionResult> Index()
        {
            var t = await context_
                .Set<Creator>()
                .Take(100)
                .ToListAsync();

            return View(t);
        }

        public IActionResult List()
        {
            var backerList = context_
                .Set<Creator>()
                .Select(c => new { c.LastName, c.Project_, c.Rewards_ })
                .Take(100)
                .ToListAsync();

            return Json(CreatorList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(
                         CrowdFundWeb.Models.CreateCreatorViewModel model)
        {
            var result = await creator_.(
                model?.);

            if (result == null) {
                model.ErrorText = " Something went wrong";

                return View(model);
            }

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBacker(
           [FromBody]   CrowdFun.Core.model.options.AddNewBackerOptions options)
        {
            var result = await backer_.AddBackerNewAsync(
                options);

            return result.AsStatusResult();
        }


    }
}
