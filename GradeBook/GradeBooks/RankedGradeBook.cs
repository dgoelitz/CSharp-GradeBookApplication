using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            int totalStudents = Students.Count;
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
    }
}
