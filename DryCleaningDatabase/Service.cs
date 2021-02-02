using System;
using System.Collections.Generic;

#nullable disable

namespace DryCleaningDatabase
{
    public partial class Service
    {
        public Service()
        {
            Orders = new HashSet<Order>();
        }

        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public int ServicePrice { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
