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
    
    public partial class booking
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public booking()
        {
            this.booking_instance = new HashSet<booking_instance>();
            this.booking_reminders = new HashSet<booking_reminders>();
        }
    
        public int Booking_ID { get; set; }
        public string Booking_Name { get; set; }
        public Nullable<System.DateTime> Booking_Date { get; set; }
        public Nullable<System.TimeSpan> Booking_Start_Time { get; set; }
        public Nullable<System.TimeSpan> Booking_End_Time { get; set; }
        public Nullable<int> Booking_Type_ID { get; set; }
        public Nullable<int> Client_ID { get; set; }
        public Nullable<int> Employee_ID { get; set; }
        public Nullable<int> Address_ID { get; set; }
    
        public virtual address address { get; set; }
        public virtual booking_type booking_type { get; set; }
        public virtual client client { get; set; }
        public virtual employee employee { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<booking_instance> booking_instance { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<booking_reminders> booking_reminders { get; set; }
    }
}
