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
    
    public partial class tasks_completed
    {
        public int Task_ID { get; set; }
        public int Booking_Instance_ID { get; set; }
        public string Task_Comments { get; set; }
    
        public virtual booking_instance booking_instance { get; set; }
        public virtual task task { get; set; }
    }
}
