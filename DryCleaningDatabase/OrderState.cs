using System;
using System.Collections.Generic;

#nullable disable

namespace DryCleaningDatabase
{
    public partial class OrderState
    {
        public OrderState()
        {
            Orders = new HashSet<Order>();
        }

        public int OrderStateId { get; set; }
        public bool? PaymentState { get; set; }
        public int ProgressId { get; set; }

        public virtual Progress Progress { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
