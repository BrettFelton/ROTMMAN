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
    
    public partial class instructor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public instructor()
        {
            this.training_course_instance = new HashSet<training_course_instance>();
        }
    
        public int Instructor_ID { get; set; }
        public string Instructor_Name { get; set; }
        public string Instructor_Surname { get; set; }
        public string Instructor_Email { get; set; }
        public Nullable<int> Employee_ID { get; set; }
        public Nullable<int> Supplier_ID { get; set; }
        public Nullable<int> Title_ID { get; set; }
    
        public virtual supplier supplier { get; set; }
        public virtual title title { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<training_course_instance> training_course_instance { get; set; }
        public virtual employee employee { get; set; }
    }
}
