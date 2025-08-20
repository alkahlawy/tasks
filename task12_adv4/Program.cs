namespace task12_adv4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>
                {
                    new Book("111", "C# Basics", new string[]{"Mohamed", "Ahmed"}, new DateTime(2020,5,1), 29.99m),
                    new Book("222", "Advanced C#", new string[]{"Alkahlawy"}, new DateTime(2021,3,15), 49.99m)
                };

            Console.WriteLine("=== Using User Defined Delegate ===");
            MyBookDelegate del = new MyBookDelegate(BookFunctions.GetTitle);
            LibraryEngine.ProcessBooks(books, del);

            Console.WriteLine("\n=== Using Built-in Delegate (Func) ===");
            LibraryEngine.ProcessBooks(books, (Func<Book, string>)BookFunctions.GetAuthors);

            Console.WriteLine("\n=== Using Anonymous Method ===");
            LibraryEngine.ProcessBooks(books, (Func<Book, string>)(delegate (Book b) { return b.ISBN; }));

            Console.WriteLine("\n=== Using Lambda Expression ===");
            LibraryEngine.ProcessBooks(books, (Func<Book, string>)(b => b.PublicationDate.ToShortDateString()));
        }
    }
}
