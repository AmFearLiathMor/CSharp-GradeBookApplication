using System;
using System.Linq;
using GradeBook.Enums;

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
            if (Students.Count < 5)
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            else
            {
                var bandLimit = Students.Count/5;
                var bandQuery = Students.Where(v => v.AverageGrade >= averageGrade);
                    

                if (bandQuery.Count() <= bandLimit)
                    return 'A';
                else if (bandQuery.Count() <= (bandLimit * 2))
                    return 'B';
                else if (bandQuery.Count() <= (bandLimit * 3))
                    return 'C';
                else if (bandQuery.Count() <= (bandLimit * 4))
                    return 'D';
                else
                    return 'F';
            }
        }
    }


}
