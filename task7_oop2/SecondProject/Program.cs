namespace SecondProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = 20;
            int y = 5;

            Console.WriteLine($"Add: {Maths.Add(x, y)}");
            Console.WriteLine($"Subtract: {Maths.Subtract(x, y)}");
            Console.WriteLine($"Multiply: {Maths.Multiply(x, y)}");
            Console.WriteLine($"Divide: {Maths.Divide(x, y)}");
        }
    }
}
