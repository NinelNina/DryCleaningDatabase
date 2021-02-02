using System;
using System.Collections.Generic;

#nullable disable

namespace DryCleaningDatabase
{
    public partial class Client
    {
        public Client()
        {
            Orders = new HashSet<Order>();
        }

        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string Inn { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string OfficeOrFlatNumber { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
