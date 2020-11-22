using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isweighted) : base(name, isweighted)
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

        public override void CalculateStatistics()
        {
            var count = Students.Count;

            if (count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            else
                base.CalculateStatistics();

            
        }

        public override void CalculateStudentStatistics(string name)
        {

            var count = Students.Count;
            
            if (count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 studentswith grades in order to properly calculate a student's overall grade.");
                return;
            }
            else
                base.CalculateStudentStatistics(name); 
        }

    }

       
    
}
