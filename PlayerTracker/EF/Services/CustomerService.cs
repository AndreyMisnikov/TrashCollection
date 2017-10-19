using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Services
{
    using Domain.Entities.TrashCollector;
    using Domain.Services;

    using EF.Models;

    public class CustomerService : ICustomerService
    {
        /// <summary>
        /// The Custom script repository.
        /// </summary>
        private readonly IGenericRepository<CustomerEntity> repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomScriptService"/> class.
        /// </summary>
        /// <param name="repository">
        /// The repository.
        /// </param>
        public CustomerService(IGenericRepository<CustomerEntity> repository)
        {
            this.repository = repository;
        }


        public void CreateOrUpdate(Customer customer)
        {
            //TODO: ADD AUTOMAPPER AND COPY OBJECT
            CustomerEntity existedCustomer = this.repository.FindByKey(customer.Id);
            if (existedCustomer != null)
            {
                existedCustomer.Id = customer.Id;
                existedCustomer.FirstName = customer.FirstName;
                existedCustomer.LastName = customer.LastName;
                existedCustomer.Email = customer.Email;
                existedCustomer.Address = customer.Address;
                existedCustomer.City = customer.City;
                existedCustomer.State = customer.State;
                existedCustomer.ZipCode = customer.ZipCode;
                existedCustomer.WeekDays = customer.WeekDays;
                existedCustomer.NotCollectFrom = customer.NotCollectFrom;
                existedCustomer.NotCollectTo = customer.NotCollectTo;
                existedCustomer.Balance = customer.Balance;
                existedCustomer.UserId = customer.UserId;
                this.repository.Update(existedCustomer);
                return;
            }

            var updateCustomer = new CustomerEntity
                                     {
                                         Id = customer.Id,
                                         FirstName = customer.FirstName,
                                         LastName = customer.LastName,
                                         Email = customer.Email,
                                         Address = customer.Address,
                                         City = customer.City,
                                         State = customer.State,
                                         ZipCode = customer.ZipCode,
                                         WeekDays = customer.WeekDays,
                                         NotCollectFrom = customer.NotCollectFrom,
                                         NotCollectTo = customer.NotCollectTo,
                                         Balance = customer.Balance,
                                         UserId = customer.UserId
                                     };

            this.repository.Insert(updateCustomer);
        }

        public Customer GetInformationByUserId(string userId)
        {
            var existedCustomer = this.repository.FindBy(item => item.UserId == userId).LastOrDefault();
            if (existedCustomer == null)
            {
                return null;
            }

            return existedCustomer.ToDomainObject();
        }
    }
}

