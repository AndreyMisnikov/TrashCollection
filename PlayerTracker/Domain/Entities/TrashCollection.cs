using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TrashCollection
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int CollectorId { get; set; }

        public string CustomerStatus { get; set; }

        public DateTime CustomerStatusModifiedDate { get; set; }

        public string CollectorStatus { get; set; }

        public DateTime CollectorStatusModifiedDate { get; set; }

        public bool IsApproved { get; set; }
    }
}
