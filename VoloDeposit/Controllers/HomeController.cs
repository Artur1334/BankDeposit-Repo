using EntitiesServices.Entities;
using EntitiesServices.Services;
using InfrastructureData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VoloDeposit.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGenericRepository<Bank> _repo;
        public HomeController()
        {
            _repo = new GenericRepository<Bank>();
        }
        public ActionResult Index()
        {
            return View(_repo.SelectAll());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}