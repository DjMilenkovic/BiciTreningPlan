//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BiciTrainingPlanDAL.DBModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Putanja
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Putanja()
        {
            this.Lista_Trka = new HashSet<Lista_Trka>();
            this.Trening_Dani = new HashSet<Trening_Dani>();
        }
    
        public long ID { get; set; }
        public string Pocetno_odrediste { get; set; }
        public string Odrediste_izmedju { get; set; }
        public string Krajnje_odrediste { get; set; }
        public string Cela_putanja { get; set; }
        public long ID_Tip_putanje { get; set; }
        public long ID_Bicikliste { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lista_Trka> Lista_Trka { get; set; }
        public virtual Tip_putanje Tip_putanje { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Trening_Dani> Trening_Dani { get; set; }
        public virtual Biciklista Biciklista { get; set; }
    }
}