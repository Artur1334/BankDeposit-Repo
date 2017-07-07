using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EntitiesServices.Entities;
using EntitiesServices.Services;
using InfrastructureData;

namespace VoloDeposit.Areas.Admin.Controllers
{
    public class DepositsControlController : Controller
    {
        protected IGenericRepository<Deposit> _repository;
        public DepositsControlController(GenericRepository<Deposit> repository)
        {
            this._repository = repository;
        }

        // GET: Admin/DepositsControl
        public ActionResult Index()
        {
            return View(_repository.SelectAll());

        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repository.Dispose();
                _repository = null;
            }
            base.Dispose(disposing);
        }
    }
}
