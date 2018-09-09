using BiciTrainingPlanDAL.RaceManipulator;
using ProjectDBDataModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiciTreningPlanBLL
{
   public class Season
    {
        public DateTime MaxDate(long IDBicikliste)
        {
            SezonaManipulator sezona = new SezonaManipulator(IDBicikliste);
            return sezona.GetData().Select(o => o.Datum_pocetka).Max();
        }

        public DateTime GetOneSeasonFromDAL(long IDBicikliste)
        {
            SezonaManipulator sezona = new SezonaManipulator(IDBicikliste);
            return sezona.GetData().OrderByDescending(o => o.Datum_pocetka).FirstOrDefault().Datum_pocetka;
        }

        public void InsertIntoDAL(long iDBicikliste)
        {
            SezonaManipulator sezonaManipulator = new SezonaManipulator();
            Sezona sezona = new Sezona();
            sezona.ID_Bicikliste = iDBicikliste;
            sezona.Datum_pocetka = GetNextMonday();
            sezonaManipulator.Insert(sezona);
        }

        public DateTime GetNextMonday()
        {
            DateTime result = DateTime.Now.AddDays(1);
            while (result.DayOfWeek != DayOfWeek.Monday)
                result = result.AddDays(1);
            return result;
        }

        public void DeleteToDAL(DateTime firstMonday, long IDBicikliste)
        {
            SezonaManipulator sezonaManipulator = new SezonaManipulator();
            sezonaManipulator.Delete(firstMonday, IDBicikliste);
        }

        public long GetSeasonID(long IDBicikliste)
        {
            SezonaManipulator sezona = new SezonaManipulator(IDBicikliste);
            return sezona.GetData().Select(o => o.ID).Max();
        }

        public string GetTime(long IDBicikliste)
        {
            Dictionary<string, string> trainingHours = new Dictionary<string, string>();
            trainingHours.Add("worldtour", "800-1200");
            trainingHours.Add("pro", "700-1000");
            trainingHours.Add("pro-amateur", "500-700");
            trainingHours.Add("amateur", "350-500");
            trainingHours.Add("recreation", "200-350");

            List<string> category = new List<string>();
            category.Add("recreation");
            category.Add("amateur");
            category.Add("pro-amateur");
            category.Add("pro");
            category.Add("worldtour");

            RiderProfile rider = new RiderProfile();
            var data = rider.getDataFromDAL(IDBicikliste);
           
            int expLv = (int)data.ID_Nivo_Iskustva;
            string work = data.Zaposlenje;

            switch (expLv)
            {
                case 1:
                    category.Remove("worldtour");
                    category.Remove("pro");
                    category.Remove("pro-amateur");
                    if (work == "Yes")
                    {
                        category.Remove("amateur");
                    }
                    else
                    {
                        category.Remove("recreation");
                    }

                    break;
                case 2:
                    category.Remove("recreation");
                    category.Remove("amateur");
                    category.Remove("worldtour");
                    if (work == "Yes")
                    {
                        category.Remove("pro");
                    }
                    else
                    {
                        category.Remove("pro-amateur");
                    }

                    break;
                case 3:
                    category.Remove("recreation");
                    category.Remove("amateur");
                    category.Remove("pro-amateur");
                    if (work == "Yes")
                    {
                        category.Remove("worldtour");
                    }
                    else
                    {
                        category.Remove("pro");
                    }

                    break;
                default:
                    break;
            }

            return trainingHours[category[0]];
        }
    }
}
