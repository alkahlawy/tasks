using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam02
{
    internal abstract class BaseQuestion : ICloneable, IComparable<BaseQuestion>
    {
        public string QuestionHeader { get; set; }
        public string QuestionBody { get; set; }
        public double Mark { get; set; }
        public Answer[] AnswerList { get; set; }
        public int RightAnswerIndex { get; set; }

        protected BaseQuestion(string header, string body, double mark)
        {
            QuestionHeader = header ?? "";
            QuestionBody = body ?? "";
            Mark = mark;
            AnswerList = new Answer[0];
            RightAnswerIndex = -1;
        }
        protected BaseQuestion(string header, string body, double mark, Answer[] answers, int rightAnswerIndex)
            : this(header, body, mark)
        {
            AnswerList = answers ?? new Answer[0];
            RightAnswerIndex = rightAnswerIndex;
        }

        public bool CheckAnswer(int chosenIndex) => chosenIndex == RightAnswerIndex;

        public abstract void DisplayQuestion();

        public override string ToString() => $"{QuestionHeader}\n{QuestionBody} (Mark: {Mark})";

        public abstract object Clone();

        public int CompareTo(BaseQuestion? other)
        {
            if (other == null) return 1;
            return Mark.CompareTo(other.Mark);
        }
    }
}

