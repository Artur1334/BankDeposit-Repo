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
    public class DepositorsControlController : Controller
    {
        protected IGenericRepository<Person> _repository;
        public DepositorsControlController(GenericRepository<Person> repository)
        {
            this._repository = repository;
        }

        // GET: Admin/DepositorsControl
        public ActionResult Index()
        {
            return View(_repository.SelectAll());
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person =_repository.Select<Bank>(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: Admin/DepositorsControl/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonId,FirstName,LastName,BirthDay,Email,Phone,Pasport")] Person person)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.Update(person);
                    _repository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException )
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again.");
            }
            return View(person);
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
