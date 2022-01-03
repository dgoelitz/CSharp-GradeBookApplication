using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeight) : base(name, isWeight)
        {
            Type = GradeBookType.Ranked;
        }

        string notEnoughStudents = "Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.";

        public override char GetLetterGrade(double averageGrade)
        {
            int totalStudents = Students.Count;
            if (totalStudents < 5) throw new InvalidOperationException("Not enough students to calculate current grade");
            double fifthOfClass = totalStudents / 5;
            int betterThanMe = 0;
            foreach (Student student in Students)
            {
                if (student.AverageGrade > averageGrade) betterThanMe++;
            }
            if (betterThanMe < fifthOfClass) return 'A';
            if (betterThanMe < fifthOfClass * 2) return 'B';
            if (betterThanMe < fifthOfClass * 3) return 'C';
            if (betterThanMe < fifthOfClass * 4) return 'D';
            return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine(notEnoughStudents);
                return;
            }

            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine(notEnoughStudents);
                return;
            }

            base.CalculateStudentStatistics(name);
        }
    }
}
