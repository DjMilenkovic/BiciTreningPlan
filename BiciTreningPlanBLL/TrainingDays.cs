using BiciTrainingPlanDAL;
using BiciTrainingPlanDAL.RaceManipulator;
using ProjectDBDataModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiciTreningPlanBLL
{
    public class TrainingDays
    {
        private long IDBicikliste;
        private long IDSezone;
        TreningDaniManipulator treningDaniManipulator;
        public TrainingDays(long IDBicikliste, long IDSezone)
        {
            treningDaniManipulator = new TreningDaniManipulator();
            this.IDBicikliste = IDBicikliste;
            this.IDSezone = IDSezone;
        }

        public void insertIntoDAL()
        {
            List<Dnevni_Trening_Periodi> trainingDay;
            List<Nedelja> lista = GetWeeks();
            Biciklista biciklista = ReturnBiciklista();
            long expLv = biciklista.ID_Nivo_Iskustva;
            Random rand = new Random();
            int training;
            long IDTreninga=0;
            int VremeTreninga=0;

            foreach (Nedelja nedelja in lista)
            {
                DateTime date = nedelja.Datum_pocetka;
                DateTime datum;
                int dayInWeek;
                for (dayInWeek = 1; dayInWeek <= 7; dayInWeek++)
                {
                    DayOfWeek day = date.DayOfWeek;
                    datum = Convert.ToDateTime(date.ToShortDateString());                   

                    switch (day)
                    {
                        case DayOfWeek.Monday:
                            trainingDay = GetDnevneTreningPeriode(1, (long)nedelja.ID_Trening_perioda);
                            training = rand.Next(0, trainingDay.Count);
                            Treninzi treningM = GetTraining(trainingDay[training].ID_Trening_period, trainingDay[training].ID_Tipovi_treninga, expLv);
                            IDTreninga = treningM.ID;
                            VremeTreninga = treningM.Duzina_treninga;
                            break;
                        case DayOfWeek.Tuesday:
                            trainingDay = GetDnevneTreningPeriode(2, (long)nedelja.ID_Trening_perioda);
                            training = rand.Next(0, trainingDay.Count);
                            Treninzi treningTu = GetTraining(trainingDay[training].ID_Trening_period, trainingDay[training].ID_Tipovi_treninga, expLv);
                            IDTreninga = treningTu.ID;
                            VremeTreninga = treningTu.Duzina_treninga;
                            break;
                        case DayOfWeek.Wednesday:
                            trainingDay = GetDnevneTreningPeriode(3, (long)nedelja.ID_Trening_perioda);
                            training = rand.Next(0, trainingDay.Count);
                            Treninzi treningW = GetTraining(trainingDay[training].ID_Trening_period, trainingDay[training].ID_Tipovi_treninga, expLv);
                            IDTreninga = treningW.ID;
                            VremeTreninga = treningW.Duzina_treninga;
                            break;
                        case DayOfWeek.Thursday:
                            trainingDay = GetDnevneTreningPeriode(4, (long)nedelja.ID_Trening_perioda);
                            training = rand.Next(0, trainingDay.Count);
                            Treninzi treningTh = GetTraining(trainingDay[training].ID_Trening_period, trainingDay[training].ID_Tipovi_treninga, expLv);
                            IDTreninga = treningTh.ID;
                            VremeTreninga = treningTh.Duzina_treninga;
                            break;
                        case DayOfWeek.Friday:
                            trainingDay = GetDnevneTreningPeriode(5, (long)nedelja.ID_Trening_perioda);
                            training = rand.Next(0, trainingDay.Count);
                            Treninzi treningF = GetTraining(trainingDay[training].ID_Trening_period, trainingDay[training].ID_Tipovi_treninga, expLv);
                            IDTreninga = treningF.ID;
                            VremeTreninga = treningF.Duzina_treninga;
                            break;
                        case DayOfWeek.Saturday:
                            trainingDay = GetDnevneTreningPeriode(6, (long)nedelja.ID_Trening_perioda);
                            training = rand.Next(0, trainingDay.Count);
                            Treninzi treningSa = GetTraining(trainingDay[training].ID_Trening_period, trainingDay[training].ID_Tipovi_treninga, expLv);
                            IDTreninga = treningSa.ID;
                            VremeTreninga = treningSa.Duzina_treninga;
                            break;
                        case DayOfWeek.Sunday:
                            trainingDay = GetDnevneTreningPeriode(7, (long)nedelja.ID_Trening_perioda);
                            training = rand.Next(0, trainingDay.Count);
                            Treninzi treningSu = GetTraining(trainingDay[training].ID_Trening_period, trainingDay[training].ID_Tipovi_treninga, expLv);
                            IDTreninga = treningSu.ID;
                            VremeTreninga = treningSu.Duzina_treninga;
                            break;
                        default:
                            break;
                    }

                    Trening_Dani treningDan = new Trening_Dani();
                    treningDan.ID_Bicikliste = IDBicikliste;
                    treningDan.Datum_treninga = datum;
                    treningDan.Broj_nedelje = nedelja.Broj_nedelje;
                    treningDan.ID_Treninga = IDTreninga;
                    treningDan.ID_Sezone = IDSezone;
                    treningDan.Vreme_treninga = VremeTreninga.ToString();

                    treningDaniManipulator.Insert(treningDan);

                    date = date.AddDays(1);                   
                }
            }
        }

        private Biciklista ReturnBiciklista()
        {
            RiderProfile profil = new RiderProfile();
            return profil.getDataFromDAL(IDBicikliste);
        }

        private List<Nedelja> GetWeeks()
        {
            Weeks nedelje = new Weeks(IDSezone,IDBicikliste);
            return nedelje.GetFromDAL();
        }

        public List<Trening_Dani> getTipPutanje()
        {
            return treningDaniManipulator.GetData();
        }

        public List<dynamic> getPutanjeWithJoin()
        {
            return treningDaniManipulator.GetDataWithJoin(IDBicikliste, IDSezone);
        }

        private Treninzi GetTraining(long TreningPeriod, long TipTreninga, long IskustveniNivo)
        {
            TreningListManipulator tlm = new TreningListManipulator();
            return tlm.GetTrening(IskustveniNivo, TipTreninga, TreningPeriod);
        }

        private int GetTrainingDuration(long TrainingID)
        {
            TreningListManipulator tlm = new TreningListManipulator();
            return Convert.ToInt32(tlm.GetData().Where(o => o.ID == TrainingID).FirstOrDefault().Duzina_treninga);
        }

        private List<Dnevni_Trening_Periodi> GetDnevneTreningPeriode(long IDDana, long IDPerioda)
        {
            DnevniTreningPeriodiManipulator dtpm = new DnevniTreningPeriodiManipulator(IDDana, IDPerioda);
            return dtpm.GetData();
        }
    }
}
