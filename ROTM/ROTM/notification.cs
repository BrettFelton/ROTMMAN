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
    
    public partial class notification
    {
        public int Notification_ID { get; set; }
        public string Notification_Name { get; set; }
        public string Notification_Text { get; set; }
        public Nullable<System.DateTime> Notification_DateTime { get; set; }
        public Nullable<int> Mailing_List_ID { get; set; }
    
        public virtual mailing_list mailing_list { get; set; }
    }
}
