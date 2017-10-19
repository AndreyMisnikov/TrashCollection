using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrashCollection.Controllers
{
    using Domain.Services;


    using Microsoft.AspNet.Identity;

    using TrashCollection.Models;

    [Authorize]
    public class CustomerController : Controller
    {
        public ICustomerService Service { get; set; }

        // GET: TrashCollectror
        [HttpGet]
        public ActionResult CreateOrUpdate()
        {
            var customer = Service.GetInformationByUserId(User.Identity.GetUserId());

            if (customer != null)
            {
                ViewBag.Title = "Edit information";

                var customerViewModel =
                    new CustomerViewModel
                        {
                        Id = customer.Id,
                            FirstName = customer.FirstName,
                            LastName = customer.LastName,
                            Email = customer.Email,
                            Address = customer.Address,
                            City = customer.City,
                            State = customer.State,
                            ZipCode = customer.ZipCode,
                            WeekDays = customer.WeekDays?.Split(','),
                            NotCollectFrom = customer.NotCollectFrom,
                            NotCollectTo = customer.NotCollectTo,
                            Balance = customer.Balance,
                            UserId = customer.UserId
                    };
                ViewBag.Title = "Edit information";
                return this.View(customerViewModel);
            }

            ViewBag.Title = "Add information";
            return View(new CustomerViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrUpdate(CustomerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateOrUpdate", model);
            }

            model.UserId = User.Identity.GetUserId();

            Service.CreateOrUpdate(model.ToDomainObject());

            return RedirectToAction("Index", "Home");
        }
    }
}