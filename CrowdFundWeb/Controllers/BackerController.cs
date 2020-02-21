using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CrowdFun.Core.data;
using CrowdFun.Core.model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Autofac;
using CrowdFun.Core.data;
using CrowdFun.Core.model;
using CrowFun.Extensions;

namespace CrowFun.web.Controllers {
    public class BackerController:Controller
    {
        private CrowdFunDbContext context_;
        private CrowdFun.Core.model.services.IBackerService backer_;
        public BackerController(
           CrowdFunDbContext context,
           CrowdFun.Core.model.services.IBackerService backer)
        {
            context_ = context;
            backer_ = backer;
        }

        public async Task<IActionResult> Index()
        {
            var t = await context_
                .Set<Backers>()
                .Take(100)
                .ToListAsync();

            return View(t);
        }

        public IActionResult List()
        {
            var backerList = context_
                .Set<Backers>()
                .Select(c => new { c.FirstName, c.LastName,c.RewardsProject })
                .Take(100)
                .ToListAsync();

            return Json(backerList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(
                         CrowdFundWeb.Models.CreateBackerViewModel model)
        {
            var result = await backer_.AddBackerNewAsync(
                model?.AddOptions);

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
