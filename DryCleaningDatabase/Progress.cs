using System;
using System.Collections.Generic;

#nullable disable

namespace DryCleaningDatabase
{
    public partial class Progress
    {
        public Progress()
        {
            OrderStates = new HashSet<OrderState>();
        }

        public int ProgressId { get; set; }
        public string ProgressName { get; set; }

        public virtual ICollection<OrderState> OrderStates { get; set; }
    }
}
