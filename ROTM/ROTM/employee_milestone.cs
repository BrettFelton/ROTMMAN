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
    
    public partial class employee_milestone
    {
        public int Employee_ID { get; set; }
        public int Milestone_ID { get; set; }
        public string Reason_Milestone { get; set; }
        public Nullable<int> Milestone_Progress { get; set; }
    
        public virtual milestone milestone { get; set; }
        public virtual employee employee { get; set; }
    }
}
