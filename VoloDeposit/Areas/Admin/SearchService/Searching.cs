using AutoMapper;
using EntitiesServices.Entities;
using EntitiesServices.Services;
using InfrastructureData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VoloDeposit.Areas.Admin.ViewModel;
using VoloDeposit.ViewModel.Deposit;

namespace VoloDeposit.Areas.Admin.SearchService
{
    public class Searching
    {

        //public List<SearchResultsViewModel> GetSearchResults(SearchViewModel searchVM)
        //{
        //    Mapper.Initialize(b => b.CreateMap<Deposit, DepositIndexViewModel>()

        //        .ForMember("BankName", d => d.MapFrom(n => n.Bank.BankName))
        //        .ForMember("FirstName", d => d.MapFrom(n => n.Person.FirstName))
        //    .ForMember("LastName", d => d.MapFrom(n => n.Person.LastName)));

        //    var deposits = Mapper.Map<IEnumerable<Deposit>, IEnumerable<DepositIndexViewModel>>(_repository.SelectAll()).AsQueryable();/*<Investment>()).AsQueryable()*/;

        //    List<SearchResultsViewModel> results = new List<SearchResultsViewModel>();
        //    if (searchVM != null)
        //    {
        //        if (string.IsNullOrEmpty(searchVM.BankName) && string.IsNullOrEmpty(searchVM.LastName) && string.IsNullOrEmpty(searchVM.FirstName) && string.IsNullOrEmpty(searchVM.DepositType) &&
        //                !searchVM.MinAmount.HasValue && !searchVM.MaxAmount.HasValue && !searchVM.MinStartDate.HasValue && !searchVM.MaxStartDate.HasValue)
        //        {
        //            return results;
        //        }


        //        if (!string.IsNullOrEmpty(searchVM.BankName))
        //            deposits = deposits.Where(x => x.BankName.Contains(searchVM.BankName));
        //        if (!string.IsNullOrEmpty(searchVM.LastName))
        //            deposits = deposits.Where(x => x.LastName.Contains(searchVM.LastName));
        //        if (!string.IsNullOrEmpty(searchVM.FirstName))
        //            deposits = deposits.Where(x => x.FirstName.Contains(searchVM.FirstName));
        //        if (!string.IsNullOrEmpty(searchVM.DepositType))
        //            deposits = deposits.Where(x => x.DepositType.Contains(searchVM.DepositType));
        //        if (searchVM.MinAmount.HasValue)
        //            deposits = deposits.Where(x => x.Amount >= searchVM.MinAmount);
        //        if (searchVM.MaxAmount.HasValue)
        //            deposits = deposits.Where(x => x.Amount <= searchVM.MaxAmount);
        //        if (searchVM.MinStartDate.HasValue)
        //            deposits = deposits.Where(x => x.StartDate >= searchVM.MinStartDate);
        //        if (searchVM.MaxStartDate.HasValue)
        //            deposits = deposits.Where(x => x.StartDate <= searchVM.MaxStartDate);

        //        foreach (var item in deposits)
        //        {
        //            var res = new SearchResultsViewModel()
        //            {
        //                FirstName = item.FirstName,
        //                LastName = item.LastName,
        //                BankName = item.BankName,
        //                DepositType = item.DepositType
        //            };

        //            results.Add(res);
        //        }
        //    }
        //    return results;
        //}

    }
}