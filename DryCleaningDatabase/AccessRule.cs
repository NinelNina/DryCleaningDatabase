using System;
using System.Collections.Generic;

#nullable disable

namespace DryCleaningDatabase
{
    public partial class AccessRule
    {
        public AccessRule()
        {
            Employees = new HashSet<Employee>();
        }

        public int Role { get; set; }
        public string AccessRules { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
