using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    using Domain.Entities;

    public interface ITrashCollectionService
    {
        void CreateOrUpdate(TrashCollection trashCollector);

        IEnumerable<TrashCollection> GetInformationByCustomerId(int customerId);

        IEnumerable<TrashCollection> GetInformationByCollectorId(int collectorId);

        IEnumerable<TrashCollection> GetInformation(List<int> customerIds);

    }
}
