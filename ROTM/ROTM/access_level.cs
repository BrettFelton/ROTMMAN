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
    using System.ComponentModel.DataAnnotations;

    public partial class access_level
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public access_level()
        {
            this.registration_token = new HashSet<registration_token>();
        }

        public int Access_Level_ID { get; set; }

        [Required]
        [Display(Name = "Access Level Name")]
        [StringLength(50)]
        public string Access_Level_Name { get; set; }

        [Required]
        [Display(Name = "Access Level Description")]
        [StringLength(255)]
        public string Access_Level_Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<registration_token> registration_token { get; set; }
    }
}