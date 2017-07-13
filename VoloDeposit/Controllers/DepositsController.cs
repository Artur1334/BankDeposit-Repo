using DepositTypeServices;
using EntitiesServices.Entities;
using EntitiesServices.Services;
using InfrastructureData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VoloDeposit.Mappings;
using VoloDeposit.ViewModel.Deposit;

namespace VoloDeposit.Controllers
{
    public class DepositsController : Controller
    {

        protected IGenericRepository<Deposit> _repository;
        protected IGenericRepository<Bank> _repositorybank;
        protected IGenericRepository<Person> _repositoryPerson;
        ListDepositType _listdeposittype = new ListDepositType();
        public DepositsController(GenericRepository<Deposit> repository, GenericRepository<Bank> repositorybank, GenericRepository<Person> repositoryPerson)
        {
            this._repository = repository;
            this._repositorybank = repositorybank;
            this._repositoryPerson = repositoryPerson;
        }
        // GET: Deposits/Create
        public ActionResult Create()
        {
         
            ViewBag.BankID = new SelectList(_repositorybank.SelectAll().Where(d=>d.Deleted==false), "BankID", "BankName");
            ViewBag.DepositorID = new SelectList(_repositoryPerson.SelectAll(), "PersonId", "FirstName");
            ViewBag.DepositType = new  SelectList(_listdeposittype.GetAllTypes(), "TypeID", "TypeName");
           
            return View();
        }

        // POST: Deposits/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DepositID,BankID,DepositorID,DepositType,Amount,DepositDated,DepositYear")] DepositViewModel deposit)
        {
            if (ModelState.IsValid)
            { 
                Deposit _deposit = DepositMapper.To_Deposit_Create_ViewModel(deposit);
                _repository.Create(_deposit);
                _repository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.BankID = new SelectList(_repositorybank.SelectAll(), "BankID", "BankName", deposit.BankID);
            ViewBag.DepositorID = new SelectList(_repositoryPerson.SelectAll(), "PersonId", "FirstName", deposit.DepositorID);
            ViewBag.DepositType = new SelectList(_listdeposittype.GetAllTypes(), "TypeID", "TypeName",deposit.DepositType);
            return View(deposit);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repository.Dispose();
                _repository = null;
                _repositorybank.Dispose();
                _repositorybank = null;
                _repositoryPerson.Dispose();
                _repositoryPerson = null;
            }
            base.Dispose(disposing);
        }
    }
}
