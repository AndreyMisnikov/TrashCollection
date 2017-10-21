using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Domain.Entities;

    [Table("TrashCollection")]
    public class TrashCollectionEntity : IEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int CollectorId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual CustomerEntity Customer { get; set; }

        [ForeignKey("CollectorId")]
        public virtual TrashCollectorEntity Collector { get; set; }

        [StringLength(100)]
        public string CustomerStatus { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CustomerStatusModifiedDate { get; set; }

        [StringLength(100)]
        public string CollectorStatus { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CollectorStatusModifiedDate { get; set; }

        public bool IsApproved { get; set; }

        public TrashCollection ToDomainObject()
        {
            return new TrashCollection
            {
                Id = this.Id,
                CustomerId = this.CustomerId,
                CollectorId = this.CollectorId,
                CustomerStatus = this.CustomerStatus,
                CustomerStatusModifiedDate = this.CustomerStatusModifiedDate,
                CollectorStatus = this.CollectorStatus,
                CollectorStatusModifiedDate = this.CollectorStatusModifiedDate,
                IsApproved = this.IsApproved
            };
        }
    }
}
