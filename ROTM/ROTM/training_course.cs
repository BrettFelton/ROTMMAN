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
    
    public partial class training_course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public training_course()
        {
            this.training_course_instance = new HashSet<training_course_instance>();
        }
    
        public int Training_Course_ID { get; set; }
        public string Training_Course_Name { get; set; }
        public string Training_Course_Description { get; set; }
        public Nullable<int> Employee_ID { get; set; }
        public Nullable<int> Training_Course_Type_ID { get; set; }
    
        public virtual training_course_type training_course_type { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<training_course_instance> training_course_instance { get; set; }
        public virtual employee employee { get; set; }
    }
}
