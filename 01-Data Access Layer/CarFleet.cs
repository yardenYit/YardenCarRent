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
    
    public partial class CarFleet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CarFleet()
        {
            this.Rentals = new HashSet<Rental>();
        }
    
        public int CarFleetID { get; set; }
        public int CarTypeID { get; set; }
        public string CarNumber { get; set; }
        public int CurrentMiles { get; set; }
        public string ImageFileName { get; set; }
        public bool IsOK2Rent { get; set; }
    
        public virtual CarType CarType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
