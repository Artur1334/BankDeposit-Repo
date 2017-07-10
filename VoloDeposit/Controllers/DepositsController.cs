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
        private ArmDepositEntities db = new ArmDepositEntities();

        protected IGenericRepository<Deposit> _repository;
        protected IGenericRepository<Bank> _repositorybank;
        protected IGenericRepository<Person> _repositoryPerson; 
        public DepositsController(GenericRepository<Deposit> repository, GenericRepository<Bank> repositorybank, GenericRepository<Person> repositoryPerson)
        {
            this._repository = repository;
            this._repositorybank = repositorybank;
            this._repositoryPerson = repositoryPerson;
        }
        // GET: Deposits/Create
        public ActionResult Create()
        {
            ViewBag.BankID = new SelectList(_repositorybank.SelectAll(), "BankID", "BankName");
            ViewBag.DepositorID = new SelectList(_repositoryPerson.SelectAll(), "PersonId", "FirstName");
            return View();
        }

        // POST: Deposits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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

                //db.Deposits.Add(deposit);
                //db.SaveChanges();

            }

            ViewBag.BankID = new SelectList(_repositorybank.SelectAll(), "BankID", "BankName", deposit.BankID);
            ViewBag.DepositorID = new SelectList(_repositoryPerson.SelectAll(), "PersonId", "FirstName", deposit.DepositorID);
            return View(deposit);
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

       // GET: Deposits
        public ActionResult Index()
        {
            var deposits = db.Deposits.Include(d => d.Bank).Include(d => d.Person);
            return View(deposits.ToList());
        }

        // GET: Deposits/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Deposit deposit = db.Deposits.Find(id);
        //    if (deposit == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(deposit);
        //}



        // GET: Deposits/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Deposit deposit = db.Deposits.Find(id);
        //    if (deposit == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.BankID = new SelectList(db.Banks, "BankID", "BankName", deposit.BankID);
        //    ViewBag.DepositorID = new SelectList(db.People, "PersonId", "FirstName", deposit.DepositorID);
        //    return View(deposit);
        //}

        // POST: Deposits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "DepositID,BankID,DepositorID,DepositType,Amount,DepositDated,DepositYear")] Deposit deposit)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(deposit).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.BankID = new SelectList(db.Banks, "BankID", "BankName", deposit.BankID);
        //    ViewBag.DepositorID = new SelectList(db.People, "PersonId", "FirstName", deposit.DepositorID);
        //    return View(deposit);
        //}

        // GET: Deposits/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Deposit deposit = db.Deposits.Find(id);
        //    if (deposit == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(deposit);
        //}

        //// POST: Deposits/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Deposit deposit = db.Deposits.Find(id);
        //    db.Deposits.Remove(deposit);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}


    }
}
