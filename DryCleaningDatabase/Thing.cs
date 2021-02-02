using System;
using System.Collections.Generic;

#nullable disable

namespace DryCleaningDatabase
{
    public partial class Thing
    {
        public Thing()
        {
            Orders = new HashSet<Order>();
        }

        public int ThingId { get; set; }
        public string ThingName { get; set; }
        public string ThingDescription { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
