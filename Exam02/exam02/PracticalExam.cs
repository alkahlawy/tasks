using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam02
{
    internal class PracticalExam : BaseExam
    {
        public PracticalExam(TimeSpan timeOfExam, int numberOfQuestions)
            : base(timeOfExam, numberOfQuestions) { }

        public PracticalExam(TimeSpan timeOfExam, MCQuestion[] questions)
            : base(timeOfExam, questions) { }

        public override void ShowExam(double score, double maxScore, TimeSpan timeTaken)
        {
            Console.WriteLine("\n===== Practical Exam Results =====");

            for (int i = 0; i < Questions.Length; i++)
            {
                if (Questions[i] == null) continue;

                Console.WriteLine($"\nQuestion {i + 1}: {Questions[i].QuestionHeader}");
                Console.WriteLine($"{Questions[i].QuestionBody}");

                if (Questions[i].RightAnswerIndex >= 0 && Questions[i].RightAnswerIndex < Questions[i].AnswerList.Length)
                {
                    var correctAnswer = Questions[i].AnswerList[Questions[i].RightAnswerIndex];
                    Console.WriteLine($"✓ Correct Answer: {correctAnswer.AnswerText}");
                }
            }

            double percentage = maxScore > 0 ? (score / maxScore * 100) : 0;
            Console.WriteLine($"\n===== RESULTS =====");
            Console.WriteLine($"Score: {score}/{maxScore} ({percentage:F1}%)");
            Console.WriteLine($"Time Taken: {timeTaken.TotalMinutes:F1} minutes ({timeTaken.TotalSeconds:F0} seconds)");
            Console.WriteLine($"Allowed Duration: {TimeOfExam.TotalMinutes} minutes");

            if (timeTaken <= TimeOfExam)
                Console.WriteLine("Completed within time limit!");
            else
                Console.WriteLine("Exceeded time limit!");
        }

        public static PracticalExam CreatePracticalExam(TimeSpan duration)
        {
            Console.WriteLine("\n=== Creating Practical Exam ===");
            Console.Write("How many MCQ questions? ");
            int numQuestions = int.TryParse(Console.ReadLine(), out int num) && num > 0 ? num : 2;

            var questions = new MCQuestion[numQuestions];

            for (int i = 0; i < numQuestions; i++)
            {
                questions[i] = CreateMCQuestion(i + 1);
            }

            return new PracticalExam(duration, questions);
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

        public override object Clone()
        {
            var clonedQuestions = new BaseQuestion[Questions.Length];
            for (int i = 0; i < Questions.Length; i++)
            {
                if (Questions[i] != null)
                    clonedQuestions[i] = (BaseQuestion)Questions[i].Clone();
            }
            return new PracticalExam(TimeOfExam, (MCQuestion[])clonedQuestions);
        }
    }
}
