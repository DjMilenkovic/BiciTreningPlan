//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BiciTrainingPlanDAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Trening_Periodi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Trening_Periodi()
        {
            this.Dnevni_Trening_Periodi = new HashSet<Dnevni_Trening_Periodi>();
            this.Nedeljas = new HashSet<Nedelja>();
            this.Treninzis = new HashSet<Treninzi>();
        }
    
        public long ID { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dnevni_Trening_Periodi> Dnevni_Trening_Periodi { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Nedelja> Nedeljas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Treninzi> Treninzis { get; set; }
    }
}
