//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace eczane1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_ilac_turu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_ilac_turu()
        {
            this.tbl_ilac = new HashSet<tbl_ilac>();
        }
    
        public int ilac_turu_id { get; set; }
        public string ilac_turu_ad { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_ilac> tbl_ilac { get; set; }
    }
}
