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
    
    public partial class Nedelja
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Nedelja()
        {
            this.Trening_Dani = new HashSet<Trening_Dani>();
        }
    
        public long ID { get; set; }
        public long Broj_nedelje { get; set; }
        public System.DateTime Datum_pocetka { get; set; }
        public System.DateTime Datum_zavrsetka { get; set; }
        public long ID_Sezone { get; set; }
        public long ID_Trening_perioda { get; set; }
        public string Opis { get; set; }
    
        public virtual Trening_Periodi Trening_Periodi { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Trening_Dani> Trening_Dani { get; set; }
    }
}
