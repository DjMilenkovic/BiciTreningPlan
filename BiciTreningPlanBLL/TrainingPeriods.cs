using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDBDataModel.Entity;
using BiciTrainingPlanDAL.TestManipulator;
using BiciTrainingPlanDAL.RaceManipulator;

namespace BiciTreningPlanBLL
{
    public class TrainingPeriods
    {
        private long IDBicikliste;
        private long IDSezone;
        Weeks nedelja;
        public TrainingPeriods(long IDBicikliste, long IDSezone)
        {
            this.IDBicikliste = IDBicikliste;
            this.IDSezone = IDSezone;
            nedelja = new Weeks(IDSezone, IDBicikliste);
        }

        public Trening_Periodi getDataFromDAL(long ID)
        {
            TreningPeriodManipulator periodManipulator = new TreningPeriodManipulator();
            var result = periodManipulator.GetDataWithJoin(ID);
            return result;
        }

        public void InsertTrainingPeriodsToWeeks(List<DateTime> racedDate)
        {
            int firstWeek = nedelja.GetWeekNumber(racedDate[0]);
            int secondWeek = nedelja.GetWeekNumber(racedDate[1]);
            int thirdWeek = nedelja.GetWeekNumber(racedDate[2]);

            Season sezona = new Season();
            int firstSeasonWeek = nedelja.GetWeekNumber(sezona.GetOneSeasonFromDAL(IDBicikliste));

            List<int> races = new List<int> { firstSeasonWeek, firstWeek, secondWeek, thirdWeek };

            for (int race = 0; race < races.Count; race++)
            {
                if (race == 0)
                    continue;

                int range = races[race] - races[race - 1];

                switch (range)
                {
                    case 26:
                        {
                            for (int first = races[race - 1]; first < races[race]; first++)
                            {
                                //Preparation period
                                if ((first == races[race - 1]) || (first == races[race - 1] + 1) || (first == races[race - 1] + 2) || (first == races[race - 1] + 3))
                                {
                                    nedelja.UpdateIntoDAL(1, first);
                                }
                                //Base 1 period
                                else if ((first == races[race - 1] + 4) || (first == races[race - 1] + 5) || (first == races[race - 1] + 6) || (first == races[race - 1] + 7))
                                {
                                    nedelja.UpdateIntoDAL(2, first);
                                }
                                //Base 2 period
                                else if ((first == races[race - 1] + 8) || (first == races[race - 1] + 9) || (first == races[race - 1] + 10) || (first == races[race - 1] + 11))
                                {
                                    nedelja.UpdateIntoDAL(3, first);
                                }
                                //Base 3 period
                                else if ((first == races[race - 1] + 12) || (first == races[race - 1] + 13) || (first == races[race - 1] + 14) || (first == races[race - 1] + 15))
                                {
                                    nedelja.UpdateIntoDAL(4, first);
                                }
                                //Build 1 period
                                else if ((first == races[race - 1] + 16) || (first == races[race - 1] + 17) || (first == races[race - 1] + 18) || (first == races[race - 1] + 19))
                                {
                                    nedelja.UpdateIntoDAL(5, first);
                                }
                                //Build 2 period
                                else if ((first == races[race - 1] + 20) || (first == races[race - 1] + 21) || (first == races[race - 1] + 22) || (first == races[race - 1] + 23))
                                {

                                    nedelja.UpdateIntoDAL(6, first);
                                }
                                //Peak
                                else if ((first == races[race - 1] + 24) || (first == races[race - 1] + 25))
                                {

                                    nedelja.UpdateIntoDAL(7, first);
                                }
                            }
                            break;
                        }
                    case 25:
                        {
                            for (int first = races[race - 1]; first < races[race]; first++)
                            {
                                //Preparation period
                                if ((first == races[race - 1]) || (first == races[race - 1] + 1) || (first == races[race - 1] + 2) || (first == races[race - 1] + 3))
                                {

                                    nedelja.UpdateIntoDAL(1, first);
                                }
                                //Base 1 period
                                else if ((first == races[race - 1] + 4) || (first == races[race - 1] + 5) || (first == races[race - 1] + 6))
                                {

                                    nedelja.UpdateIntoDAL(2, first);
                                }
                                //Base 2 period
                                else if ((first == races[race - 1] + 7) || (first == races[race - 1] + 8) || (first == races[race - 1] + 9) || (first == races[race - 1] + 10))
                                {

                                    nedelja.UpdateIntoDAL(3, first);
                                }
                                //Base 3 period
                                else if ((first == races[race - 1] + 11) || (first == races[race - 1] + 12) || (first == races[race - 1] + 13) || (first == races[race - 1] + 14))
                                {

                                    nedelja.UpdateIntoDAL(4, first);
                                }
                                //Build 1 period
                                else if ((first == races[race - 1] + 15) || (first == races[race - 1] + 16) || (first == races[race - 1] + 17) || (first == races[race - 1] + 18))
                                {

                                    nedelja.UpdateIntoDAL(5, first);
                                }
                                //Build 2 period
                                else if ((first == races[race - 1] + 19) || (first == races[race - 1] + 20) || (first == races[race - 1] + 21) || (first == races[race - 1] + 22))
                                {

                                    nedelja.UpdateIntoDAL(6, first);
                                }
                                //Peak
                                else if ((first == races[race - 1] + 23) || (first == races[race - 1] + 24))
                                {

                                    nedelja.UpdateIntoDAL(7, first);
                                }
                            }
                        }
                        break;
                    case 24:
                        {
                            for (int first = races[race - 1]; first < races[race]; first++)
                            {
                                //Preparation period
                                if ((first == races[race - 1]) || (first == races[race - 1] + 1) || (first == races[race - 1] + 2) || (first == races[race - 1] + 3))
                                {

                                    nedelja.UpdateIntoDAL(1, first);
                                }
                                //Base 1 period
                                else if ((first == races[race - 1] + 4) || (first == races[race - 1] + 5) || (first == races[race - 1] + 6))
                                {

                                    nedelja.UpdateIntoDAL(2, first);
                                }
                                //Base 2 period
                                else if ((first == races[race - 1] + 7) || (first == races[race - 1] + 8) || (first == races[race - 1] + 9))
                                {

                                    nedelja.UpdateIntoDAL(3, first);
                                }
                                //Base 3 period
                                else if ((first == races[race - 1] + 10) || (first == races[race - 1] + 11) || (first == races[race - 1] + 12) || (first == races[race - 1] + 13))
                                {

                                    nedelja.UpdateIntoDAL(4, first);
                                }
                                //Build 1 period
                                else if ((first == races[race - 1] + 14) || (first == races[race - 1] + 15) || (first == races[race - 1] + 16) || (first == races[race - 1] + 17))
                                {

                                    nedelja.UpdateIntoDAL(5, first);
                                }
                                //Build 2 period
                                else if ((first == races[race - 1] + 18) || (first == races[race - 1] + 19) || (first == races[race - 1] + 20) || (first == races[race - 1] + 21))
                                {

                                    nedelja.UpdateIntoDAL(6, first);
                                }
                                //Peak
                                else if ((first == races[race - 1] + 22) || (first == races[race - 1] + 23))
                                {

                                    nedelja.UpdateIntoDAL(7, first);
                                }
                            }
                        }
                        break;
                    case 23:
                        {
                            for (int first = races[race - 1]; first < races[race]; first++)
                            {
                                //Preparation period
                                if ((first == races[race - 1]) || (first == races[race - 1] + 1) || (first == races[race - 1] + 2) || (first == races[race - 1] + 3))
                                {

                                    nedelja.UpdateIntoDAL(1, first);
                                }
                                //Base 1 period
                                else if ((first == races[race - 1] + 4) || (first == races[race - 1] + 5) || (first == races[race - 1] + 6))
                                {

                                    nedelja.UpdateIntoDAL(2, first);
                                }
                                //Base 2 period
                                else if ((first == races[race - 1] + 7) || (first == races[race - 1] + 8) || (first == races[race - 1] + 9))
                                {

                                    nedelja.UpdateIntoDAL(3, first);
                                }
                                //Base 3 period
                                else if ((first == races[race - 1] + 10) || (first == races[race - 1] + 11) || (first == races[race - 1] + 12))
                                {

                                    nedelja.UpdateIntoDAL(4, first);
                                }
                                //Build 1 period
                                else if ((first == races[race - 1] + 13) || (first == races[race - 1] + 14) || (first == races[race - 1] + 15) || (first == races[race - 1] + 16))
                                {

                                    nedelja.UpdateIntoDAL(5, first);
                                }
                                //Build 2 period
                                else if ((first == races[race - 1] + 17) || (first == races[race - 1] + 18) || (first == races[race - 1] + 19) || (first == races[race - 1] + 20))
                                {

                                    nedelja.UpdateIntoDAL(6, first);
                                }
                                //Peak
                                else if ((first == races[race - 1] + 21) || (first == races[race - 1] + 22))
                                {

                                    nedelja.UpdateIntoDAL(7, first);
                                }
                            }
                        }
                        break;
                    case 22:
                        {
                            for (int first = races[race - 1]; first < races[race]; first++)
                            {
                                //Preparation period
                                if ((first == races[race - 1]) || (first == races[race - 1] + 1) || (first == races[race - 1] + 2) || (first == races[race - 1] + 3))
                                {

                                    nedelja.UpdateIntoDAL(1, first);

                                }
                                //Base 1 period
                                else if ((first == races[race - 1] + 4) || (first == races[race - 1] + 5) || (first == races[race - 1] + 6))
                                {

                                    nedelja.UpdateIntoDAL(2, first);
                                }
                                //Base 2 period
                                else if ((first == races[race - 1] + 7) || (first == races[race - 1] + 8) || (first == races[race - 1] + 9))
                                {

                                    nedelja.UpdateIntoDAL(3, first);
                                }
                                //Base 3 period
                                else if ((first == races[race - 1] + 10) || (first == races[race - 1] + 11) || (first == races[race - 1] + 12))
                                {

                                    nedelja.UpdateIntoDAL(4, first);
                                }
                                //Build 1 period
                                else if ((first == races[race - 1] + 13) || (first == races[race - 1] + 14) || (first == races[race - 1] + 15))
                                {

                                    nedelja.UpdateIntoDAL(5, first);
                                }
                                //Build 2 period
                                else if ((first == races[race - 1] + 16) || (first == races[race - 1] + 17) || (first == races[race - 1] + 18) || (first == races[race - 1] + 19))
                                {

                                    nedelja.UpdateIntoDAL(6, first);
                                }
                                //Peak
                                else if ((first == races[race - 1] + 20) || (first == races[race - 1] + 21))
                                {

                                    nedelja.UpdateIntoDAL(7, first);
                                }
                            }
                        }
                        break;
                    case 21:
                        {
                            for (int first = races[race - 1]; first < races[race]; first++)
                            {
                                //Preparation period
                                if ((first == races[race - 1]) || (first == races[race - 1] + 1) || (first == races[race - 1] + 2) || (first == races[race - 1] + 3))
                                {

                                    nedelja.UpdateIntoDAL(1, first);

                                }
                                //Base 1 period
                                else if ((first == races[race - 1] + 4) || (first == races[race - 1] + 5) || (first == races[race - 1] + 6))
                                {

                                    nedelja.UpdateIntoDAL(2, first);

                                }
                                //Base 2 period
                                else if ((first == races[race - 1] + 7) || (first == races[race - 1] + 8) || (first == races[race - 1] + 9))
                                {

                                    nedelja.UpdateIntoDAL(3, first);

                                }
                                //Base 3 period
                                else if ((first == races[race - 1] + 10) || (first == races[race - 1] + 11) || (first == races[race - 1] + 12))
                                {

                                    nedelja.UpdateIntoDAL(4, first);

                                }
                                //Build 1 period
                                else if ((first == races[race - 1] + 13) || (first == races[race - 1] + 14) || (first == races[race - 1] + 15))
                                {

                                    nedelja.UpdateIntoDAL(5, first);

                                }
                                //Build 2 period
                                else if ((first == races[race - 1] + 16) || (first == races[race - 1] + 17) || (first == races[race - 1] + 18))
                                {

                                    nedelja.UpdateIntoDAL(6, first);


                                }
                                //Peak
                                else if ((first == races[race - 1] + 19) || (first == races[race - 1] + 20))
                                {

                                    nedelja.UpdateIntoDAL(7, first);

                                }
                            }
                        }
                        break;
                    case 20:
                        {
                            for (int first = races[race - 1]; first < races[race]; first++)
                            {
                                //Preparation period
                                if ((first == races[race - 1]) || (first == races[race - 1] + 1) || (first == races[race - 1] + 2))
                                {

                                    nedelja.UpdateIntoDAL(1, first);
                                }
                                //Base 1 period
                                else if ((first == races[race - 1] + 3) || (first == races[race - 1] + 4) || (first == races[race - 1] + 5))
                                {

                                    nedelja.UpdateIntoDAL(2, first);

                                }
                                //Base 2 period
                                else if ((first == races[race - 1] + 6) || (first == races[race - 1] + 7) || (first == races[race - 1] + 8))
                                {

                                    nedelja.UpdateIntoDAL(3, first);
                                }
                                //Base 3 period
                                else if ((first == races[race - 1] + 9) || (first == races[race - 1] + 10) || (first == races[race - 1] + 11))
                                {

                                    nedelja.UpdateIntoDAL(4, first);
                                }
                                //Build 1 period
                                else if ((first == races[race - 1] + 12) || (first == races[race - 1] + 13) || (first == races[race - 1] + 14))
                                {

                                    nedelja.UpdateIntoDAL(5, first);
                                }
                                //Build 2 period
                                else if ((first == races[race - 1] + 15) || (first == races[race - 1] + 16) || (first == races[race - 1] + 17))
                                {

                                    nedelja.UpdateIntoDAL(6, first);
                                }
                                //Peak
                                else if ((first == races[race - 1] + 18) || (first == races[race - 1] + 19))
                                {

                                    nedelja.UpdateIntoDAL(7, first);

                                }
                            }
                        }
                        break;
                    case 19:
                        {
                            for (int first = races[race - 1]; first < races[race]; first++)
                            {
                                //Preparation period
                                if ((first == races[race - 1]) || (first == races[race - 1] + 1) || (first == races[race - 1] + 2))
                                {

                                    nedelja.UpdateIntoDAL(1, first);
                                }
                                //Base 1 period
                                else if ((first == races[race - 1] + 3) || (first == races[race - 1] + 4))
                                {

                                    nedelja.UpdateIntoDAL(2, first);
                                }
                                //Base 2 period
                                else if ((first == races[race - 1] + 5) || (first == races[race - 1] + 6) || (first == races[race - 1] + 7))
                                {

                                    nedelja.UpdateIntoDAL(3, first);
                                }
                                //Base 3 period
                                else if ((first == races[race - 1] + 8) || (first == races[race - 1] + 9) || (first == races[race - 1] + 10))
                                {

                                    nedelja.UpdateIntoDAL(4, first);
                                }
                                //Build 1 period
                                else if ((first == races[race - 1] + 11) || (first == races[race - 1] + 12) || (first == races[race - 1] + 13))
                                {

                                    nedelja.UpdateIntoDAL(5, first);
                                }
                                //Build 2 period
                                else if ((first == races[race - 1] + 14) || (first == races[race - 1] + 15) || (first == races[race - 1] + 16))
                                {

                                    nedelja.UpdateIntoDAL(6, first);
                                }
                                //Peak
                                else if ((first == races[race - 1] + 17) || (first == races[race - 1] + 18))
                                {

                                    nedelja.UpdateIntoDAL(7, first);
                                }
                            }
                        }
                        break;
                    case 18:
                        {
                            for (int first = races[race - 1]; first < races[race]; first++)
                            {
                                //Preparation period
                                if ((first == races[race - 1]) || (first == races[race - 1] + 1))
                                {
                                    nedelja.UpdateIntoDAL(1, first);
                                }
                                //Base 1 period
                                else if ((first == races[race - 1] + 2) || (first == races[race - 1] + 3))
                                {
                                    nedelja.UpdateIntoDAL(2, first);
                                }
                                //Base 2 period
                                else if ((first == races[race - 1] + 4) || (first == races[race - 1] + 5) || (first == races[race - 1] + 6))
                                {
                                    nedelja.UpdateIntoDAL(3, first);
                                }
                                //Base 3 period
                                else if ((first == races[race - 1] + 7) || (first == races[race - 1] + 8) || (first == races[race - 1] + 9))
                                {
                                    nedelja.UpdateIntoDAL(4, first);
                                }
                                //Build 1 period
                                else if ((first == races[race - 1] + 10) || (first == races[race - 1] + 11) || (first == races[race - 1] + 12))
                                {
                                    nedelja.UpdateIntoDAL(5, first);
                                }
                                //Build 2 period
                                else if ((first == races[race - 1] + 13) || (first == races[race - 1] + 14) || (first == races[race - 1] + 15))
                                {
                                    nedelja.UpdateIntoDAL(6, first);
                                }
                                //Peak
                                else if ((first == races[race - 1] + 16) || (first == races[race - 1] + 17))
                                {

                                    nedelja.UpdateIntoDAL(7, first);
                                }
                            }
                        }
                        break;
                    case 17:
                        {
                            for (int first = races[race - 1]; first < races[race]; first++)
                            {
                                //Preparation period
                                if ((first == races[race - 1]))
                                {

                                    nedelja.UpdateIntoDAL(1, first);
                                }
                                //Base 1 period
                                else if ((first == races[race - 1] + 1) || (first == races[race - 1] + 2))
                                {

                                    nedelja.UpdateIntoDAL(2, first);
                                }
                                //Base 2 period
                                else if ((first == races[race - 1] + 3) || (first == races[race - 1] + 4) || (first == races[race - 1] + 5))
                                {

                                    nedelja.UpdateIntoDAL(3, first);
                                }
                                //Base 3 period
                                else if ((first == races[race - 1] + 6) || (first == races[race - 1] + 7) || (first == races[race - 1] + 8))
                                {

                                    nedelja.UpdateIntoDAL(4, first);
                                }
                                //Build 1 period
                                else if ((first == races[race - 1] + 9) || (first == races[race - 1] + 10) || (first == races[race - 1] + 11))
                                {

                                    nedelja.UpdateIntoDAL(5, first);
                                }
                                //Build 2 period
                                else if ((first == races[race - 1] + 12) || (first == races[race - 1] + 13) || (first == races[race - 1] + 14))
                                {

                                    nedelja.UpdateIntoDAL(6, first);
                                }
                                //Peak
                                else if ((first == races[race - 1] + 15) || (first == races[race - 1] + 16))
                                {

                                    nedelja.UpdateIntoDAL(7, first);
                                }
                            }
                        }
                        break;
                    case 16:
                        {
                            for (int first = races[race - 1]; first < races[race]; first++)
                            {
                                //Preparation period

                                //Base 1 period
                                if ((first == races[race - 1]) || (first == races[race - 1] + 1))
                                {

                                    nedelja.UpdateIntoDAL(2, first);
                                }
                                //Base 2 period
                                else if ((first == races[race - 1] + 2) || (first == races[race - 1] + 3) || (first == races[race - 1] + 4))
                                {

                                    nedelja.UpdateIntoDAL(3, first);
                                }
                                //Base 3 period
                                else if ((first == races[race - 1] + 5) || (first == races[race - 1] + 7) || (first == races[race - 1] + 8))
                                {

                                    nedelja.UpdateIntoDAL(4, first);
                                }
                                //Build 1 period
                                else if ((first == races[race - 1] + 8) || (first == races[race - 1] + 9) || (first == races[race - 1] + 10))
                                {

                                    nedelja.UpdateIntoDAL(5, first);
                                }
                                //Build 2 period
                                else if ((first == races[race - 1] + 11) || (first == races[race - 1] + 12) || (first == races[race - 1] + 13))
                                {

                                    nedelja.UpdateIntoDAL(6, first);
                                }
                                //Peak
                                else if ((first == races[race - 1] + 14) || (first == races[race - 1] + 15))
                                {

                                    nedelja.UpdateIntoDAL(7, first);
                                }
                            }
                        }
                        break;
                    case 15:
                        {
                            for (int first = races[race - 1]; first < races[race]; first++)
                            {
                                //Preparation period

                                //Base 1 period
                                if (first == races[race - 1])
                                {

                                    nedelja.UpdateIntoDAL(2, first);
                                }
                                //Base 2 period
                                else if ((first == races[race - 1] + 1) || (first == races[race - 1] + 2) || (first == races[race - 1] + 3))
                                {

                                    nedelja.UpdateIntoDAL(3, first);
                                }
                                //Base 3 period
                                else if ((first == races[race - 1] + 4) || (first == races[race - 1] + 5) || (first == races[race - 1] + 6))
                                {

                                    nedelja.UpdateIntoDAL(4, first);
                                }
                                //Build 1 period
                                else if ((first == races[race - 1] + 7) || (first == races[race - 1] + 8) || (first == races[race - 1] + 9))
                                {

                                    nedelja.UpdateIntoDAL(5, first);
                                }
                                //Build 2 period
                                else if ((first == races[race - 1] + 10) || (first == races[race - 1] + 11) || (first == races[race - 1] + 12))
                                {

                                    nedelja.UpdateIntoDAL(6, first);
                                }
                                //Peak
                                else if ((first == races[race - 1] + 13) || (first == races[race - 1] + 14))
                                {

                                    nedelja.UpdateIntoDAL(7, first);
                                }
                            }
                        }
                        break;
                    case 14:
                        {
                            for (int first = races[race - 1]; first < races[race]; first++)
                            {
                                //Preparation period

                                //Base 1 period

                                //Base 2 period
                                if ((first == races[race - 1]) || (first == races[race - 1] + 1) || (first == races[race - 1] + 2))
                                {

                                    nedelja.UpdateIntoDAL(3, first);
                                }
                                //Base 3 period
                                else if ((first == races[race - 1] + 3) || (first == races[race - 1] + 4) || (first == races[race - 1] + 5))
                                {

                                    nedelja.UpdateIntoDAL(4, first);
                                }
                                //Build 1 period
                                else if ((first == races[race - 1] + 6) || (first == races[race - 1] + 7) || (first == races[race - 1] + 8))
                                {

                                    nedelja.UpdateIntoDAL(5, first);
                                }
                                //Build 2 period
                                else if ((first == races[race - 1] + 9) || (first == races[race - 1] + 10) || (first == races[race - 1] + 11))
                                {

                                    nedelja.UpdateIntoDAL(6, first);
                                }
                                //Peak
                                else if ((first == races[race - 1] + 12) || (first == races[race - 1] + 13))
                                {

                                    nedelja.UpdateIntoDAL(7, first);
                                }
                            }
                        }
                        break;
                    case 13:
                        {
                            for (int first = races[race - 1]; first < races[race]; first++)
                            {
                                //Preparation period

                                //Base 1 period

                                //Base 2 period
                                if ((first == races[race - 1]) || (first == races[race - 1] + 1) || (first == races[race - 1] + 2))
                                {

                                    nedelja.UpdateIntoDAL(3, first);
                                }
                                //Base 3 period
                                else if ((first == races[race - 1] + 3) || (first == races[race - 1] + 4) || (first == races[race - 1] + 5))
                                {

                                    nedelja.UpdateIntoDAL(4, first);
                                }
                                //Build 1 period
                                else if ((first == races[race - 1] + 6) || (first == races[race - 1] + 7) || (first == races[race - 1] + 8))
                                {

                                    nedelja.UpdateIntoDAL(5, first);
                                }
                                //Build 2 period
                                else if ((first == races[race - 1] + 9) || (first == races[race - 1] + 10) || (first == races[race - 1] + 11))
                                {

                                    nedelja.UpdateIntoDAL(6, first);
                                }
                                //Peak
                                else if ((first == races[race - 1] + 12))
                                {

                                    nedelja.UpdateIntoDAL(7, first);
                                }
                            }
                        }
                        break;
                    case 12:
                        {
                            for (int first = races[race - 1]; first < races[race]; first++)
                            {
                                //Preparation period

                                //Base 1 period

                                //Base 2 period
                                if ((first == races[race - 1]) || (first == races[race - 1] + 1))
                                {

                                    nedelja.UpdateIntoDAL(3, first);
                                }
                                //Base 3 period
                                else if ((first == races[race - 1] + 2) || (first == races[race - 1] + 3) || (first == races[race - 1] + 4))
                                {

                                    nedelja.UpdateIntoDAL(4, first);
                                }
                                //Build 1 period
                                else if ((first == races[race - 1] + 5) || (first == races[race - 1] + 6) || (first == races[race - 1] + 7))
                                {

                                    nedelja.UpdateIntoDAL(5, first);
                                }
                                //Build 2 period
                                else if ((first == races[race - 1] + 8) || (first == races[race - 1] + 9) || (first == races[race - 1] + 10))
                                {

                                    nedelja.UpdateIntoDAL(6, first);
                                }
                                //Peak
                                else if ((first == races[race - 1] + 11))
                                {

                                    nedelja.UpdateIntoDAL(7, first);
                                }
                            }
                        }
                        break;
                    case 11:
                        {
                            for (int first = races[race - 1]; first < races[race]; first++)
                            {
                                //Preparation period

                                //Base 1 period

                                //Base 2 period
                                if ((first == races[race - 1]) || (first == races[race - 1] + 1))
                                {

                                    nedelja.UpdateIntoDAL(3, first);
                                }
                                //Base 3 period
                                else if ((first == races[race - 1] + 2) || (first == races[race - 1] + 3))
                                {

                                    nedelja.UpdateIntoDAL(4, first);
                                }
                                //Build 1 period
                                else if ((first == races[race - 1] + 4) || (first == races[race - 1] + 5) || (first == races[race - 1] + 6))
                                {

                                    nedelja.UpdateIntoDAL(5, first);
                                }
                                //Build 2 period
                                else if ((first == races[race - 1] + 7) || (first == races[race - 1] + 8) || (first == races[race - 1] + 9))
                                {

                                    nedelja.UpdateIntoDAL(6, first);
                                }
                                //Peak
                                else if ((first == races[race - 1] + 10))
                                {

                                    nedelja.UpdateIntoDAL(7, first);
                                }
                            }
                        }
                        break;
                    case 10:
                        {
                            for (int first = races[race - 1]; first < races[race]; first++)
                            {
                                //Preparation period

                                //Base 1 period

                                //Base 2 period
                                if (first == races[race - 1])
                                {

                                    nedelja.UpdateIntoDAL(3, first);
                                }
                                //Base 3 period
                                else if ((first == races[race - 1] + 1) || (first == races[race - 1] + 2))
                                {

                                    nedelja.UpdateIntoDAL(4, first);
                                }
                                //Build 1 period
                                else if ((first == races[race - 1] + 3) || (first == races[race - 1] + 4) || (first == races[race - 1] + 5))
                                {

                                    nedelja.UpdateIntoDAL(5, first);
                                }
                                //Build 2 period
                                else if ((first == races[race - 1] + 6) || (first == races[race - 1] + 7) || (first == races[race - 1] + 8))
                                {

                                    nedelja.UpdateIntoDAL(6, first);
                                }
                                //Peak
                                else if ((first == races[race - 1] + 9))
                                {

                                    nedelja.UpdateIntoDAL(7, first);
                                }
                            }
                        }
                        break;
                    case 9:
                        {
                            for (int first = races[race - 1]; first < races[race]; first++)
                            {
                                //Preparation period

                                //Base 1 period

                                //Base 2 period

                                //Base 3 period
                                if ((first == races[race - 1]) || (first == races[race - 1] + 1))
                                {

                                    nedelja.UpdateIntoDAL(4, first);
                                }
                                //Build 1 period
                                else if ((first == races[race - 1] + 2) || (first == races[race - 1] + 3) || (first == races[race - 1] + 4))
                                {

                                    nedelja.UpdateIntoDAL(5, first);
                                }
                                //Build 2 period
                                else if ((first == races[race - 1] + 5) || (first == races[race - 1] + 6) || (first == races[race - 1] + 7))
                                {

                                    nedelja.UpdateIntoDAL(6, first);
                                }
                                //Peak
                                else if ((first == races[race - 1] + 8))
                                {

                                    nedelja.UpdateIntoDAL(7, first);
                                }
                            }
                        }
                        break;
                    case 8:
                        {
                            for (int first = races[race - 1]; first < races[race]; first++)
                            {
                                //Preparation period

                                //Base 1 period

                                //Base 2 period

                                //Base 3 period
                                if (first == races[race - 1])
                                {

                                    nedelja.UpdateIntoDAL(4, first);
                                }
                                //Build 1 period
                                else if ((first == races[race - 1] + 1) || (first == races[race - 1] + 2) || (first == races[race - 1] + 3))
                                {

                                    nedelja.UpdateIntoDAL(5, first);
                                }
                                //Build 2 period
                                else if ((first == races[race - 1] + 4) || (first == races[race - 1] + 5) || (first == races[race - 1] + 6))
                                {

                                    nedelja.UpdateIntoDAL(6, first);
                                }
                                //Peak
                                else if ((first == races[race - 1] + 7))
                                {

                                    nedelja.UpdateIntoDAL(7, first);
                                }
                            }
                        }
                        break;
                    case 7:
                        {
                            for (int first = races[race - 1]; first < races[race]; first++)
                            {
                                //Preparation period

                                //Base 1 period

                                //Base 2 period

                                //Base 3 period

                                //Build 1 period
                                if ((first == races[race - 1]) || (first == races[race - 1] + 1) || (first == races[race - 1] + 2))
                                {

                                    nedelja.UpdateIntoDAL(5, first);
                                }
                                //Build 2 period
                                else if ((first == races[race - 1] + 3) || (first == races[race - 1] + 4) || (first == races[race - 1] + 5))
                                {

                                    nedelja.UpdateIntoDAL(6, first);
                                }
                                //Peak
                                else if ((first == races[race - 1] + 6))
                                {

                                    nedelja.UpdateIntoDAL(7, first);
                                }
                            }
                        }
                        break;
                    case 6:
                        {
                            for (int first = races[race - 1]; first < races[race]; first++)
                            {
                                //Preparation period

                                //Base 1 period

                                //Base 2 period

                                //Base 3 period

                                //Build 1 period
                                if ((first == races[race - 1]) || (first == races[race - 1] + 1))
                                {

                                    nedelja.UpdateIntoDAL(5, first);
                                }
                                //Build 2 period
                                else if ((first == races[race - 1] + 2) || (first == races[race - 1] + 3) || (first == races[race - 1] + 4))
                                {

                                    nedelja.UpdateIntoDAL(6, first);
                                }
                                //Peak
                                else if ((first == races[race - 1] + 5))
                                {

                                    nedelja.UpdateIntoDAL(7, first);
                                }
                            }
                        }
                        break;
                    case 5:
                        {
                            for (int first = races[race - 1]; first < races[race]; first++)
                            {
                                //Preparation period

                                //Base 1 period

                                //Base 2 period

                                //Base 3 period

                                //Build 1 period
                                if (first == races[race - 1])
                                {

                                    nedelja.UpdateIntoDAL(5, first);
                                }
                                //Build 2 period
                                else if ((first == races[race - 1] + 1) || (first == races[race - 1] + 2) || (first == races[race - 1] + 3))
                                {

                                    nedelja.UpdateIntoDAL(6, first);
                                }
                                //Peak
                                else if ((first == races[race - 1] + 4))
                                {

                                    nedelja.UpdateIntoDAL(7, first);
                                }
                            }
                        }
                        break;
                    case 4:
                        {
                            for (int first = races[race - 1]; first < races[race]; first++)
                            {
                                //Preparation period

                                //Base 1 period

                                //Base 2 period

                                //Base 3 period

                                //Build 1 period

                                //Build 2 period
                                if ((first == races[race - 1]) || (first == races[race - 1] + 1) || (first == races[race - 1] + 2))
                                {

                                    nedelja.UpdateIntoDAL(6, first);
                                }
                                //Peak
                                else if ((first == races[race - 1] + 3))
                                {

                                    nedelja.UpdateIntoDAL(7, first);
                                }
                            }
                        }
                        break;
                    case 3:
                        {
                            for (int first = races[race - 1]; first < races[race]; first++)
                            {
                                //Preparation period

                                //Base 1 period

                                //Base 2 period

                                //Base 3 period

                                //Build 1 period

                                //Build 2 period
                                if ((first == races[race - 1]) || (first == races[race - 1] + 1))
                                {

                                    nedelja.UpdateIntoDAL(6, first);
                                }
                                //Peak
                                else if ((first == races[race - 1] + 2))
                                {

                                    nedelja.UpdateIntoDAL(7, first);
                                }
                            }
                        }
                        break;
                    case 2:
                        {
                            for (int first = races[race - 1]; first < races[race]; first++)
                            {
                                //Preparation period

                                //Base 1 period

                                //Base 2 period

                                //Base 3 period

                                //Build 1 period

                                //Build 2 period
                                if (first == races[race - 1])
                                {

                                    nedelja.UpdateIntoDAL(6, first);
                                }
                                //Peak
                                else if ((first == races[race - 1] + 1))
                                {

                                    nedelja.UpdateIntoDAL(7, first);
                                }
                            }
                        }
                        break;
                    case 1:
                        {
                            for (int first = races[race - 1]; first < races[race]; first++)
                            {
                                //Preparation period

                                //Base 1 period

                                //Base 2 period

                                //Base 3 period

                                //Build 1 period

                                //Build 2 period

                                //Peak
                                if (first == races[race - 1])
                                {
                                    nedelja.UpdateIntoDAL(7, first);
                                }
                            }
                        }
                        break;
                    case 0:
                        //Prekasno je za pripremu trke MsgBox 
                        break;
                    default:
                        //Prerano je za start pripremnog perioda MsgBox
                        break;
                }
            }
        }
    }
}
