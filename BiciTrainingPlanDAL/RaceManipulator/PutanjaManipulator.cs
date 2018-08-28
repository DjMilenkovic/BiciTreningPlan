﻿using ProjectDBDataModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BiciTrainingPlanDAL.RaceManipulator
{
    public class PutanjaManipulator : IRepository<Putanja>
    {
        long IDBicikliste;

        public PutanjaManipulator(long IDBicikliste)
        {
            this.IDBicikliste = IDBicikliste;
        }

        public PutanjaManipulator() { }              

        public List<dynamic> GetDataWithJoin()
        {
            using (var db = new ProjectDBEntities())
            {
                var query = from putanja in db.Putanjas.Where(o => o.ID_Bicikliste == IDBicikliste)
                            join tipPutanje in db.Tip_putanje on putanja.ID_Tip_putanje equals tipPutanje.ID into newPutanja
                            from putanje in newPutanja.DefaultIfEmpty()
                            select new
                            {
                                putanja.ID,
                                putanja.Pocetno_odrediste,
                                putanja.Odrediste_izmedju,
                                putanja.Krajnje_odrediste,
                                putanje.Naziv
                            };

                return query.ToList<dynamic>();
            }
        }

        public List<Putanja> GetData()
        {
            using (var db = new ProjectDBEntities())
            {
                var query = from l in db.Putanjas
                            orderby l.ID
                            select l;

                return query.ToList();
            }
        }

        public void Insert(Putanja entity)
        {
            var testPutanjaManipulator = entity as Putanja;
            if (testPutanjaManipulator != null)
            {
                using (var db = new ProjectDBEntities())
                {
                    var customers = db.Set<Putanja>();
                    customers.Add(testPutanjaManipulator);
                    db.SaveChanges();
                }
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public void Update(Putanja entity)
        {
            var putanja = entity as Putanja;
            if (putanja != null)
            {
                using (var db = new ProjectDBEntities())
                {
                    var result = db.Putanjas.SingleOrDefault(b => b.ID == putanja.ID);
                    if (result != null)
                    {
                        result.Pocetno_odrediste = putanja.Pocetno_odrediste;
                        result.Odrediste_izmedju = putanja.Odrediste_izmedju;
                        result.Krajnje_odrediste = putanja.Krajnje_odrediste;
                        result.Cela_putanja = putanja.Cela_putanja;
                        result.ID_Tip_putanje = putanja.ID_Tip_putanje;
                        db.SaveChanges();
                    }
                    else
                    {
                        throw new NullReferenceException();
                    }
                }
            }
        }

        public void Delete(long ID)
        {
            using (var db = new ProjectDBEntities())
            {
                var result = db.Putanjas.SingleOrDefault(b => b.ID == ID);
                if (result != null)
                {
                    db.Putanjas.Remove(result);
                    db.SaveChanges();
                }
            }
        }
    }
}
