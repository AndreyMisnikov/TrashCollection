using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollection.Models
{
    using System.ComponentModel.DataAnnotations;

    public enum CustomerStatusEnum
    {
        Unverified,
        Verified
    }

    public sealed class TrashCollectorStatus
    {
        public static readonly string Default = "Default";

        public static readonly string ToDo = "To Do";

        public static readonly string InProgress = "In Progress";

        public static readonly string Done = "Done";

        public static readonly string AlreadyBooked = "AlreadyBooked";
    }

    public class TrashCollectorManagementViewModel
    {
        public TrashCollectorManagementViewModel()
        {
            this.CollectorStatus = CustomerStatusEnum.Unverified.ToString();
        }

        [Display(Name = "Id")]
        [Editable(false)]
        public int? Id { get; set; }

        [Display(Name = "Id")]
        public int CustomerId { get; set; }

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

        [Display(Name = "Status by Customer")]
        public string CustomerStatus { get; set; }

        [Display(Name = "Status Modified Date by Customer")]
        public DateTime CustomerStatusModifiedDate { get; set; }

        [Display(Name = "Status by Collector")]
        public string CollectorStatus { get; set; }

        [Display(Name = "Status Modified Date by Collector")]
        public DateTime CollectorStatusModifiedDate { get; set; }
    }
}