using static System.Runtime.InteropServices.JavaScript.JSType;

namespace task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Question1
            // 1- Write a program that allows the user to enter a number then print it.
            Console.WriteLine("Please enter a number:");
            bool isValidInput = int.TryParse(Console.ReadLine(), out int input);
            if (isValidInput)
            {
                Console.WriteLine($"You entered: {input}");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
            #endregion
            #region Question2
            // 2- Write C# program that converts a string to an integer,
            //    but the string contains non-numeric characters. And mention what will happen
            string nonNumericString = "123abc";
            int result = int.Parse(nonNumericString);
            Console.WriteLine($"Converted value: {result}");
            // error happens because of converting non-numeric chars
            #endregion
            #region Question3
            // 3- Write C# program that Perform a simple arithmetic operation with floating-point
            //    numbers And mention what will happen
            float num1 = 5.5f;
            float num2 = 2.2f;
            float result = num1 / num2;
            Console.WriteLine($"Result of division: {result}");
            // The result will be a floating-point number, and it will be printed correctly.
            #endregion
            #region Question4
            // 4-	Write C# program that Extract a substring from a given string.
            Console.WriteLine("Please enter a string:");
            string? inputString = Console.ReadLine();
            Console.WriteLine("Please enter the starting index for the substring:");
            bool isValidIndex = int.TryParse(Console.ReadLine(), out int startIndex);
            Console.WriteLine("Please enter the length of the substring:");
            bool isValidLength = int.TryParse(Console.ReadLine(), out int length);
            if (isValidIndex && isValidLength)
            {
                if (startIndex > 0 && length < inputString!.Length)
                {
                    string substring = inputString.Substring(startIndex, length);
                    Console.WriteLine($"Extracted substring: {substring}");
                }
                else
                {
                    Console.WriteLine("Invalid start index or length for the substring.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input for start index or length.");
            }
            #endregion
            #region Question5
            // 5- Write C# program that Assigning one value type variable to another and modifying
            //    the value of one variable and mention what will happen
            int a = 10;
            int b = a; // b is assigned the value of a
            b = 20; // modifying b does not affect a
            Console.WriteLine($"Value of a: {a}, Value of b: {b}");
            // Output: Value of a: 10, Value of b: 20
            #endregion
            #region Question6
            // 6- Write C# program that Assigning one reference type variable to another and modifying the
            //    object through one variable and mention what will happen
            Person person1 = new Person();
            person1.name = "Mohamed";
            Person person2 = person1; // person2 references the same object as person1
            person2.name = "Alkahlawy"; // modifying person2 affects person1
            Console.WriteLine("person1.Name: " + person1.name);
            Console.WriteLine("person2.Name: " + person2.name);
            #endregion
            #region Question7
            // 7- Write C# program that take two string variables and print them as one variable 
            Console.WriteLine("Please enter the first string:");
            string firstString = Console.ReadLine();
            Console.WriteLine("Please enter the second string:");
            string secondString = Console.ReadLine();
            string combinedString = firstString + secondString;
            Console.WriteLine($"Combined string: {combinedString}");
            #endregion
            #region Question8
            // 8- Which of the following statements is correct about the C#.NET code snippet given below?
            int d;
            d = Convert.ToInt32(!(30 < 20));
            //a)	A value 0 will be assigned to d.
            //b)	A value 1 will be assigned to d.
            //c)	A value -1 will be assigned to d.
            //d)	The code reports an error.
            //e)	The code snippet will work correctly if ! is replaced by Not.
            // The expression !(30 < 20) evaluates to true, which is then converted to an integer.
            //// Answer: b) A value 1 will be assigned to d.
            #endregion
            #region Question9
            // 9-	Which of the following is the correct output for the C# code given below?
            Console.WriteLine(13 / 2 + " " + 13 % 2);
            //a)	6.5 1
            //b)	6.5 0
            //c)	6 0
            //d)	6 1
            //e)	6.5 6.5
            // 13 /2 gives 6 (integer division) and 13 % 2 gives 1 (remainder)
            // Answer: d) 6 1
            #endregion
            #region Question10
            //What will be the output of the C# code given below?
            int num = 1, z = 5;
            if (!(num <= 0))
                Console.WriteLine(++num + z++ + " " + ++z);
            else
                Console.WriteLine(--num + z-- + " " + --z);
            //a)	5 6
            //b)	6 5
            //c)	6 6
            //d)	7 7
            //(2 + 5) + " " + 7 => 7 7
            // the output will be: d) 7 7 
            #endregion
        }
    }
}
