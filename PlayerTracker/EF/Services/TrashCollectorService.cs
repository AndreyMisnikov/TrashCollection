using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Services
{
    using Domain.Entities;

    public class TrashCollectorService : ITrashCollectorService
    {
        /// <summary>
        /// The Trash Collector repository.
        /// </summary>
        private readonly IGenericRepository<TrashCollectorEntity> repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TrashCollectorService"/> class.
        /// </summary>
        /// <param name="repository">
        /// The repository.
        /// </param>
        public TrashCollectorService(IGenericRepository<TrashCollectorEntity> repository)
        {
            this.repository = repository;
        }


        public void CreateOrUpdate(TrashCollector trashCollector)
        {
            //TODO: ADD AUTOMAPPER AND COPY OBJECT
            TrashCollectorEntity existedTrashCollector = this.repository.FindByKey(trashCollector.Id);
            if (existedTrashCollector != null)
            {
                existedTrashCollector.StartTimeSpan = trashCollector.StartTime;
                existedTrashCollector.EndTimeSpan = trashCollector.EndTime;
                existedTrashCollector.WeekDays = trashCollector.WeekDays;
                existedTrashCollector.ZipCodes = trashCollector.ZipCodes;
                existedTrashCollector.MonthlyPayment = trashCollector.MonthlyPayment;
                existedTrashCollector.UserId = trashCollector.UserId;
                this.repository.Update(existedTrashCollector);
                return;
            }

            var updateTrashCollector =
                new TrashCollectorEntity
                    {
                        Id = trashCollector.Id,
                        StartTimeSpan = trashCollector.StartTime,
                        EndTimeSpan = trashCollector.EndTime,
                        WeekDays = trashCollector.WeekDays,
                        ZipCodes = trashCollector.ZipCodes,
                        MonthlyPayment = trashCollector.MonthlyPayment,
                        UserId = trashCollector.UserId
                    };

            this.repository.Insert(updateTrashCollector);
        }

        public TrashCollector GetInformationByUserId(string userId)
        {
            var trashCollectorEntity = this.repository.FindBy(item => item.UserId == userId).LastOrDefault();
            if (trashCollectorEntity == null)
            {
                return null;
            }

            return trashCollectorEntity.ToDomainObject();
        }
    }
}
