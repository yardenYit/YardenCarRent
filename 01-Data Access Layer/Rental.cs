//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JohnBryce
{
    using System;
    using System.Collections.Generic;
    
    public partial class Rental
    {
        public int RentalID { get; set; }
        public int CarFleetID { get; set; }
        public int UserID { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime DesiredEndDate { get; set; }
        public Nullable<System.DateTime> ActualEndDate { get; set; }
    
        public virtual CarFleet CarFleet { get; set; }
        public virtual User User { get; set; }
    }
}
