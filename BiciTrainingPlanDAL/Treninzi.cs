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
    
    public partial class Treninzi : ITable
    {
        public long ID { get; set; }
        public long ID_Iskustveni_nivo { get; set; }
        public long ID_Tipovi_treninga { get; set; }
        public long ID_Trening_perioda { get; set; }
        public int Zona_srcane_frekvencije { get; set; }
        public int Duzina_treninga { get; set; }
    
        public virtual Iskustveni_Nivo Iskustveni_Nivo { get; set; }
        public virtual Tipovi_Treninga Tipovi_Treninga { get; set; }
        public virtual Trening_Periodi Trening_Periodi { get; set; }
    }
}
