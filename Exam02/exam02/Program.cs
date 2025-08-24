namespace exam02
{
    internal class Program
    {
        static Subject CreateSubject()
        {
            Console.WriteLine("=== CREATE SUBJECT ===");
            Console.Write("Enter Subject ID: ");
            int subjectId = int.TryParse(Console.ReadLine(), out int id) && id > 0 ? id : 1;

            Console.Write("Enter Subject Name: ");
            string subjectName = Console.ReadLine() ?? "Default Subject";

            Subject subject = new Subject(subjectId, subjectName);
            Console.WriteLine($"Subject created: {subject}");

            return subject;
        }

        static void PrepareExam(Subject subject)
        {
            Console.WriteLine("\n=== PREPARE EXAM ===");
            Console.WriteLine($"Preparing exam for: {subject.SubjectName}");
            subject.CreateExam();

            Console.WriteLine($"Exam Type: {subject.Exam.GetType().Name}");
            Console.WriteLine($"Duration: {subject.Exam.TimeOfExam.TotalMinutes} minutes");
            Console.WriteLine($"Number of Questions: {subject.Exam.NumberOfQuestions}");
        }

        static void TakeExam(Subject subject)
        {
            Console.WriteLine("\n=== TAKE EXAM ===");
            Console.WriteLine($"Ready to take the {subject.SubjectName} exam?");
            Console.WriteLine("Press any key to start...");
            Console.ReadKey();
            subject.Exam.StartExam();

            Console.WriteLine("\n=== EXAM COMPLETED ===");
            Console.WriteLine("Thank you for taking the exam!");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("===== EXAMINATION SYSTEM =====\n");
            Subject subject = CreateSubject();
            PrepareExam(subject);
            if (subject.Exam != null)
            {
                TakeExam(subject);
            }
            else
            {
                Console.WriteLine("No exam was created. Exiting...");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
