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
    
    public partial class CarModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CarModel()
        {
            this.CarTypes = new HashSet<CarType>();
        }
    
        public int CarModelID { get; set; }
        public int CarManufactureID { get; set; }
        public string CarModelName { get; set; }
    
        public virtual CarManufacturer CarManufacturer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarType> CarTypes { get; set; }
    }
}
