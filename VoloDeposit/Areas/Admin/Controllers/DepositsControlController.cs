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
        public ActionResult Search()
        {
            return View();
        }

        // POST: Admin/BanksControl/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search([Bind(Include = " FirstName,LastName,BankName,DepositType, MinAmount,MaxAmount, MinStartDate,MaxStartDate")] SearchViewModel Search)
        {

            if (ModelState.IsValid)
            {
               
                return View();
            }

            return View();
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
        //public ActionResult Seaffrch()
        //{
        //    //string _tempID = User.Identity.GetUserId();
        //    var _deposits = db.Deposits.Include(d => d.Bank).Include(d => d.DepositorInfo).Where(d => d.DepositorInfo.DepositorFirstName == "Artur");

        //    Mapper.CreateMap<Deposit, SearchViewModel>()
        //        .ForMember(cv => cv.DepositType, m => m.ResolveUsing<DepositTypeResolver>().FromMember(x => x.DepositType));

        //    var _depositCollection = Mapper.Map<List<Deposit>, List<DepositsListViewModel>>(_deposits.ToList());


        //    return View();
        //}
    }
}
