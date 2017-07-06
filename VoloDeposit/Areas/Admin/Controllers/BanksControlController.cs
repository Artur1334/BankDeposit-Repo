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
    public class BanksControlController : Controller
    {
        protected IGenericRepository<Bank> _repository;
       
        public BanksControlController(GenericRepository<Bank> repository)
        {
            this._repository = repository;
        }

        // GET: Admin/BanksControl
        public ActionResult Index()
        {
            return View(_repository.SelectAll());
        }

        // GET: Admin/BanksControl/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/BanksControl/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BankID,BankName,Deleted")] Bank bank)
        {
            if (ModelState.IsValid)
            {
                _repository.Create(bank);
                _repository.Save();
                return RedirectToAction("Index");
            }

            return View(bank);
        }

        // GET: Admin/BanksControl/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bank bank = _repository.Select<Bank>(id);
            if (bank == null)
            {
                return HttpNotFound();
            }
            return View(bank);
        }

        // POST: Admin/BanksControl/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BankID,BankName,Deleted")] Bank bank)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.Update(bank);
                    _repository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again.");
            }
            return View(bank);

        }

        // GET: Admin/BanksControl/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bank bank = _repository.Select<Bank>(id);
            if (bank == null)
            {
                return HttpNotFound();
            }
            return View(bank);
        }

        // POST: Admin/BanksControl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bank bank = _repository.Select<Bank>(id);
            bank.Deleted = true;
            _repository.Update(bank);
            _repository.Save();
            return RedirectToAction("Index");
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

