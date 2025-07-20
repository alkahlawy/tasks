using Microsoft.VisualBasic;
using System.Data;

namespace task0
{
    internal class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Todo> todos = new List<Todo>();
            Console.WriteLine("Please Enter the number of to-do points: ");
            bool isValidNumber = int.TryParse(Console.ReadLine(), out int number);
            if (isValidNumber && number > 0)
            {
                
                for (int i = 0; i < number; i++)
                {
                    int Id;
                    string repaly;
                    Todo todo = new Todo();
                    do
                    {
                        Console.WriteLine($"Enter unique ID for task {i + 1}: ");
                        Id = int.Parse(Console.ReadLine());
                        if (todos.Any(t => t.Id == Id))
                        {
                            Console.WriteLine("There is already a Task with this ID. Please enter a new one.");
                        }
                    } while (todos.Any(t => t.Id == Id));
                    todo.Id = Id;
                    Console.WriteLine($"Enter task {i + 1} title: ");
                    todo.Title = Console.ReadLine();
                    Console.WriteLine("You want to add a description? (Y or N)");
                    repaly = Console.ReadLine();
                    if (repaly != null)
                    {
                        if (repaly == "Y" ||  repaly == "y")
                        {
                            Console.WriteLine($"Enter task {i + 1} description: ");
                            todo.Description = Console.ReadLine();
                        } else
                        {
                            Console.WriteLine("this task will be created without description.");
                        }
                    } else
                    {
                        todo.Description = string.Empty;
                        Console.WriteLine("You have entered an null value \n YOU WILL BE PUNSHMENT ;)");
                    }
                    todos.Add(todo);
                }
            } else
            {
                Console.WriteLine("invalid number.");
            }
            foreach (var t in todos)
            {
                Console.WriteLine($"ID: {t.Id}, Title: {t.Title}, Description: {t.Description}");
            }
        }
    }
}
