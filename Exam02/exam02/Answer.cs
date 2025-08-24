using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam02
{
    internal class Answer : ICloneable, IComparable<Answer>
    {
        public int AnswerID { get; }
        public string AnswerText { get; }

        public Answer(int answerID, string answerText)
        {
            if (answerID <= 0) 
                throw new ArgumentException("Answer ID must be greater than zero.");
            if (string.IsNullOrWhiteSpace(answerText)) 
                throw new ArgumentException("Answer text cannot be null or empty.");

            AnswerID = answerID;
            AnswerText = answerText;
        }

        public override string ToString() => $"{AnswerID}. {AnswerText}";
        public object Clone() => new Answer(AnswerID, AnswerText);

        public int CompareTo(Answer? other)
        {
            if (other is null) return 1;
            int byId = AnswerID.CompareTo(other.AnswerID);
            if (byId != 0) return byId;
            return string.Compare(AnswerText, other.AnswerText, StringComparison.Ordinal);
        }
    }
}
