using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }
            
            base.CalculateStatistics();
        }
        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }
             
            base.CalculateStudentStatistics(name);
        }

        public override char GetLetterGrade(double averageGrade)
        {
            
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }
            
            int top20 = (int)Math.Ceiling(0.2 * Students.Count);

            List<double> grades = Students.Select(s => s.AverageGrade).ToList();
            grades.OrderBy(g => g);


            if(grades[top20] < averageGrade) return 'A';
            
            if(grades[(2 * top20)] < averageGrade) return 'B';
            
            if(grades[(3 * top20)] < averageGrade) return 'C';
            
            if(grades[(4 * top20)] < averageGrade) return 'D';
            
            return 'F';
        }
    }
}