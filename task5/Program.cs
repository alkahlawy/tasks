using Microsoft.VisualBasic;
using System;
using System.Buffers.Text;
using System.ComponentModel;
using System.Data.Common;
using System.Diagnostics.Metrics;
using System.Net;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace task5
{
    internal class Program
    {
        static void IncrementByValue(int number)
        {
            number += 10;
            Console.WriteLine($"Inside IncrementByValue: {number}");
        }

        static void IncrementByReference(ref int number)
        {
            number += 10;
            Console.WriteLine($"Inside IncrementByReference: {number}");
        }

        static void ModifyArrayByValue(int[] numbers)
        {
            numbers[0] = 100;
            numbers = new int[] { 200, 300 };
        }
        static void ModifyArrayByReference(ref int[] numbers)
        {
            numbers[0] = 400; 
            numbers = new int[] { 500, 600 };
        }

        static void SumSubNumbers(int num1, int num2, int num3, int num4, out int sum, out int sub)
        {
            sum = num1 + num2;
            sub = num3 - num4;
        }

        static int SumOfDigits(int number) 
        {
            int sum = 0;
            while (number != 0)
            {
                int digit = number % 10; 
                sum += digit;            
                number /= 10;            
            }
            return sum;
        }

        static bool IsPrime(int number)
        {
            if (number <= 1)
                return false;

            for (int? i = 2; i < number; i++)
            {
                if (number % i == 0)
                    return false; 
            }

            return true; 
        }

        static void MinMaxArray(ref int[] numbers, out int maxNum, out int minNum)
        {
            minNum = numbers.Min();
            maxNum = numbers.Max();
        }

        static int Factorial(int number)
        {
            if (number < 0)
                return 0; 

            int result = 1;

            for (int i = 1; i <= number; i++)
            {
                result *= i;
            }

            return result;
        }

        static string ChangeChar(string input, char newChar, int position = 0)
        {
            char[] chars = input.ToCharArray();

            chars[position] = newChar;

            return new string(chars);
        }
        static void Main(string[] args)
        {
            #region Question 1
            // 1- Explain the difference between passing (Value type
            // parameters) by value and by reference then write a suitable c# example.

            #region Explanation
            // Passing by value
            // When you pass a variable by value, a copy of the variable’s value is sent to the method.
            // Any change to the parameter inside the method does not affect the original variable outside the method.

            // Passing by reference
            //When you pass a variable by reference, you send the address of the variable to the method.
            //The method works with the original variable, not a copy.
            //Any change inside the method affects the original variable outside the method.
            #endregion

            #region Example
            int number = 5;

            Console.WriteLine($"Original number: {number}");

            Console.WriteLine("-------------- Pass By Value ----------------------");
            IncrementByValue(number);
            Console.WriteLine($"After IncrementByValue: {number}");

            Console.WriteLine("-------------- Pass By Reference ----------------------");
            IncrementByReference(ref number);
            Console.WriteLine($"After IncrementByReference: {number}");

            #endregion

            #endregion

            #region Question 2
            // 2- Explain the difference between passing (Reference type
            // parameters) by value and by reference then write a suitable c# example.

            #region Explanation
            // Passing by value
            // You pass a copy of the reference(the address) to the method.
            // Inside the method, you can change the object’s data(because both references point to the same object in memory).
            // But if you reassign the parameter to a new object inside the method, it doesn’t affect the original reference outside.

            // Passing by reference
            // You pass the reference itself by reference — so both the reference and the object it points to can be changed.
            // This means the method can change the contents of the object and 
            // Reassign the reference to a new object and this change will affect the original reference outside the method.
            #endregion

            #region Example
            int[] numbers = { 1, 2, 3 };

            Console.WriteLine($"Before ModifyArrayByValue: {string.Join(", ", numbers)}");
            ModifyArrayByValue(numbers);
            Console.WriteLine($"After ModifyArrayByValue: {string.Join(", ", numbers)}");
            Console.WriteLine();
            Console.WriteLine($"Before ModifyArrayByReference: {string.Join(", ", numbers)}");
            ModifyArrayByReference(ref numbers);
            Console.WriteLine($"After ModifyArrayByReference: {string.Join(", ", numbers)}");
            Console.WriteLine();
            #endregion

            #endregion

            #region Question 3
            bool isValidNum1, isValidNum2, isValidNum3, isValidNum4;
            int n1, n2, n3, n4, sumRes, subRes;
            do
            {
                Console.WriteLine("Enter number 1: ");
                isValidNum1 = int.TryParse(Console.ReadLine(), out n1);
            } while (!isValidNum1);
            do
            {
                Console.WriteLine("Enter number 2: ");
                isValidNum2 = int.TryParse(Console.ReadLine(), out n2);
            } while (!isValidNum2);
            do
            {
                Console.WriteLine("Enter number 3: ");
                isValidNum3 = int.TryParse(Console.ReadLine(), out n3);
            } while (!isValidNum3);
            do
            {
                Console.WriteLine("Enter number 4: ");
                isValidNum4 = int.TryParse(Console.ReadLine(), out n4);
            } while (!isValidNum4);

            SumSubNumbers(n1, n2, n3, n4, out sumRes, out subRes);

            Console.WriteLine($"Sum Result: {sumRes}");
            Console.WriteLine();
            Console.WriteLine($"Sub Result: {subRes}");
            #endregion

            #region Question 4
            // 4- Write a program in C# Sharp to create a function to calculate the sum of
            // the individual digits of a given number.
            bool isValidNum;
            int num;
            do
            {
                Console.Write("Enter a number: ");
                isValidNum = int.TryParse(Console.ReadLine(), out num);
            } while (!isValidNum);

            int result = SumOfDigits(num);
            Console.WriteLine($"The sum of the digits of the number {num} is: {result}");

            #endregion
            #region Question 5
            // 5- Create a function named "IsPrime", which receives an integer number
            // and returns true if it is prime, or false if it is not.

            bool isValidNumber2;
            int number2;
            do
            {
                Console.Write("Enter a number: ");
                isValidNumber2 = int.TryParse(Console.ReadLine(), out number2);
            } while (!isValidNumber2);

            bool result2 = IsPrime(number2);

            if (result2)
                Console.WriteLine($"{number2} is a prime number.");
            else
                Console.WriteLine($"{number2} is not a prime number.");

            #endregion

            #region Question 6
            // 6- Create a function named MinMaxArray, to return the minimum and
            // maximum values stored in an array, using reference parameters
            int[] numbers2 = { 1, 2, 100, 9900, 9, 0193, 902, 0103 };
            int maxNum, minNum;
            MinMaxArray(ref numbers2, out maxNum, out minNum);
            Console.WriteLine($"Minimum: {minNum}");
            Console.WriteLine($"Maximum: {maxNum}");
            #endregion

            #region Question 7
            //7- Create an iterative (non-recursive) function to calculate the factorial
            // of the number specified as parameter
            int res = Factorial(5);
            Console.WriteLine($"Factorial is: {res}");
            #endregion

            #region Question 8 
            // 8- Create a function named "ChangeChar" to modify a letter in a certain
            // position(0 based) of a string, replacing it with a different letter
            Console.Write("Enter a word: ");
            string word = Console.ReadLine();

            Console.Write("Enter position to change (0-based): ");
            int pos = int.Parse(Console.ReadLine());

            Console.Write("Enter new character: ");
            char newChar = Console.ReadLine()[0];

            string newWord = ChangeChar(input: word, newChar: newChar, position: pos);

            Console.WriteLine($"New word: {newWord}");

            #endregion 

        }
    }
}
