using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrashCollection.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using Domain.Entities.TrashCollector;

    public class CustomerViewModel
    {
        [Display(Name = "Id")]
        [Editable(false)]
        public int? Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        [Display(Name = "Zip code")]
        [Required(ErrorMessage = "Required")]
        public int ZipCode { get; set; }

        [Display(Name = "Not Collect From")]
        public DateTime? NotCollectFrom { get; set; }

        [Display(Name = "Not Collect To")]
        public DateTime? NotCollectTo { get; set; }

        [DisplayFormat(DataFormatString = "{0:C0}", ApplyFormatInEditMode = true)]
        [Editable(false)]
        [Required(ErrorMessage = "Required")]
        public decimal Balance { get; set; }

        [Display(Name = "UserId")]
        [Editable(false)]
        public string UserId { get; set; }

        [Display(Name = "Week Days")]
        public IList<string> WeekDays { get; set; }

        public IList<SelectListItem> AvailableWeekDays { get; set; }

        public CustomerViewModel()
        {
            AvailableWeekDays = new List<SelectListItem>
                                    {
                                        new SelectListItem { Text = "Monday", Value = "Monday" },
                                        new SelectListItem { Text = "Tuesday", Value = "Tuesday" },
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
                                        new SelectListItem { Text = "Friday", Value = "Friday" },
                                        new SelectListItem
                                            {
                                                Text = "Saturday",
                                                Value = "Saturday"
                                            },
                                        new SelectListItem { Text = "Sunday", Value = "Sunday" }
                                    };
            WeekDays = new List<string>();
        }


        public Customer ToDomainObject()
        {
            return new Customer
                       {
                           Id = this.Id ?? -1,
                           FirstName = this.FirstName,
                           LastName = this.LastName,
                           Email = this.Email,
                           Address = this.Address,
                           City = this.City,
                           State = this.State,
                           ZipCode = this.ZipCode,
                           WeekDays = string.Join(",", this.WeekDays),
                           NotCollectFrom = this.NotCollectFrom,
                           NotCollectTo = this.NotCollectTo,
                           Balance = this.Balance,
                           UserId = this.UserId
                       };
        }
    }
}