namespace task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Question1
            //19- . Write a program that prints an identity matrix using for loop,
            //in other words takes a value n from the user and shows the identity
            //table of size n * n.
            Console.Write("Enter the size of the identity matrix (n): ");
            bool isValidN = int.TryParse(Console.ReadLine(), out int n);

            if (isValidN)
            {
                Console.WriteLine($"\nIdentity matrix of size {n} x {n}:\n");
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (i == j)
                            Console.Write("1 ");
                        else
                            Console.Write("0 ");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Invalid number.");
            }
            #endregion

            #region Question2
            // 20- Write a program in C# Sharp to find the sum of all elements of the array.
            int[] arr01 = { 1, 2, 3, 4, 5, 6 };
            int sumOfArrayElements = arr01.Sum();
            Console.WriteLine($"the sum of all elements of the array: {sumOfArrayElements}");
            #endregion

            #region Question3
            // 21- Write a program in C# Sharp to merge two arrays of the same size sorted in ascending order.
            int[] arr02 = { 1, 3, 5, 7, 9 };
            int[] arr03 = { 2, 4, 6, 8, 10 };

            int array02Size = arr02.Length;
            int array03Size = arr03.Length;

            int mergedArraySize = array02Size + array03Size;
            int[] mergedArray = new int[mergedArraySize];

            for (int i = 0; i < array02Size; i++)
            {
                mergedArray[i] = arr02[i];
            }

            for (int i = 0; i < array03Size; i++)
            {
                mergedArray[array02Size + i] = arr03[i];
            }

            Array.Sort(mergedArray);

            Console.WriteLine("Merged array in ascending order:");

            for (int i = 0; i < mergedArraySize; i++)
            {
                Console.Write(mergedArray[i] + " ");
            }
            #endregion

            #region Question4
            // 22- Write a program in C# Sharp to count the frequency of each element of an array
            int[] arr04 = { 1, 2, 2, 3, 3, 3, 4, 5, 5, 5, 0, 1, 7, 6, 7, 5 };
            int arr04Size = arr04.Length;
            int[] freq = new int[arr04Size];
            int visited = -1;

            for (int i = 0; i < arr04Size; i++)
            {
                int count = 1;
                for (int j = i + 1; j < arr04Size; j++)
                {
                    if (arr04[i] == arr04[j])
                    {
                        count++;
                        freq[j] = visited;
                    }
                }
                if (freq[i] != visited)
                {
                    freq[i] = count;
                }
            }

            Console.WriteLine("Element => Frequency");
            for (int i = 0; i < arr04Size; i++)
            {
                if (freq[i] != visited)
                {
                    Console.WriteLine("   " + arr04[i] + "    =>    " + freq[i]);
                }
            }
            #endregion

            #region Question5
            // 23- Write a program in C# Sharp to find maximum and minimum element in an array
            int[] arr05 = { 1, 10, 20, 100, 9, 0, -1, 100, 18 };
            int maxNum = arr05.Max();
            int minNum = arr05.Min();
            Console.WriteLine($"Min number is: {minNum} and the max one is: {maxNum}");
            #endregion

            #region Question6
            // 24- Write a program in C# Sharp to find the second largest element in an array.
            int[] arr06 = { 1, 10, 20, 9, 0, -1, 100, 18 };
            int sizeOfArray06 = arr06.Length;
            Array.Sort(arr06);
            Console.WriteLine(arr06[sizeOfArray06 - 2]);
            #endregion

            #region Question7
            // 25-. Consider an Array of Integer values with size N, having values as in this Example
            Console.Write("Enter the size of the array (N): ");
            bool isValidNum = int.TryParse(Console.ReadLine(), out int num);

            if (isValidNum && num > 0)
            {
                int[] arr = new int[num];

                Console.WriteLine("Enter the array elements:");
                for (int i = 0; i < num; i++)
                {
                    arr[i] = int.Parse(Console.ReadLine());
                }

                int maxDistance = 0;

                for (int i = 0; i < num - 1; i++)
                {
                    for (int j = i + 1; j < num; j++)
                    {
                        if (arr[i] == arr[j])
                        {
                            int distance = j - i - 1;
                            if (distance > maxDistance)
                            {
                                maxDistance = distance;
                            }
                        }
                    }
                }

                Console.WriteLine("The longest distance between two equal cells is: " + maxDistance);
            }
            #endregion

            #region Question8
            // 26- Given a list of space separated words, reverse the order of the words.
            Console.Write("Enter a sentence: ");
            string? input = Console.ReadLine();
            string? output = string.Join(" ", input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Reverse());
            Console.WriteLine(output);
            #endregion

            #region Question9
            // 27- Write a program to create two multidimensional arrays of same size.
            // Accept value from user and store them in first array.
            // Now copy all the elements of first array on second array and print second array.
            int[] firstArray = new int[5];
            int[] secondArray = new int[5];

            Console.WriteLine("Enter 5 elements:");
            for (int i = 0; i < 5; i++)
            {
                firstArray[i] = int.Parse(Console.ReadLine());
            }

            Array.Copy(firstArray, secondArray, firstArray.Length);

            Console.WriteLine("Second array:");
            foreach (int number in secondArray)
            {
                Console.Write(number + " ");
            }

            #endregion

            #region Question10
            //28- Write a Program to Print One Dimensional Array in Reverse Order
            Console.Write("Enter the size of the array: ");
            bool isValidSize = int.TryParse(Console.ReadLine(), out int size);

            if (isValidSize && size > 0)
            {
                int[] arr = new int[size];

                Console.WriteLine("Enter the elements of the array:");
                for (int i = 0; i < size; i++)
                {
                    arr[i] = int.Parse(Console.ReadLine());
                }

                Array.Reverse(arr);

                Console.WriteLine("Array in reverse order:");

                foreach (int item in arr)
                {
                    Console.Write(item + " ");
                }
            }

            #endregion
        }
    }
}
