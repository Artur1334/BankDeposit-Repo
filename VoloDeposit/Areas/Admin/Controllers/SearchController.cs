﻿using AutoMapper;
using EntitiesServices.Entities;
using EntitiesServices.Services;
using InfrastructureData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VoloDeposit.Areas.Admin.SearchService;
using VoloDeposit.Areas.Admin.ViewModel;
using VoloDeposit.ViewModel.Deposit;

namespace VoloDeposit.Areas.Admin.Controllers
{
    public class SearchController : Controller
    {
        protected IGenericRepository<Deposit> _repository;
        protected IGenericRepository<Bank> _repositorybank = new GenericRepository<Bank>();
        protected IGenericRepository<Person> _repositoryPerson = new GenericRepository<Person>();
        public SearchController(GenericRepository<Deposit> repository)
        {
            _repository = repository;
        }
        // GET: Admin/Search
        public ActionResult Search()
        {

            SearchViewModel ss = new SearchViewModel();
            ViewBag.Banks= new SelectList(_repositorybank.SelectAll().Where(d => d.Deleted == false), "BankID", "BankName");
            ViewBag.DepositorFirstName = new SelectList(_repositoryPerson.SelectAll(), "PersonId", "FirstName");
            ViewBag.LastName = new SelectList(_repositoryPerson.SelectAll(), "PersonId", "LastName");
            ViewBag.LastName = new SelectList(_repositoryPerson.SelectAll(), "PersonId", "LastName");
            ViewBag.Type = new SelectList(_repository.SelectAll(), "DepositId", "DepositType");
            return View(ss);
        }

        // POST: Admin/BanksControl/Create

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult SearchResults(/*[Bind(Include = " FirstName,LastName,BankName,DepositType, MinAmount,MaxAmount, MinStartDate,MaxStartDate")]*/ SearchViewModel SearchVM)
        {

            var Results = GetSearchResults(SearchVM);

            return PartialView(Results);

           
        }


        public List<SearchResultsViewModel> GetSearchResults(SearchViewModel searchVM)
        {
            Mapper.Initialize(b => b.CreateMap<Deposit, DepositIndexViewModel>()
           
                .ForMember("BankName", d => d.MapFrom(n => n.Bank.BankName))
                .ForMember("FirstName", d => d.MapFrom(n => n.Person.FirstName))
            .ForMember("LastName", d => d.MapFrom(n => n.Person.LastName)));

            var deposits = Mapper.Map<IEnumerable<Deposit>, IEnumerable<DepositIndexViewModel>>(_repository.SelectAll()).AsQueryable();/*<Investment>()).AsQueryable()*/;

            List<SearchResultsViewModel> results = new List<SearchResultsViewModel>();
            if (searchVM != null)
            {
                if (string.IsNullOrEmpty(searchVM.BankName) && string.IsNullOrEmpty(searchVM.LastName) && string.IsNullOrEmpty(searchVM.FirstName) && string.IsNullOrEmpty(searchVM.DepositType) &&
                        !searchVM.MinAmount.HasValue && !searchVM.MaxAmount.HasValue && !searchVM.MinStartDate.HasValue && !searchVM.MaxStartDate.HasValue)
                {
                    return results;
                }


                if (!string.IsNullOrEmpty(searchVM.BankName))
                    deposits = deposits.Where(x => x.BankName.Contains(searchVM.BankName));
                if (!string.IsNullOrEmpty(searchVM.LastName))
                    deposits = deposits.Where(x => x.LastName.Contains(searchVM.LastName));
                if (!string.IsNullOrEmpty(searchVM.FirstName))
                    deposits = deposits.Where(x => x.FirstName.Contains(searchVM.FirstName));
                if (!string.IsNullOrEmpty(searchVM.DepositType))
                    deposits = deposits.Where(x => x.DepositType.Contains(searchVM.DepositType));
                if (searchVM.MinAmount.HasValue)
                    deposits = deposits.Where(x => x.Amount >= searchVM.MinAmount);
                if (searchVM.MaxAmount.HasValue)
                    deposits = deposits.Where(x => x.Amount <= searchVM.MaxAmount);
                if (searchVM.MinStartDate.HasValue)
                    deposits = deposits.Where(x => x.StartDate >= searchVM.MinStartDate);
                if (searchVM.MaxStartDate.HasValue)
                    deposits = deposits.Where(x => x.StartDate <= searchVM.MaxStartDate);

                foreach (var item in deposits)
                {
                    var res = new SearchResultsViewModel()
                    {
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        BankName = item.BankName,
                        DepositType = item.DepositType
                    };

                    results.Add(res);
                }
            }
            return results;
        }




    }
}