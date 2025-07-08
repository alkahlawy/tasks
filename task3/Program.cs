namespace task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Question1
            // 6- Write a program that allows the user to insert an integer then
            // print all numbers between 1 to that number.
            Console.WriteLine("Please enter a number: ");
            bool isValidNumber = int.TryParse(Console.ReadLine(), out int number);
            if (isValidNumber && number > 0)
            {
                for (int i = 1; i <= number; i++)
                {
                    Console.Write($"{i}, ");
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
            #endregion

            #region Question2
            // 7- Write a program that allows the user to insert an integer then 
            // print a multiplication table up to 12.
            Console.WriteLine("Please enter a number: ");
            bool isValidNum = int.TryParse(Console.ReadLine(), out int num);
            if (isValidNum && num > 0)
            {
                for (int i = 1; i <= 12; i++)
                {
                    Console.Write($"{i * num} ");
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
            #endregion
            #region Question3
            // 8- Write a program that allows to user to insert number then print all even
            // numbers between 1 to this number
            Console.WriteLine("Please enter a number: ");
            bool isValidInput = int.TryParse(Console.ReadLine(), out int input);
            if (isValidInput && input > 0)
            {

                for (int i = 1; i <= input; i++)
                {
                    if (i % 2 == 0)
                    {
                        Console.Write($"{i} ");
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
            #endregion
            #region Question4
            // 9- Write a program that takes two integers then prints the power.
            Console.WriteLine("Please enter num1: ");
            bool isValidNum1 = int.TryParse(Console.ReadLine(), out int num1);
            Console.WriteLine("Please enter num2: ");
            bool isValidNum2 = int.TryParse(Console.ReadLine(), out int num2);
            if (isValidNum1 && isValidNum2)
            {
                double result = 1;
                if (num1 == 0 && num2 == 0)
                {
                    Console.WriteLine("= 1");
                }
                else
                {
                    for (int i = 1; i <= num2; i++)
                    {
                        result *= num1;
                    }
                    Console.WriteLine($"result is {result}");
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
            #endregion
            #region Question5
            // 10- Write a program to enter marks of five subjects and calculate total,
            // average and percentage.
            int numOfSubjects = 5;
            int[] marks = new int[numOfSubjects];
            double total = 0.0;

            for (int i = 0; i < numOfSubjects; i++)
            {
                Console.Write($"Enter marks for subject {i + 1}: ");
                bool isValidMark = int.TryParse(Console.ReadLine(), out marks[i]);
                if (!isValidMark || marks[i] < 0 || marks[i] > 100)
                {
                    Console.WriteLine("Invalid input. Please enter a valid non-negative number and equal or less than 100.");
                    i--; // repeat the iteration for the invalid input
                }
                else
                {
                    total += marks[i];
                }
            }

            double avg = total / numOfSubjects;
            double percentage = (total / (numOfSubjects * 100)) * 100;

            Console.WriteLine($"Total Marks: {total}");
            Console.WriteLine($"Average Marks: {avg}");
            Console.WriteLine($"Percentage: {percentage}%");
            #endregion
            #region Question6
            // 11- Write a program to input the month number and print the number of days in that month.
            Console.Write("Enter month number (1-12): ");
            bool isValidMonth = int.TryParse(Console.ReadLine(), out int monthNumber);

            if (isValidMonth && monthNumber >= 1 && monthNumber <= 12)
            {
                int daysInMonth = 0;

                switch (monthNumber)
                {
                    case 1: goto case 12;
                    case 3: goto case 12;
                    case 5: goto case 12;
                    case 7: goto case 12;
                    case 8: goto case 12;
                    case 10: goto case 12;
                    case 12:
                        daysInMonth = 31;
                        break;
                    case 4: goto case 11;
                    case 6: goto case 11;
                    case 9: goto case 11;
                    case 11:
                        daysInMonth = 30;
                        break;
                    case 2:
                        daysInMonth = 28;
                        break;
                }

                Console.WriteLine($"Number of days in month {monthNumber}: {daysInMonth}");
            }
            else
            {
                Console.WriteLine("Invalid month number. Please enter a number between 1 and 12.");
            }
            #endregion
            #region Question7
            // 12- Write a program to create a Simple Calculator.

            Console.Write("Enter first number: ");
            bool isValidNumber1 = double.TryParse(Console.ReadLine(), out double number1);

            Console.Write("Enter second number: ");
            bool isValidNumber2 = double.TryParse(Console.ReadLine(), out double number2);

            if (isValidNumber1 && isValidNumber2)
            {
                Console.Write("Enter operator (+, -, *, /): ");
                string? op = Console.ReadLine();
                double opResult = 0.0;
                bool validOperation = true;

                switch (op)
                {
                    case "+":
                        opResult = number1 + number2;
                        break;
                    case "-":
                        opResult = number1 - number2;
                        break;
                    case "*":
                        opResult = number1 * number2;
                        break;
                    case "/":
                        if (number2 != 0)
                        {
                            opResult = number1 / number2;
                        }
                        else
                        {
                            Console.WriteLine("Error: Division by zero is not allowed.");
                            validOperation = false;
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid operator.");
                        validOperation = false;
                        break;
                }

                if (validOperation)
                {
                    Console.WriteLine($"Result: {opResult}");
                }
            }
            else
            {
                Console.WriteLine("Invalid number input.");
            }
            #endregion
            #region Question8
            // 13- Write a program to allow the user to enter a string and print the REVERSE of it.

            Console.Write("Enter a string: ");
            string inputString = Console.ReadLine();

            string reversed = "";

            for (int i = (inputString.Length - 1); i >= 0; i--)
            {
                reversed += inputString[i];
            }

            Console.WriteLine($"Reversed string: {reversed}");
            #endregion
            #region Question9
            // 14- Write a program to allow the user to enter an int and print the REVERSED of it.

            Console.Write("Enter an integer: ");
            bool isValidNumbers = int.TryParse(Console.ReadLine(), out int numbers);

            if (isValidNumbers)
            {
                string numStr = numbers.ToString();
                string reversedStr = "";

                if (numStr[0] == '-')
                {
                    reversedStr += "-";
                    numStr = numStr.Substring(1); // remove negative sign
                }

                for (int i = numStr.Length - 1; i >= 0; i--)
                {
                    reversedStr += numStr[i];
                }

                Console.WriteLine($"Reversed integer: {reversedStr}");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
            #endregion
            #region Question10
            // 15- Write a program in C# Sharp to find prime numbers within a range of numbers.

            Console.Write("Input starting number of range: ");
            bool isValidStart = int.TryParse(Console.ReadLine(), out int start);

            Console.Write("Input ending number of range: ");
            bool isValidEnd = int.TryParse(Console.ReadLine(), out int end);

            if (isValidStart && isValidEnd && start != end)
            {
                Console.WriteLine($"The prime numbers between {start} and {end} are: ");
                for (int n = start; n <= end; n++)
                {
                    if (n > 1)
                    {
                        bool isPrime = true;
                        for (int i = 2; i <= n / 2; i++)
                        {
                            if (num % i == 0)
                            {
                                isPrime = false;
                                break;
                            }
                        }

                        if (isPrime)
                        {
                            Console.Write($"{n} ");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter valid integers where end >= start.");
            }
            #endregion
            #region Question11
            // 17- Create a program that asks the user to input three points and determines whether they lie on a single straight line.
            // i will not use TryParse here because there are many variables.
            Console.WriteLine("Enter coordinates for point 1:");
            Console.Write("x1: ");
            double x1 = double.Parse(Console.ReadLine());
            Console.Write("y1: ");
            double y1 = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter coordinates for point 2:");
            Console.Write("x2: ");
            double x2 = double.Parse(Console.ReadLine());
            Console.Write("y2: ");
            double y2 = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter coordinates for point 3:");
            Console.Write("x3: ");
            double x3 = double.Parse(Console.ReadLine());
            Console.Write("y3: ");
            double y3 = double.Parse(Console.ReadLine());

            double left = (y2 - y1) * (x3 - x2);
            double right = (y3 - y2) * (x2 - x1);

            if (left == right)
            {
                Console.WriteLine("The points lie on a single straight line.");
            }
            else
            {
                Console.WriteLine("The points do NOT lie on a single straight line.");
            }
            #endregion
            #region Question12
            // 18- Evaluate a worker's efficiency based on the time taken to complete a task.

            Console.Write("Enter time taken by the worker (in hours): ");
            bool isValidTime = double.TryParse(Console.ReadLine(), out double timeTaken);

            if (isValidTime && timeTaken > 0)
            {
                if (timeTaken >= 2 && timeTaken <= 3)
                {
                    Console.WriteLine("Highly efficient worker.");
                }
                else if (timeTaken > 3 && timeTaken <= 4)
                {
                    Console.WriteLine("Worker needs to increase speed.");
                }
                else if (timeTaken > 4 && timeTaken <= 5)
                {
                    Console.WriteLine("Worker will be provided with training to improve speed.");
                }
                else if (timeTaken > 5)
                {
                    Console.WriteLine("Worker has to leave the company.");
                }
                else
                {
                    Console.WriteLine("Excellent! Job done faster than expected.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid positive number for time.");
            }
            #endregion

        }
    }
}