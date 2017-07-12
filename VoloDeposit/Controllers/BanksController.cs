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
using VoloDeposit.ViewModel;
using VoloDeposit.Mappings;
using InfrastructureData;

namespace VoloDeposit.Controllers
{
    public class BanksController : Controller
    {
        protected IGenericRepository<Bank> _repository;

        public BanksController(GenericRepository<Bank> repository)
        {
            _repository = repository;

        }

        // GET: Admin/Banks
        public ActionResult Index()
        {
         
            List<BankViewModel> bankVM = _repository.SelectAll().Where(d => d.Deleted ==false).To_BankViewModel().ToList<BankViewModel>();  //BankModel to BankViewModel list
            return View(bankVM);
        }
        protected override void Dispose(bool disposing)
        {
            if (_repository != null)
            {
                _repository.Dispose();
                _repository = null;
            }

            base.Dispose(disposing);
        }
    }
}