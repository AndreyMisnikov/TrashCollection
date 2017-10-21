using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrashCollection.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using Domain.Entities;

    public class TrashCollectorViewModel
    {
        [Display(Name = "Id")]
        [Editable(false)]
        public int? Id { get; set; }

        [Display(Name = "Start time")]
        //[DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan StartTime { get; set; }

        [Display(Name = "Stop time")]
        //[DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan EndTime { get; set; }

        [Display(Name = "Zip codes")]
        [Required(ErrorMessage = "Zip code Required")]
        public string ZipCodes { get; set; }

        [Display(Name = "Monthly Payment")]
        [DisplayFormat(DataFormatString = "{0:C0}", ApplyFormatInEditMode = true)]
        [Editable(false)]
        [Required(ErrorMessage = "Required")]
        public decimal MonthlyPayment { get; set; }

        [Display(Name = "UserId")]
        [Editable(false)]
        public string UserId { get; set; }

        [Display(Name = "Week Days")]
        public IList<string> WeekDays { get; set; }

        public IList<SelectListItem> AvailableWeekDays { get; set; }

        public TrashCollectorViewModel()
        {
            AvailableWeekDays = new List<SelectListItem>
                                    {
                                        new SelectListItem
                                            {
                                                Text = "Monday",
                                                Value = "Monday"
                                            },
                                        new SelectListItem
                                            {
                                                Text = "Tuesday",
                                                Value = "Tuesday"
                                            },
                                        new SelectListItem
                                            {
                                                Text = "Wednesday",
                                                Value = "Wednesday"
                                            },
                                        new SelectListItem
                                            {
                                                Text = "Thursday",
                                                Value = "Thursday"
                                            },
                                        new SelectListItem
                                            {
                                                Text = "Friday",
                                                Value = "Friday"
                                            },
                                        new SelectListItem
                                            {
                                                Text = "Saturday",
                                                Value = "Saturday"
                                            },
                                        new SelectListItem
                                            {
                                                Text = "Sunday",
                                                Value = "Sunday"
                                            }
                                    };
            WeekDays = new List<string>();
        }


        public TrashCollector ToDomainObject()
        {
            return new TrashCollector
                       {
                           Id = this.Id?? -1,
                           StartTime = this.StartTime,
                           EndTime = this.EndTime,
                           WeekDays = string.Join(",", this.WeekDays),
                           ZipCodes = this.ZipCodes,
                           MonthlyPayment = this.MonthlyPayment,
                           UserId = this.UserId
                       };
        }
    }
}