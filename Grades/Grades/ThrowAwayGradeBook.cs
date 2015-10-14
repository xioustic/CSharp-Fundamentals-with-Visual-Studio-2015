using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class ThrowAwayGradeBook : GradeBook
    {
        public override GradeStatistics ComputeStatistics()
        {
            if (grades.Count() > 1)
            {
                float lowest = float.MaxValue;
                foreach (float grade in grades)
                {
                    lowest = Math.Min(grade, lowest);
                }
                grades.Remove(lowest);
            }

            return base.ComputeStatistics();
        }
    }
}
