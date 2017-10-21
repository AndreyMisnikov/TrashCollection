using System;

namespace EF.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Domain.Entities;

    [Table("Customer")]
    public class CustomerEntity : IEntity
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [Key]
        [Required]
        public int Id { get; set; }

        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(100)]
        public string City { get; set; }

        [StringLength(100)]
        public string State { get; set; }

        public int ZipCode { get; set; }

        [StringLength(100)]
        public string WeekDays { get; set; }

        public DateTime? NotCollectFrom { get; set; }

        public DateTime? NotCollectTo { get; set; }

        public decimal Balance { get; set; }


        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }


        public Customer ToDomainObject()
        {
            return new Customer
            {
                Id = this.Id,
                FirstName = this.FirstName,
                LastName = this.LastName,
                Email = this.Email,
                Address = this.Address,
                City = this.City,
                State = this.State,
                ZipCode = this.ZipCode,
                WeekDays = this.WeekDays,
                NotCollectFrom = this.NotCollectFrom,
                NotCollectTo = this.NotCollectTo,
                Balance = this.Balance,
                UserId = this.UserId
            };
        }
    }
}
