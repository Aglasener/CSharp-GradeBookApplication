using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            var count = Students.Count;
            var NumberOfStudentsPerRank = count / 5;
            List<double> OrderedGrades = new List<double>();
            if (count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }

            foreach (var student in Students)
            {
                OrderedGrades.Add(student.AverageGrade);
            }
            OrderedGrades.Sort();

            var GradeForA = OrderedGrades[count - NumberOfStudentsPerRank];
            var GradeForB = OrderedGrades[count - 2 * NumberOfStudentsPerRank];
            var GradeForC = OrderedGrades[count - 3 * NumberOfStudentsPerRank];
            var GradeForD = OrderedGrades[count - 4 * NumberOfStudentsPerRank];



            if (averageGrade >= GradeForA)
            {
                return 'A';
            }
            if (averageGrade >= GradeForB && averageGrade < GradeForA)
            {
                return 'B';
            }
            if (averageGrade >= GradeForC && averageGrade < GradeForB)
                return 'C';
            if (averageGrade >= GradeForD && averageGrade < GradeForC)
                return 'D';
            return 'F';
            

        }
    }

        
    
}
