using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrowdFun.Core.data;
using CrowdFun.Core.model;
using CrowFun.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrowFun.web.Controllers {
    public class CreatorControler:Controller
    {
        private CrowdFunDbContext context_;
        private CrowdFun.Core.model.services.ICreatorService creator_;
        public CreatorControler(
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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(
                         CrowdFundWeb.Models.CreateCreatorViewModel model)
        {
            var result = await creator_.CreateNewCreatorAsync(
                model?.Create);

            if (result == null) {
                model.ErrorText = " Something went wrong";

                return View(model);
            }

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCreator(
           [FromBody]   CrowdFun.Core.model.options.AddNewCreatorOptions options)
        {
            var result = await creator_.CreateNewCreatorAsync(
                options);

            return result.AsStatusResult();
        }


    }
}
