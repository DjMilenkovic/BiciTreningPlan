﻿using ProjectDBDataModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BiciTrainingPlanDAL.TestManipulator
{
    public class ProfilisanjeProfilaVozacaManipulator : IRepository<Profilisanje_Profila_Vozaca>
    {
        long IDBicikliste;

        public ProfilisanjeProfilaVozacaManipulator(long IDBicikliste)
        {
            this.IDBicikliste = IDBicikliste;
        }

        public ProfilisanjeProfilaVozacaManipulator() { }
   
        public void Delete(long ID)
        {
            throw new NotImplementedException();
        }

        public Profilisanje_Profila_Vozaca GetOneData(long iD)
        {
            using (var db = new ProjectDBEntities())
            {
                var query = from b in db.Profilisanje_Profila_Vozaca
                            where b.ID_Bicikliste == IDBicikliste
                            select b;

                var profilVozaca = query.FirstOrDefault();
                return profilVozaca;
            }
        }

        public List<Profilisanje_Profila_Vozaca> GetData()
        {
            using (var db = new ProjectDBEntities())
            {
                var query = from b in db.Profilisanje_Profila_Vozaca
                            where b.ID_Bicikliste == IDBicikliste
                            select b;

                return query.ToList();
            }
        }

        public void Insert(Profilisanje_Profila_Vozaca entity)
        {
            var testProfilisanjeProfilaVozaca = entity as Profilisanje_Profila_Vozaca;
            if (testProfilisanjeProfilaVozaca != null)
            {
                using (var db = new ProjectDBEntities())
                {
                    var customers = db.Set<Profilisanje_Profila_Vozaca>();
                    customers.Add(testProfilisanjeProfilaVozaca);
                    db.SaveChanges();
                }
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public void Update(Profilisanje_Profila_Vozaca entity)
        {
            throw new NotImplementedException();
        }
    }
}
