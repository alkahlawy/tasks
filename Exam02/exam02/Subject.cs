using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam02
{
    internal class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public BaseExam Exam { get; set; }

        public Subject(int subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName ?? "";
        }

        public void CreateExam()
        {
            Console.WriteLine($"\n=== Creating Exam for {SubjectName} ===");
            Console.WriteLine("Choose Exam Type:");
            Console.WriteLine("1. Practical Exam (MCQ only)");
            Console.WriteLine("2. Final Exam (MCQ + True/False)");
            Console.Write("Enter choice (1 or 2): ");

            string choice = Console.ReadLine() ?? "1";
            TimeSpan duration = GetExamDuration();

            switch (choice)
            {
                case "1":
                    Exam = PracticalExam.CreatePracticalExam(duration);
                    break;
                case "2":
                    Exam = FinalExam.CreateFinalExam(duration);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Creating Practical Exam.");
                    Exam = PracticalExam.CreatePracticalExam(duration);
                    break;
            }

            Console.WriteLine("Exam created successfully!");
        }

        private TimeSpan GetExamDuration()
        {
            while (true)
            {
                Console.Write("Enter exam duration in minutes (30-180): ");
                if (int.TryParse(Console.ReadLine(), out int minutes) && minutes >= 30 && minutes <= 180)
                    return TimeSpan.FromMinutes(minutes);
                Console.WriteLine("Invalid duration. Please enter between 30 and 180 minutes.");
            }
        }

        public override string ToString() => $"Subject: {SubjectName} (ID: {SubjectId})";
    }

}
