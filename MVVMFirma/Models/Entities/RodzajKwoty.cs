//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVVMFirma.Models.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class RodzajKwoty
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RodzajKwoty()
        {
            this.Faktura = new HashSet<Faktura>();
        }
    
        public int IDRodzajuKwoty { get; set; }
        public string Nazwa { get; set; }
        public Nullable<bool> CzyAktywny { get; set; }
        public Nullable<int> KtoDodal { get; set; }
        public Nullable<System.DateTime> KiedyDodal { get; set; }
        public Nullable<int> KtoZmodyfikowal { get; set; }
        public Nullable<System.DateTime> KiedyZModyfikowal { get; set; }
        public Nullable<int> KtoUsunal { get; set; }
        public Nullable<System.DateTime> KiedyUsunal { get; set; }
        public string Uwagi { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Faktura> Faktura { get; set; }
    }
}
