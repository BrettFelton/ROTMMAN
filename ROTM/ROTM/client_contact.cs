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
    
    public partial class client_contact
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public client_contact()
        {
            this.bookings = new HashSet<booking>();
        }
    
        public int Client_Contact_ID { get; set; }
        public string Contact_Name { get; set; }
        public string Contact_Surname { get; set; }
        public string Contact_Phone { get; set; }
        public string Contact_Email { get; set; }
        public Nullable<int> Client_Contact_Type_ID { get; set; }
        public Nullable<int> Client_ID { get; set; }
    
        public virtual client client { get; set; }
        public virtual client_contact_type client_contact_type { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<booking> bookings { get; set; }
    }
}
