using BiciTrainingPlanDAL;
using BiciTrainingPlanDAL.TestManipulator;
using ProjectDBDataModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiciTreningPlanBLL
{
    public class CriticalPowerTest
    {
        public List<Test_Kriticne_Snage> getDataFromDAL(long ID)
        {
            TestKriticneSnageManipulator kriticnaSnagaManipulator = new TestKriticneSnageManipulator(ID);
            var result = kriticnaSnagaManipulator.GetData();
            if (result == null)
            {
                Test_Kriticne_Snage test = new Test_Kriticne_Snage();
                test.CP0 = 0;
                test.CP1 = 0;
                test.CP6 = 0;
                test.CP12 = 0;
                test.CP30 = 0;
                test.CP60 = 0;
                test.CP90 = 0;
                test.CP180 = 0;
                result.Add(test);
            }
            return result;
        }

        public void insertIntoDAL(Test_Kriticne_Snage test)
        {
            TestKriticneSnageManipulator kriticnaSnagaManipulator = new TestKriticneSnageManipulator();
            kriticnaSnagaManipulator.Insert(test);           
        }
    }
}
