using BiciTrainingPlanDAL;
using ProjectDBDataModel.Entity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiciTreningPlanBLL
{
    public class Weeks
    {
        private long IDSezone;
        private long IDBicikliste;
        
        public Weeks(long IDSezone, long IDBicikliste)
        {
            this.IDSezone = IDSezone;
            this.IDBicikliste = IDBicikliste;
        }

        public void insertIntoDAL(DateTime LastRaceDate)
        {
            Season sezona = new Season();
            DateTime dtStart = sezona.GetNextMonday();
            DateTime dtEnd = GetMonday(LastRaceDate);
            while (dtStart <= dtEnd)
            {
                Nedelja ned = new Nedelja();
                ned.Broj_nedelje = GetWeekNumber(dtStart);
                ned.Datum_pocetka = dtStart;
                ned.Datum_zavrsetka = dtStart.AddDays(6);
                ned.ID_Sezone = IDSezone;
                ned.ID_Bicikliste = IDBicikliste;

                NedeljeManipulator nedeljaManipulator = new NedeljeManipulator();
                nedeljaManipulator.Insert(ned);

                dtStart = dtStart.AddDays(7);
            }
        }

        public void UpdateIntoDAL(long IDTreningPerioda, long BrojNedelje)
        {
            NedeljeManipulator nedeljaManipulator = new NedeljeManipulator();
            Nedelja ned = nedeljaManipulator.GetOneData(BrojNedelje, IDSezone, IDBicikliste);
            ned.ID_Trening_perioda = IDTreningPerioda;
            nedeljaManipulator.Update(ned);
        }

        public List<Nedelja> GetFromDAL()
        {
            NedeljeManipulator nedeljaManipulator = new NedeljeManipulator(IDSezone, IDBicikliste);
            return nedeljaManipulator.GetData();
        }

        private DateTime GetMonday(DateTime lastRaceDate)
        {
            DateTime result = lastRaceDate;
            while (result.DayOfWeek != DayOfWeek.Monday)
                result = result.AddDays(-1);
            return result;
        }

        public int GetWeekNumber(DateTime d)
        {
            CultureInfo cul = CultureInfo.CurrentCulture;
            int weekNum = cul.Calendar.GetWeekOfYear(
                d,
                CalendarWeekRule.FirstDay,
                DayOfWeek.Monday);
            return weekNum;
        }
    }
}
