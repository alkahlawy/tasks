using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam02
{
    internal class MCQuestion : BaseQuestion
    {
        public MCQuestion(string header, string body, double mark)
            : base(header, body, mark) { }

        public MCQuestion(string header, string body, double mark, Answer[] answers, int rightAnswerIndex)
            : base(header, body, mark, answers, rightAnswerIndex) { }

        public override void DisplayQuestion()
        {
            Console.WriteLine($"[MCQ] {QuestionHeader}");
            Console.WriteLine($"{QuestionBody}");
            Console.WriteLine($"Mark: {Mark}");
            Console.WriteLine("Choose one answer:");

            for (int i = 0; i < AnswerList.Length; i++)
            {
                Console.WriteLine($"  {i + 1}. {AnswerList[i].AnswerText}");
            }
        }

        public override object Clone()
        {
            var clonedAnswers = new Answer[AnswerList.Length];
            for (int i = 0; i < AnswerList.Length; i++)
            {
                clonedAnswers[i] = (Answer)AnswerList[i].Clone();
            }
            return new MCQuestion(QuestionHeader, QuestionBody, Mark, clonedAnswers, RightAnswerIndex);
        }
    }

}
