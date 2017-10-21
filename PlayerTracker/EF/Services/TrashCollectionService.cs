using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Services
{
    using System.Data.Entity;

    using Domain.Entities;
    using Domain.Services;

    using EF.Models;

    public class TrashCollectionService : ITrashCollectionService
    {
        /// <summary>
        /// The Custom script repository.
        /// </summary>
        private readonly IGenericRepository<TrashCollectionEntity> repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TrashCollectionService"/> class.
        /// </summary>
        /// <param name="repository">
        /// The repository.
        /// </param>
        public TrashCollectionService(IGenericRepository<TrashCollectionEntity> repository)
        {
            this.repository = repository;
        }


        public void CreateOrUpdate(TrashCollection trashCollection)
        {
            //TODO: ADD AUTOMAPPER AND COPY OBJECT
            TrashCollectionEntity existedTrashCollection = this.repository.FindByKey(trashCollection.Id);
            if (existedTrashCollection != null)
            {
                existedTrashCollection.CustomerId = trashCollection.CustomerId;
                existedTrashCollection.CollectorId = trashCollection.CollectorId;
                existedTrashCollection.CustomerStatus = trashCollection.CustomerStatus;
                existedTrashCollection.CustomerStatusModifiedDate = trashCollection.CustomerStatusModifiedDate;
                existedTrashCollection.CollectorStatus = trashCollection.CollectorStatus;
                existedTrashCollection.CollectorStatusModifiedDate = trashCollection.CollectorStatusModifiedDate;
                this.repository.Update(existedTrashCollection);
                return;
            }

            var updateTrashCollection =
                new TrashCollectionEntity
                    {
                        Id = trashCollection.Id,
                        CustomerId = trashCollection.CustomerId,
                        CollectorId = trashCollection.CollectorId,
                        CustomerStatus = trashCollection.CustomerStatus,
                        CustomerStatusModifiedDate = trashCollection.CustomerStatusModifiedDate,
                        CollectorStatus = trashCollection.CollectorStatus,
                        CollectorStatusModifiedDate = trashCollection.CollectorStatusModifiedDate
                    };

            this.repository.Insert(updateTrashCollection);
        }

        public IEnumerable<TrashCollection> GetInformationByCustomerId(int customerId)
        {
            var trashCollectionEntities = this.repository.FindBy(item => item.CustomerId == customerId).Select(item => item.ToDomainObject());
            return trashCollectionEntities;
        }

        public IEnumerable<TrashCollection> GetInformationByCollectorId(int collectorId)
        {
            var trashCollectionEntities = this.repository.FindBy(item => item.CollectorId == collectorId).Select(item => item.ToDomainObject());
            return trashCollectionEntities;
        }

        public IEnumerable<TrashCollection> GetInformation(List<int> customerIds)
        {
            IEnumerable<TrashCollection> trashCollections = this.repository.FindBy(item => DbFunctions.TruncateTime(item.CollectorStatusModifiedDate) == DbFunctions.TruncateTime(DateTime.Today) && customerIds.Contains(item.CustomerId)).Select(item => item.ToDomainObject());
            return trashCollections;
        }

       /* public void ChangeStatus(int collectorId, int customerId, string status)
        {
            this.repository.Insert(new TrashCollectionEntity() {} );
        }*/
    }
}
