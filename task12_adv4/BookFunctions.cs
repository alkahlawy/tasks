using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task12_adv4
{
    public class BookFunctions
    {
        public static string GetTitle(Book B)
        {
            return B.Title;
        }

        public static string GetAuthors(Book B)
        {
            return string.Join(", ", B.Authors);
        }

        public static string GetPrice(Book B)
        {
            return B.Price.ToString("C");
        }

        public static string GetISBN(Book B)
        {
            return B.ISBN;
        }

        public static string GetPublicationDate(Book B)
        {
            return B.PublicationDate.ToShortDateString();
        }
    }
}
