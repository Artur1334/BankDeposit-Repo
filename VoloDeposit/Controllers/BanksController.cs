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

namespace VoloDeposit.Controllers
{
    public class BanksController : Controller
    {
        protected IGenericRepository<Bank> _repository;

        public BanksController(IGenericRepository<Bank> repository)
        {
            _repository = repository;

        }

        // GET: Admin/Banks
        public ActionResult Index()
        {
            List<BankViewModel> bankVM = _repository.SelectAll().Where(d => d.Deleted == false).To_BankViewModel().ToList<BankViewModel>();
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

        //// GET: Admin/Banks/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Admin/Banks/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "BankID,BankName,Deleted")] Bank bank)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _repo.Create(bank);
        //        _repo.Save();
        //        return RedirectToAction("Index");
        //    }

        //    return View();

        //}

        // GET: Admin/Banks/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    //if (id == null)
        //    //{
        //    //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    //}

        //    BankViewModel bankVM = _repo.Select<Bank>(id).To_BankViewModel();
        //    if (bankVM == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    return View(bankVM);
        //}

        // POST: Admin/Banks/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "BankID,BankName,Deleted")] Bank bank)
        //{
        //    try
        //    {
        //        _repo.Update(bank);
        //        _repo.Save();
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: Admin/Banks/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    //if (id == null)
        //    //{
        //    //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    //}
        //    BankViewModel bankVM = _repo.Select<Bank>(id).To_BankViewModel();
        //    if (bankVM == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(bankVM);
        //}

        // POST: Admin/Banks/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    try
        //    {
        //        // _repo.DeleteBankAndThrowToArchive(_repo.Select<Bank>(id));
        //        _repo.Delete(id);
        //        _repo.Save();
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

    }
}