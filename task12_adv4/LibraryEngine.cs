
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task12_adv4
{
    public delegate string MyBookDelegate(Book b);
    public class LibraryEngine
    {
        public static void ProcessBooks(List<Book> bList, MyBookDelegate fptr)
        {
            foreach (var B in bList) Console.WriteLine(fptr(B));
        }
        public static void ProcessBooks(List<Book> bList, Func<Book, string> fptr)
        {
            foreach (var B in bList) Console.WriteLine(fptr(B));
        }
    }
}
