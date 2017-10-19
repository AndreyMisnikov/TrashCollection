using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrashCollection.Controllers
{
    using EF.Services;

    using Microsoft.AspNet.Identity;

    using TrashCollection.Models;

    [Authorize]
    public class TrashCollectorController : Controller
    {
        /// <summary>
        /// The service.
        /// </summary>
        public ITrashCollectorService Service { get; set; }

        // GET: TrashCollectror
        [HttpGet]
        public ActionResult CreateOrUpdate()
        {
            var trashCollector = Service.GetInformationByUserId(User.Identity.GetUserId());

            if (trashCollector != null)
            {
                ViewBag.Title = "Edit information";

                var trashCollectorViewModel =
                    new TrashCollectorViewModel
                        {
                            Id = trashCollector.Id,
                            StartTime = trashCollector.StartTime,
                            EndTime = trashCollector.EndTime,
                            WeekDays = trashCollector.WeekDays,
                            ZipCodes = trashCollector.ZipCodes,
                            MonthlyPayment = trashCollector.MonthlyPayment,
                            UserId = trashCollector.UserId
                        };
                ViewBag.Title = "Edit information";
                return this.View(trashCollectorViewModel);
            }

            ViewBag.Title = "Add information";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrUpdate(TrashCollectorViewModel model)
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