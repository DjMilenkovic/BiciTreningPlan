﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using ProjectDBDataModel.Entity;

    public partial class ProjectDBEntities : DbContext
    {
        public ProjectDBEntities()
            : base("name=ProjectDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Biciklista> Biciklistas { get; set; }
        public virtual DbSet<Dani> Danis { get; set; }
        public virtual DbSet<Dnevni_Trening_Periodi> Dnevni_Trening_Periodi { get; set; }
        public virtual DbSet<Glavni_Tipovi_Treninga> Glavni_Tipovi_Treninga { get; set; }
        public virtual DbSet<Iskustveni_Nivo> Iskustveni_Nivo { get; set; }
        public virtual DbSet<Lista_Trka> Lista_Trka { get; set; }
        public virtual DbSet<Mentalne_Sposobnosti> Mentalne_Sposobnosti { get; set; }
        public virtual DbSet<Nedelja> Nedeljas { get; set; }
        public virtual DbSet<Prirodne_Sposobnosti> Prirodne_Sposobnosti { get; set; }
        public virtual DbSet<Profilisanje_Profila_Vozaca> Profilisanje_Profila_Vozaca { get; set; }
        public virtual DbSet<Putanja> Putanjas { get; set; }
        public virtual DbSet<Sezona> Sezonas { get; set; }
        public virtual DbSet<Sprint_Test> Sprint_Test { get; set; }
        public virtual DbSet<Test_Kriticne_Snage> Test_Kriticne_Snage { get; set; }
        public virtual DbSet<Test_Ocenjivanja> Test_Ocenjivanja { get; set; }
        public virtual DbSet<Tip_putanje> Tip_putanje { get; set; }
        public virtual DbSet<Tipovi_Treninga> Tipovi_Treninga { get; set; }
        public virtual DbSet<Trening_Dani> Trening_Dani { get; set; }
        public virtual DbSet<Trening_Periodi> Trening_Periodi { get; set; }
        public virtual DbSet<Treninzi> Treninzis { get; set; }
        public virtual DbSet<Treniraj_Ili_Ne> Treniraj_Ili_Ne { get; set; }
        public virtual DbSet<Trke_U_Sezoni> Trke_U_Sezoni { get; set; }
        public virtual DbSet<Vreme> Vremes { get; set; }
    }
}
