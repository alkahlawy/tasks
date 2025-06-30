using System.ComponentModel;

namespace task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Question1
            // 1 - Write a program that takes a number from the user then print yes if that number can be
            //     divided by 3 and 4 otherwise print no.
            Console.WriteLine("Please enter a number: ");
            bool isValidNumber = int.TryParse(Console.ReadLine(), out int number);
            if (isValidNumber)
            {
                if (number % 3 == 0 && number % 4 == 0)
                {
                    Console.WriteLine("Yes, this number can be divided by 3 and 4.");
                }
                else
                {
                    Console.WriteLine("No, this number can't be divided by 3 and 4.");
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
            }
            #endregion
            #region Question2
            // 2- Write a program that allows the user to insert an integer then print negative
            //    if it is negative number otherwise print positive.
            Console.WriteLine("Please enter a number: ");
            bool isValidInput = int.TryParse(Console.ReadLine(), out int input);
            if (isValidInput)
            {
                if (input < 0)
                {
                    Console.WriteLine("The number you have inserted is Negative.");
                }
                else if (input > 0)
                {
                    Console.WriteLine("The number you have inserted is Positive.");
                }
                else
                {
                    Console.WriteLine("The number you have inserted is Zero.");
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
            }
            #endregion
            #region Question3
            // 3- Write a program that takes 3 integers from the user then prints the max element
            //    and the min element.
            Console.WriteLine("Enter a three numbers to get the max one.");
            Console.WriteLine("Enter the first one: ");
            bool isValidNum1 = int.TryParse(Console.ReadLine(), out int num1);
            Console.WriteLine("Enter the second one: ");
            bool isValidNum2 = int.TryParse(Console.ReadLine(), out int num2);
            Console.WriteLine("Enter the third one: ");
            bool isValidNum3 = int.TryParse(Console.ReadLine(), out int num3);
            if (isValidNum1 && isValidNum2 && isValidNum3)
            {
                if (num1 > num2 && num1 > num3)
                {
                    Console.WriteLine($"The max number is {num1}");
                }
                else if (num2 > num1 && num2 > num3) 
                {
                    Console.WriteLine($"The max number is {num2}");
                }
                else if (num3 > num1 && num3 > num2)
                {
                    Console.WriteLine($"The max number is {num3}");
                } else
                {
                    Console.WriteLine($"You have entered the same number. {num1}");
                }
            } else
            {
                Console.WriteLine("Please enter a valid numbers.");
            } 
            #endregion
            #region Question4
            // 4- Write a program that allows the user to insert an integer number then check
            //    If a number is even or odd.
            Console.WriteLine("Please enter a number: ");
            bool isValidNum = int.TryParse(Console.ReadLine(), out int num);
            if (isValidNum)
            {
                if (num == 0)
                {
                    Console.WriteLine("The number you have entered is Zero.");
                } 
                else if (num % 2 == 0)
                {
                    Console.WriteLine("The number you have entered is Even.");
                } 
                else
                {
                    Console.WriteLine("The number you have entered is Odd.");
                }
            } 
            else
            {
                Console.WriteLine("Please enter a valid number.");
            }
            #endregion
            #region Question5
            // 5- Write a program that takes character from the user then if it is a vowel
            //    chars (a,e,I,o,u) then print (vowel) otherwise print (consonant).
            char[] vowelChars = { 'a', 'e', 'i', 'o', 'u' };
            Console.Write("Please enter a character: ");
            bool isValidChar = char.TryParse(Console.ReadLine(), out char inputChar);
            if (isValidChar)
            {
                inputChar = char.ToLower(inputChar);
                if (vowelChars.Contains(inputChar))
                {
                    Console.WriteLine("The character you have entered is a vowel.");
                }
                else if (char.IsLetter(inputChar))
                {
                    Console.WriteLine("The character you have entered is a consonant.");
                }
                else
                {
                    Console.WriteLine("You entered a character that is not a letter.");
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid single character.");
            }
            #endregion
        }
    }
}
