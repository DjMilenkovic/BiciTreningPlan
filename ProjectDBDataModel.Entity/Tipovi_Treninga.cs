//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectDBDataModel.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tipovi_Treninga
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tipovi_Treninga()
        {
            this.Dnevni_Trening_Periodi = new HashSet<Dnevni_Trening_Periodi>();
            this.Treninzis = new HashSet<Treninzi>();
        }
    
        public long ID { get; set; }
        public string Naziv { get; set; }
        public long ID_Glavni_tipovi_treninga { get; set; }
        public string Opis { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dnevni_Trening_Periodi> Dnevni_Trening_Periodi { get; set; }
        public virtual Glavni_Tipovi_Treninga Glavni_Tipovi_Treninga { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Treninzi> Treninzis { get; set; }
    }
}
