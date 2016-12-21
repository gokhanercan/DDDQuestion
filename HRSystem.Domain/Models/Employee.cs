namespace HRSystem.Domain
{
    using Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Employee")]
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            Vacations = new HashSet<Vacation>();
        }

        public int Id { get; set; }

        [StringLength(100)]
        public string FullName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vacation> Vacations { get; set; }
        public int GrantedAnnualLeaveDays { get; set; }

        public void OpenVacationRequest(int requestedDays)
        {
            this.Vacations.Add(new Vacation(requestedDays));
        }
    }
}
