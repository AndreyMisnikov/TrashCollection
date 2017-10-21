using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    using Domain.Entities;

    public interface ICustomerService
    {
        void CreateOrUpdate(Customer trashCollector);

        Customer GetInformationByUserId(string userId);

        IEnumerable<Customer> GetCustomersByCollector(TrashCollector trashCollector);
    }
}
