namespace EF
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using EF.Models;

    /// <summary>
    /// The custom script entity.
    /// </summary>
    [Table("TrashCollector")]
    public class TrashCollectorEntity: IEntity
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [Key]
        [Required]
        public int Id { get; set; }

        [StringLength(100)]
        public string WeekDays { get; set; }

        [Required]
        [StringLength(100)]
        public string ZipCodes { get; set; }

        [Column(TypeName = "time")]
        public TimeSpan StartTime { get; set; }

        [Column(TypeName = "time")]
        public TimeSpan EndTime { get; set; }

        public double MonthlyPayment { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
