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
using VoloDeposit.ViewModel.Depositors;
using VoloDeposit.Mappings;

namespace VoloDeposit.Controllers
{
    public class DepositorsController : Controller
    {
        private ArmDepositEntities db = new ArmDepositEntities();
        protected IGenericRepository<Person> _repository;
        protected IPasportSelect _pasportSelect;

        public DepositorsController(GenericRepository<Person> repository, IPasportSelect pasportSelect)
        {
            this._repository = repository;
            this._pasportSelect = pasportSelect;
        }
       // GET: Depositors/PasportCheck
        public ActionResult PasportCheck()
        {
            
            return View("PasportCheckView");
        }
       // POST: Depositors/PasportCheck
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PasportCheck([Bind(Include = "Pasport")] Depositor_Pasport_ViewModel item)
        {
            if (ModelState.IsValid)
            {
                Person TempPerson = _pasportSelect.SelectPasport(item.Pasport);
                if (TempPerson == null)
                {
                    
                    return RedirectToAction("Create",item);

                }

                return RedirectToAction("Index", "Home"); //depositi  create a uxarkum
            }
            
           
            return View("PasportCheckView",item);
        }

        // GET: Depositors/Create
        public ActionResult Create(Depositor_Pasport_ViewModel item)
        {
            ViewBag.pasp = item.Pasport;
            return View();
        }

        // POST: Depositors/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonId,FirstName,LastName,BirthDay,Email,Phone,Pasport")] Person person)
        {
            Depositor_Create_ViewModel kkk= DepositorMapper.To_Depositor_CreateEdit_ViewModel(person);

            //    try
            //    {
            //    _repository.Create();
            //    _repository.Save();
            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}



            //    if (ModelState.IsValid)
            //    {
            //        _repository.Create(person);
            //        _repository.Save();
            //        return RedirectToAction("Index");
            //    }

            return View(person);
        }

       

        protected override void Dispose(bool disposing)
        {
            if (_repository != null)
            {
                _pasportSelect.Dispose();
                _repository.Dispose();
                _pasportSelect = null;
                _repository = null;
            }

            base.Dispose(disposing);
        }
    }
}
