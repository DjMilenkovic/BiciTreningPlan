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
    
    public partial class Treniraj_Ili_Ne : ITable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Treniraj_Ili_Ne()
        {
            this.Glavni_Tipovi_Treninga = new HashSet<Glavni_Tipovi_Treninga>();
        }
    
        public long ID { get; set; }
        public string Naziv { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Glavni_Tipovi_Treninga> Glavni_Tipovi_Treninga { get; set; }
    }
}
