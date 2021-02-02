using System;
using System.Collections.Generic;

#nullable disable

namespace DryCleaningDatabase
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeFio { get; set; }
        public string Position { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }

        public virtual AccessRule Role { get; set; }
    }
}
