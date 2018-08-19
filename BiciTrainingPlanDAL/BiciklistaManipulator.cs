using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiciTrainingPlanDAL
{
    public class BiciklistaManipulator : IDataManipulator<Biciklista>
    {             
        public List<Biciklista> GetData()
        {
            using (var db = new ProjectDBEntities())
            {
                var query = from b in db.Biciklistas
                            orderby b.Ime
                            select b;

                return query.ToList();
            }
        }

        public void Create(ITable tabelaBiciklista)
        {
            var biciklista = tabelaBiciklista as Biciklista;
            if (biciklista != null)
            {
                using (var db = new ProjectDBEntities())
                {
                    var customers = db.Set<Biciklista>();
                    customers.Add(biciklista);
                    db.SaveChanges();
                }
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public void Update(ITable tableBiciklista)
        {
            var biciklista = tableBiciklista as Biciklista;
            if (biciklista != null) {
                using (var db = new ProjectDBEntities())
                {
                    var result = db.Biciklistas.SingleOrDefault(b => b.ID == biciklista.ID);
                    if (result != null)
                    {
                        result.Ime = biciklista.Ime;
                        result.Prezime = biciklista.Prezime;
                        result.Datum_Rodjenja = biciklista.Datum_Rodjenja;
                        result.Adresa = biciklista.Adresa;
                        result.Grad = biciklista.Grad;
                        result.Drzava = biciklista.Drzava;
                        result.Visina = biciklista.Visina;
                        result.Tezina = biciklista.Tezina;
                        result.Omiljena_Trka_A = biciklista.Omiljena_Trka_A;
                        result.Omiljena_Trka_B = biciklista.Omiljena_Trka_B;
                        result.Omiljena_Trka_C = biciklista.Omiljena_Trka_C;
                        result.Slika = biciklista.Slika;
                        result.ID_Nivo_Iskustva = biciklista.ID_Nivo_Iskustva;
                        result.Zaposlenje = biciklista.Zaposlenje;
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
                var result = db.Biciklistas.SingleOrDefault(b => b.ID == ID);
                if (result != null)
                {
                    db.Biciklistas.Remove(result);
                    db.SaveChanges();
                }
            }
        }
    }
}
