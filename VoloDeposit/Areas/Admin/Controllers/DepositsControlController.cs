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

using VoloDeposit.ViewModel.Deposit;
using VoloDeposit.Areas.Admin.ViewModel;
using VoloDeposit.Mappings;

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
            List<DepositIndexViewModel> bankVM = _repository.SelectAll().To_Deposit_Index_ViewModel().ToList<DepositIndexViewModel>();
            return View(bankVM);
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
