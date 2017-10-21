using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrashCollection.Controllers
{
    using System.Collections;
    using System.Web.Mvc;

    using Domain.Entities;
    using Domain.Services;

    using EF.Services;

    using Microsoft.AspNet.Identity;

    using TrashCollection.Models;

    [Authorize]
    public class ManageTrashController : Controller
    {
        public ITrashCollectionService TrashCollectionService { get; set; }

        public ICustomerService CustomerService { get; set; }

        public ITrashCollectorService TrashCollectorService { get; set; }

        // GET: TrashCollectror
        [HttpGet]
        public ActionResult Collector()
        {
            string userId = User.Identity.GetUserId();
            var collector = this.TrashCollectorService.GetInformationByUserId(userId);
            IEnumerable<Customer> customers = this.CustomerService.GetCustomersByCollector(collector);
            var trashCollectorManagementViewModels = new List<TrashCollectorManagementViewModel>();
            if (customers != null && customers.Any())
            {
                var usersLogs = TrashCollectionService.GetInformation(customers.Select(item => item.Id).ToList());
                foreach (var customer in customers)
                {
                    var trashCollectorManagementViewModel = new TrashCollectorManagementViewModel();
                    trashCollectorManagementViewModel.ZipCode = customer.ZipCode;
                    trashCollectorManagementViewModel.Address = customer.Address;
                    trashCollectorManagementViewModel.City = customer.City;
                    trashCollectorManagementViewModel.Email = customer.Email;
                    trashCollectorManagementViewModel.FirstName = customer.FirstName;
                    trashCollectorManagementViewModel.LastName = customer.LastName;
                    trashCollectorManagementViewModel.City = customer.City;
                    trashCollectorManagementViewModel.State = customer.State;
                    
                    var userLog = usersLogs.LastOrDefault(log => log.CustomerId == customer.Id);
                    trashCollectorManagementViewModel.CustomerStatus = userLog == null ? TrashCollectorStatus.Default : userLog.CustomerStatus;
                    trashCollectorManagementViewModel.CollectorStatus = userLog == null ? TrashCollectorStatus.Default : userLog.CollectorStatus;
                    trashCollectorManagementViewModel.CollectorStatusModifiedDate =
                        userLog == null ? DateTime.MinValue : userLog.CollectorStatusModifiedDate;
                    trashCollectorManagementViewModel.CustomerStatusModifiedDate = userLog == null ? DateTime.MinValue : userLog.CustomerStatusModifiedDate;

                    trashCollectorManagementViewModels.Add(trashCollectorManagementViewModel);
                }

                return this.View(trashCollectorManagementViewModels);
            }

            return View(trashCollectorManagementViewModels);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult CollectorTT()
        //{
            
        //}

    }
}