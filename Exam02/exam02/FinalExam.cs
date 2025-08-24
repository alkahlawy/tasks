using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam02
{
    internal class FinalExam : BaseExam
    {
        public FinalExam(TimeSpan timeOfExam, int numberOfQuestions)
            : base(timeOfExam, numberOfQuestions) { }

        public FinalExam(TimeSpan timeOfExam, BaseQuestion[] questions)
            : base(timeOfExam, questions) { }

        public override void ShowExam(double score, double maxScore, TimeSpan timeTaken)
        {
            Console.WriteLine("\n===== Final Exam Results =====");

            for (int i = 0; i < Questions.Length; i++)
            {
                if (Questions[i] == null) continue;

                Console.WriteLine($"\nQuestion {i + 1}: {Questions[i].QuestionHeader}");
                Console.WriteLine($"{Questions[i].QuestionBody}");
                Console.WriteLine($"Mark: {Questions[i].Mark}");

                Console.WriteLine("Options:");
                for (int j = 0; j < Questions[i].AnswerList.Length; j++)
                {
                    string marker = (j == Questions[i].RightAnswerIndex) ? " ✓" : "";
                    Console.WriteLine($"  {j + 1}. {Questions[i].AnswerList[j].AnswerText}{marker}");
                }
            }

            double percentage = maxScore > 0 ? (score / maxScore * 100) : 0;
            Console.WriteLine($"\n===== FINAL GRADE =====");
            Console.WriteLine($"Score: {score}/{maxScore}");
            Console.WriteLine($"Percentage: {percentage:F1}%");
            Console.WriteLine($"Time Taken: {timeTaken.TotalMinutes:F1} minutes ({timeTaken.TotalSeconds:F0} seconds)");
            Console.WriteLine($"Allowed Duration: {TimeOfExam.TotalMinutes} minutes");

            if (timeTaken <= TimeOfExam)
                Console.WriteLine("Completed within time limit!");
            else
                Console.WriteLine("Exceeded time limit!");
        }

        public static FinalExam CreateFinalExam(TimeSpan duration)
        {
            Console.WriteLine("\n=== Creating Final Exam ===");
            Console.Write("How many questions total? ");
            int totalQuestions = int.TryParse(Console.ReadLine(), out int total) && total > 0 ? total : 3;

            var questions = new BaseQuestion[totalQuestions];

            for (int i = 0; i < totalQuestions; i++)
            {
                Console.WriteLine($"\nQuestion {i + 1}:");
                Console.WriteLine("1. MCQ Question");
                Console.WriteLine("2. True/False Question");
                Console.Write("Choose type (1 or 2): ");

                string type = Console.ReadLine() ?? "1";
                if (type == "2")
                    questions[i] = CreateTFQuestion(i + 1);
                else
                    questions[i] = CreateMCQuestion(i + 1);
            }

            return new FinalExam(duration, questions);
        }

        private static MCQuestion CreateMCQuestion(int questionNum)
        {
            Console.WriteLine($"\n--- MCQ Question {questionNum} ---");
            Console.Write("Question header: ");
            string header = Console.ReadLine() ?? $"MCQ Question {questionNum}";

            Console.Write("Question body: ");
            string body = Console.ReadLine() ?? "Choose the correct answer";

            Console.Write("Question mark: ");
            double mark = double.TryParse(Console.ReadLine(), out double m) && m > 0 ? m : 1.0;

            var answers = new Answer[4];
            for (int i = 0; i < 4; i++)
            {
                Console.Write($"Answer {i + 1}: ");
                string answerText = Console.ReadLine() ?? $"Option {i + 1}";
                answers[i] = new Answer(i + 1, answerText);
            }

            Console.Write("Which answer is correct (1-4)? ");
            int correctAnswer = int.TryParse(Console.ReadLine(), out int correct) && correct >= 1 && correct <= 4 ? correct - 1 : 0;

            return new MCQuestion(header, body, mark, answers, correctAnswer);
        }

        private static TFQuestion CreateTFQuestion(int questionNum)
        {
            Console.WriteLine($"\n--- True/False Question {questionNum} ---");
            Console.Write("Question header: ");
            string header = Console.ReadLine() ?? $"T/F Question {questionNum}";

            Console.Write("Question body: ");
            string body = Console.ReadLine() ?? "True or False?";

            Console.Write("Question mark: ");
            double mark = double.TryParse(Console.ReadLine(), out double m) && m > 0 ? m : 1.0;

            Console.Write("Is the answer True or False (T/F)? ");
            string answer = Console.ReadLine()?.ToUpper() ?? "T";
            int correctAnswer = answer.StartsWith("T") ? 0 : 1;

            return new TFQuestion(header, body, mark, correctAnswer);
        }

        public override object Clone()
        {
            var clonedQuestions = new BaseQuestion[Questions.Length];
            for (int i = 0; i < Questions.Length; i++)
            {
                if (Questions[i] != null)
                    clonedQuestions[i] = (BaseQuestion)Questions[i].Clone();
            }
            return new FinalExam(TimeOfExam, clonedQuestions);
        }
    }

}
