//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ROTM
{
    using System;
    using System.Collections.Generic;
    
    public partial class milestone
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public milestone()
        {
            this.employee_milestone = new HashSet<employee_milestone>();
            this.task_milestone = new HashSet<task_milestone>();
        }
    
        public int Milestone_ID { get; set; }
        public string Milestone_Name { get; set; }
        public string Milestone_Description { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<employee_milestone> employee_milestone { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<task_milestone> task_milestone { get; set; }
    }
}
