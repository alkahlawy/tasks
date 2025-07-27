namespace task7_oop2
{
    internal class Program
    {
        static int ReadInt(string message)
        {
            int value;
            bool valid;
            do
            {
                Console.WriteLine(message);
                string input = Console.ReadLine();
                valid = int.TryParse(input, out value);
                if (!valid)
                {
                    try
                    {
                        value = Convert.ToInt32(input);
                        valid = true;
                    }
                    catch
                    {
                        Console.WriteLine("Invalid input. Try again.");
                    }
                }
            } while (!valid);
            return value;
        }
        static Point3D ReadPointFromUser(string pointName)
        {
            int x = ReadInt($"{pointName} - Enter X:");
            int y = ReadInt($"{pointName} - Enter Y:");
            int z = ReadInt($"{pointName} - Enter Z:");
            return new Point3D(x, y, z);
        }
        static void Main(string[] args)
        {
            #region Question 1,2
            Point3D P01 = new Point3D(10, 10, 10);
            Console.WriteLine(P01.ToString());
            #endregion

            #region Question 3,4
            // Read from the User the Coordinates for 2 points
            // P1, P2 (Check the input using try Pares, Parse, Convert).
            Point3D P1 = ReadPointFromUser("P1");
            Point3D P2 = ReadPointFromUser("P2");
            Console.WriteLine("================= Points is ====================");
            Console.WriteLine($"P1: {P1}");
            Console.WriteLine($"P2: {P2}");
            if (P1 == P2)
                Console.WriteLine("P1 and P2 are equal.");
            else
                Console.WriteLine("P1 and P2 are not equal.");
            // for the part above we must do comparator overloading
            #endregion

            #region Question 5,6
            //Define an array of points and sort this array based on X & Y coordinates.
            Point3D[] points = new Point3D[]
                {
                    new Point3D(5, 3, 1),
                    new Point3D(2, 7, 0),
                    new Point3D(2, 5, 5),
                    new Point3D(10, 1, 9)
                };
            Array.Sort(points);

            Console.WriteLine("\nSorted Points by X then Y:");
            foreach (var pt in points)
            {
                Console.WriteLine(pt);
            }
            // Cloning example
            Point3D clone = (Point3D)P1.Clone();
            Console.WriteLine($"\nCloned P1: {clone}");
            #endregion
        }
    }
}
