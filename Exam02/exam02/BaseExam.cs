using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam02
{
    internal abstract class BaseExam : ICloneable, IComparable<BaseExam>
    {
        public TimeSpan TimeOfExam { get; set; }
        public int NumberOfQuestions { get; set; }
        public BaseQuestion[] Questions { get; set; }

        protected BaseExam(TimeSpan timeOfExam, int numberOfQuestions)
        {
            TimeOfExam = timeOfExam;
            NumberOfQuestions = numberOfQuestions;
            Questions = new BaseQuestion[numberOfQuestions];
        }

        protected BaseExam(TimeSpan timeOfExam, BaseQuestion[] questions)
            : this(timeOfExam, questions?.Length ?? 0)
        {
            Questions = questions ?? new BaseQuestion[0];
            NumberOfQuestions = Questions.Length;
        }

        public void StartExam()
        {
            Console.WriteLine($"\n===== Starting Exam =====");
            Console.WriteLine($"Duration: {TimeOfExam.TotalMinutes} minutes");
            Console.WriteLine($"Questions: {NumberOfQuestions}\n");

            DateTime startTime = DateTime.Now;
            Console.WriteLine($"Exam started at: {startTime:HH:mm:ss}");
            Console.WriteLine();

            double totalScore = 0;
            double maxScore = 0;

            for (int i = 0; i < Questions.Length; i++)
            {
                if (Questions[i] == null) continue;

                Console.WriteLine($"Question {i + 1}:");
                Questions[i].DisplayQuestion();

                Console.Write("Your answer (enter number): ");
                string input = Console.ReadLine() ?? "";

                if (int.TryParse(input, out int answer))
                {
                    int answerIndex = answer - 1;
                    if (Questions[i].CheckAnswer(answerIndex))
                    {
                        totalScore += Questions[i].Mark;
                        Console.WriteLine("Correct!");
                    }
                    else
                    {
                        Console.WriteLine("Wrong!");
                    }
                }

                maxScore += Questions[i].Mark;
                Console.WriteLine();
            }

            DateTime endTime = DateTime.Now;
            TimeSpan timeTaken = endTime - startTime;

            Console.WriteLine($"Exam finished at: {endTime:HH:mm:ss}");
            Console.WriteLine($"Time taken: {timeTaken.TotalMinutes:F1} minutes ({timeTaken.TotalSeconds:F0} seconds)");

            ShowExam(totalScore, maxScore, timeTaken);
        }

        public abstract void ShowExam(double score, double maxScore, TimeSpan timeTaken);

        public override string ToString() => $"Exam | Questions: {NumberOfQuestions} | Duration: {TimeOfExam.TotalMinutes} min";

        public abstract object Clone();

        public int CompareTo(BaseExam? other)
        {
            if (other == null) return 1;
            return TimeOfExam.CompareTo(other.TimeOfExam);
        }
    }
}

