using System;
using System.Linq;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name,bool isWeighted) : base(name,isWeighted)
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

        public override void CalculateStatistics()
        {


            if (Students.Count < 5)
            {
                Console.WriteLine(
                    "Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStatistics();

        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5) 
            {
                Console.WriteLine(
                    "Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStudentStatistics(name);
        }
    }


}
