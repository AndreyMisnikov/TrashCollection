﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public int ZipCode { get; set; }
 
        public string WeekDays { get; set; }

        public DateTime? NotCollectFrom { get; set; }

        public DateTime? NotCollectTo { get; set; }

        public decimal Balance { get; set; }

        public string UserId { get; set; }
    }
}
