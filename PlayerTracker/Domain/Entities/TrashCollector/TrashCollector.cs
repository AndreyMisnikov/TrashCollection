using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.TrashCollector
{

    public class TrashCollector
    {
        public int Id { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public string WeekDays { get; set; }

        public string ZipCodes { get; set; }

        public double MonthlyPayment { get; set; }

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
                           MonthlyPayment = this.MonthlyPayment
                       };
        }
    }
}
