using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    class RankedGradeBook : BaseGradeBook
    {

        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if(Students.Count < 5)
                throw new InvalidOperationException("Ranked grading required 5 or more students");

            var threshold = (int)Math.Ceiling(Students.Count * 0.2); ///20% of the total number of students
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList(); ///Order list descending by AverageGrade

            if (grades[threshold - 1] <= averageGrade)
                return 'A';
            else if (grades[threshold * 2 - 1] <= averageGrade)
                return 'B';
            else if (grades[threshold * 3 - 1] <= averageGrade)
                return 'C';
            else if (grades[threshold * 4 - 1] <= averageGrade)
                return 'D';
            else return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranged grading requires at least 5 students with grades in order to properly calculate a student's overall grade");
                return;
            }
            base.CalculateStatistics();
        }
    }
}
