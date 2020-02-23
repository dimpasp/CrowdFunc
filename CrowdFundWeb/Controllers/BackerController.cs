using CrowdFun.Core.data;
using CrowdFun.Core.model.services;
using Microsoft.AspNetCore.Mvc;

namespace CrowFun.web.Controllers
{
    public class BackerController : Controller
    {
        private IBackerService backer_;
        public BackerController(CrowdFunDbContext context)
        {

            backer_ = new BackerServices(context);
        }

        [HttpGet]
        public object Index()
        {
            return backer_.SearchBackerId(1);
        }
    }
}
    //public IActionResult AddBacker()
    //{
    //    return View();
    //}
    //public IActionResult UpdateBacker()
    //{
    //    return View();
    //}
    //public IActionResult SearchBacker()
    //{
    //    return View();
    //}
