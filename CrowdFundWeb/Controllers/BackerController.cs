using System;
using System.Threading.Tasks;
using CrowdFun.Core.data;
using CrowdFun.Core.model;
using CrowdFun.Core.model.options;
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
        public IActionResult Index()
        {
            //oso den uparxei authority tha emfanizetai o bakcer me id=1
            var backer =  backer_.SearchBackerId(1);

            return View(backer);
        }

        [HttpGet("backer/addBacker")]
        public IActionResult AddBacker()
        {
            return View();
        }

        [HttpGet("backer/add")]
        public async Task<object> AddBacker(string firstname, string lastname, string email, string phone, string password, decimal donate)
        {
            var result = await backer_.AddBackerNewAsync(new AddNewBackerOptions { 
                Donate = donate,
                Email = email,
                FirstName = firstname,
                LastName = lastname,
                Password = password
            });

            return result.Success;
        }

        [HttpGet("backer/updateBacker")]
        public IActionResult UpdateBackerView()
        {
            var backer = backer_.SearchBackerId(1);
            return View("UpdateBacker", backer);
        }

        [HttpGet("backer/update")]
        public bool Update(string id, string firstname, string lastname, string email, string phone, string password, decimal donate)
        {

            var result =  backer_.UpdateBacker(new UpdateBacker
            {
                Id = Convert.ToInt32(id),
                NewDonate = donate,
                Email = email,
                FirstName = firstname,
                LastName = lastname,
                Password = password,
                Phone = phone
            });

            return result;
        }
    }
}
    
