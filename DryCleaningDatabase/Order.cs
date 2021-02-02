using System;
using System.Collections.Generic;

#nullable disable

namespace DryCleaningDatabase
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public int ClientId { get; set; }
        public int ServiceId { get; set; }
        public int ThingId { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? IssueDate { get; set; }
        public bool? Delivery { get; set; }
        public int OrderStateId { get; set; }
        public string Contract { get; set; }
        public int? Price { get; set; }
        public string OrderNote { get; set; }

        public virtual Client Client { get; set; }
        public virtual OrderState OrderState { get; set; }
        public virtual Service Service { get; set; }
        public virtual Thing Thing { get; set; }
    }
}
