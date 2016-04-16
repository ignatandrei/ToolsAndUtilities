namespace EFSwitch
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstNameEmployee { get; set; }

        [Required]
        [StringLength(50)]
        public string LastNameEmployee { get; set; }

        public int IDDepartment { get; set; }

        public virtual Department Department { get; set; }
    }
}
