namespace ThirdProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Duration D1 = new Duration(1, 10, 15);
            Console.WriteLine(D1.ToString());

            D1 = new Duration(3600);
            Console.WriteLine(D1.ToString());

            Duration D2 = new Duration(7800);
            Console.WriteLine(D2.ToString()); 

            Duration D3 = new Duration(666);
            Console.WriteLine(D3.ToString()); 

            D3 = D1 + D2;
            Console.WriteLine("D3 = D1 + D2 → " + D3);

            D3 = D1 + 7800;
            Console.WriteLine("D3 = D1 + 7800 → " + D3);

            D3 = 666 + D3;
            Console.WriteLine("D3 = 666 + D3 → " + D3);

            D3 = ++D1;
            Console.WriteLine("++D1 → " + D3);

            D3 = --D2;
            Console.WriteLine("--D2 → " + D3);

            D1 = D1 - D2;
            Console.WriteLine("D1 = D1 - D2 → " + D1);

            if (D1 > D2)
                Console.WriteLine("D1 > D2");
            if (D1 <= D2)
                Console.WriteLine("D1 <= D2");

            if (D1)
                Console.WriteLine("D1 is not zero");
            else
                Console.WriteLine("D1 is zero");

            DateTime timeObj = (DateTime)D1;
            Console.WriteLine("DateTime object: " + timeObj.ToLongTimeString());
        }
    }
}
