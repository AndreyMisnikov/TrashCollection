using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrashCollection.Models
{
    using System.ComponentModel.DataAnnotations;

    using Domain.Entities.TrashCollector;

    public class TrashCollectorViewModel
    {
        [Display(Name = "Id")]
        [Editable(false)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Week Days")]
        public string WeekDays { get; set; }

        [Display(Name = "Start time")]
        //[DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan StartTime { get; set; }

        [Display(Name = "Stop time")]
        //[DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan EndTime { get; set; }

        [Display(Name = "Zip codes")]
        public string ZipCodes { get; set; }

        [Display(Name = "Monthly Payment")]
        [Required(ErrorMessage = "Required")]
        public double MonthlyPayment { get; set; }

        [Display(Name = "UserId")]
        [Editable(false)]
        public string UserId { get; set; }

        public TrashCollector ToDomainObject()
        {
            return new TrashCollector
                       {
                           Id = this.Id,
                           StartTime = this.StartTime,
                           EndTime = this.EndTime,
                           WeekDays = this.WeekDays,
                           ZipCodes = this.ZipCodes,
                           MonthlyPayment = this.MonthlyPayment,
                           UserId = this.UserId
                       };
        }
    }
}