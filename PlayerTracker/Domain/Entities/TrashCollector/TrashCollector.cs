using System;

namespace Domain.Entities.TrashCollector
{
    public class TrashCollector
    {
        public int Id { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public string WeekDays { get; set; }

        public string ZipCodes { get; set; }

        public decimal MonthlyPayment { get; set; }

        public string UserId { get; set; }
    }
}
