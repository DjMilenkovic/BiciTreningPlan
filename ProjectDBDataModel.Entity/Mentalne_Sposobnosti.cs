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
    
    public partial class Mentalne_Sposobnosti
    {
        public System.DateTime Datum_testiranja { get; set; }
        public long ID_Bicikliste { get; set; }
        public int Motivacija { get; set; }
        public int Samopouzdanje { get; set; }
        public int Navika { get; set; }
        public int Fokus { get; set; }
        public int Vizualizacija { get; set; }
    
        public virtual Biciklista Biciklista { get; set; }
    }
}
