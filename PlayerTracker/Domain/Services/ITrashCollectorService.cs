using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Services
{
    using Domain.Entities;

    public interface ITrashCollectorService
    { 
        void CreateOrUpdate(TrashCollector trashCollector);

        TrashCollector GetInformationByUserId(string userId);
    }
}
