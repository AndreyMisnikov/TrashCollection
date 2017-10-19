namespace EF
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Domain.Entities.TrashCollector;

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


        [Obsolete("Property 'Duration' should be used instead.")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long StartTime { get; set; }

        [NotMapped]
        public TimeSpan StartTimeSpan
        {
            get
            {
                return new TimeSpan(StartTime);
            }
            set
            {
                StartTime = value.Ticks;
            }
        }

        [Obsolete("Property 'Duration' should be used instead.")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long EndTime { get; set; }

        [NotMapped]
        public TimeSpan EndTimeSpan
        {
            get
            {
                return new TimeSpan(EndTime);
            }
            set
            {
                EndTime = value.Ticks;
            }
        }

        public double MonthlyPayment { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public TrashCollector ToDomainObject()
        {
            return new TrashCollector
                       {
                           Id = this.Id,
                           StartTime = this.StartTimeSpan,
                           EndTime = this.EndTimeSpan,
                           WeekDays = this.WeekDays,
                           ZipCodes = this.ZipCodes,
                           MonthlyPayment = this.MonthlyPayment,
                           UserId = this.UserId
                       };
        }
    }
}
