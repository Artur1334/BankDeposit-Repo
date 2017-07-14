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
        private readonly IGenericRepository<Bank> _repo;
       
        public HomeController(IGenericRepository<Bank> repo)
        {
            _repo = repo;
            var calulator = CalculatorResolver.Get("Family");
            var total = calulator.Calculate(75.50m, 1);
        }
        public HomeController()
        {
            
        }
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult About(CreateBankViewModel ViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Bank bank = new Bank { BankID = ViewModel.BankId, BankName = ViewModel.BankName };
        //    }


        //        return View();
        //}

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        // GET
        public ActionResult Calculator(string type)
        {
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

