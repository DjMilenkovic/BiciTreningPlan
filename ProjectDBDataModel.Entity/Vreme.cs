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
    
    public partial class Vreme
    {
        public System.DateTime Datum { get; set; }
        public Nullable<int> Temperatura { get; set; }
        public Nullable<int> Brzina_vetra { get; set; }
        public Nullable<int> Smer_vetra { get; set; }
        public Nullable<int> Vlaznost_vazduha { get; set; }
        public Nullable<int> Oblacnost { get; set; }
        public string Slika { get; set; }
        public string Opis { get; set; }
        public Nullable<long> ID_Grada { get; set; }
    }
}
