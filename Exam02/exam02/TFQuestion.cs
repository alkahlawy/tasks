using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam02
{
    internal class TFQuestion : BaseQuestion
    {
        public TFQuestion(string header, string body, double mark, int rightAnswerIndex)
            : base(header, body, mark, CreateTrueFalseAnswers(), rightAnswerIndex)
        {
        }

        private static Answer[] CreateTrueFalseAnswers()
        {
            return new Answer[]
            {
            new Answer(1, "True"),
            new Answer(2, "False")
            };
        }

        public override void DisplayQuestion()
        {
            Console.WriteLine($"[T/F] {QuestionHeader}");
            Console.WriteLine($"{QuestionBody}");
            Console.WriteLine($"Mark: {Mark}");
            Console.WriteLine("Choose True or False:");
            Console.WriteLine("  1. True");
            Console.WriteLine("  2. False");
        }

        public override object Clone()
        {
            var clonedAnswers = new Answer[AnswerList.Length];
            for (int i = 0; i < AnswerList.Length; i++)
            {
                clonedAnswers[i] = (Answer)AnswerList[i].Clone();
            }
            return new TFQuestion(QuestionHeader, QuestionBody, Mark, RightAnswerIndex);
        }
    }
}
