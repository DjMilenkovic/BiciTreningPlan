using BiciTrainingPlanDAL.TestManipulator;
using ProjectDBDataModel.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiciTreningPlanBLL
{
    public class GradedTest
    {
        public List<Test_Ocenjivanja> getDataFromDAL(long ID)
        {
            TestOcenjivanjaManipulator testOcenjivanjaManipulator = new TestOcenjivanjaManipulator(ID);
            var result = testOcenjivanjaManipulator.GetData();
            if (result == null)
            {
                Test_Ocenjivanja test = new Test_Ocenjivanja();
                test.Snaga = 0;
                test.Otkucaji_srca = 0;
                test.Napor = 0;
                result.Add(test);
            }
            return result;
        }

        public void insertIntoDAL(ObservableCollection<Test_Ocenjivanja> tests, long IDBicikliste)
        {
            ObservableCollection<Test_Ocenjivanja> test = addIDandDate(tests, IDBicikliste);
            TestOcenjivanjaManipulator testOcenjivanjaManipulator = new TestOcenjivanjaManipulator();
            foreach(var item in test)
            {
                testOcenjivanjaManipulator.Insert(item);
            }
        }

        private ObservableCollection<Test_Ocenjivanja> addIDandDate(ObservableCollection<Test_Ocenjivanja> tests, long IDBicikliste)
        {
            foreach(var item in tests)
            {
                item.ID_Bicikliste = IDBicikliste;
                item.Datum_testiranja = DateTime.Today;
            }
            return tests;
        }
    }
}
