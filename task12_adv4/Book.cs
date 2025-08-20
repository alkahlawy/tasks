using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task12_adv4
{
    public class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string[] Authors { get; set; }
        public DateTime PublicationDate { get; set; }
        public decimal Price { get; set; }

        // Constructor
        public Book(string _ISBN, string _Title, string[] _Authors, DateTime _PublicationDate, decimal _Price)
        {
            ISBN = _ISBN;
            Title = _Title;
            Authors = _Authors;
            PublicationDate = _PublicationDate;
            Price = _Price;
        }

        // Override ToString
        public override string ToString()
        {
            return $"ISBN: {ISBN}, Title: {Title}, Authors: {string.Join(", ", Authors)}, " +
                   $"Publication Date: {PublicationDate.ToShortDateString()}, Price: {Price:C}";
        }
    }
}
