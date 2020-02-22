using System.Linq;
using System.Threading.Tasks;
using CrowdFun.Core.data;
using CrowdFun.Core.model;
using CrowdFun.Core.model.services;
using CrowFun.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrowFun.web.Controllers {
    public class BackerController:Controller
    {
       // private CrowdFunDbContext context_;
        private IBackerService backer_;

        public BackerController(CrowdFunDbContext context)
        {
            // context_ = context;
            backer_ = new BackerServices(context);
        }

        [HttpGet]
        public object Index()
        {
            return backer_.SearchBackerId(1);
        }

        //public IActionResult List()
        //{
        //    var backerList = context_
        //        .Set<Backer>()
        //        .Select(c => new { c.FirstName, c.LastName,c.RewardsProject })
        //        .Take(100)
        //        .ToListAsync();

        //    return Json(backerList);
        //}

        //[HttpGet]
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Create(
        //                 CrowdFundWeb.Models.CreateBackerViewModel model)
        //{
        //    var result = await backer_.AddBackerNewAsync(
        //        model?.AddOptions);

        //    if (result == null) {
        //        model.ErrorText = " Something went wrong";

        //        return View(model);
        //    }

        //    return Ok();
        //}

        //[HttpPost]
        //public async Task<IActionResult> CreateBacker(
        //   [FromBody]   CrowdFun.Core.model.options.AddNewBackerOptions options)
        //{
        //    var result = await backer_.AddBackerNewAsync(
        //        options);

        //    return result.AsStatusResult();
       // }

    }
}
