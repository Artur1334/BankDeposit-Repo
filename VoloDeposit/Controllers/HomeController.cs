using CalculatorService;
using EntitiesServices.Entities;
using EntitiesServices.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VoloDeposit.ViewModel.Home;

namespace VoloDeposit.Controllers
{
 
    public class HomeController : Controller
    {  
        public HomeController(IGenericRepository<Bank> repo)
        {
            var calulator = CalculatorFactory.Get("Family");
            var total = calulator.Calculate(75.50m, 1);
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET
        public ActionResult Calculator(string depotype)
        {
            ViewBag.Depotype= depotype;
            //var calulator = CalculatorResolver.Get(type);
            //return PartialView(calulator);
            //CalculatorViewModels cc = new CalculatorViewModels();
            return View();

        }

        [HttpPost]
       
        public ActionResult Calculator([Bind(Include = "Year,Amount")]CalculatorViewModels CalculatotVM)
        {
            //var calulator = CalculatorResolver.Get(type);
            //return PartialView(calulator);
            //CalculatorViewModels cc = new CalculatorViewModels();
            return View();

        }
    }
}

