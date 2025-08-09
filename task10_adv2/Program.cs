using System.Collections;

namespace task10_adv2
{
    internal class Program
    {
        // Question 01 Function
        static void ReverseArrayList(ArrayList list)
        {
            int left = 0;
            int right = list.Count - 1;

            while (left < right)
            {
                (list[right], list[left]) = (list[left], list[right]);
                left++;
                right--;
            }
        }

        // Question 02 Function
        static List<int> GetEvenNumbers(List<int> numbers)
        {
            List<int> evens = new List<int>();

            foreach (int num in numbers)
            {
                if (num % 2 == 0)
                {
                    evens.Add(num);
                }
            }

            return evens;
        }

        // Question 06 Function
        static int[] RemoveDuplicates(int[] arr)
        {
            List<int> result = new List<int>();
            HashSet<int> seen = new HashSet<int>();

            foreach (int num in arr)
            {
                if (!seen.Contains(num))
                {
                    seen.Add(num);
                    result.Add(num);
                }
            }

            return result.ToArray();
        }

        // Question 07 Function
        static void RemoveOddNumbers(ArrayList list)
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                if ((int)list[i] % 2 == 0)
                {
                    continue;
                }
                list.RemoveAt(i);
            }
        }
        static void Main(string[] args)
        {
            #region Question 01
            ArrayList myList = new ArrayList() { 1, 2, 3, 4, 5 };

            Console.WriteLine("Original ArrayList:");
            foreach (var item in myList)
                Console.Write(item + " ");
            Console.WriteLine();
            Console.WriteLine("==============================");

            ReverseArrayList(myList);

            Console.WriteLine("Reversed ArrayList:");
            foreach (var item in myList)
                Console.Write(item + " ");
            Console.WriteLine();
            Console.WriteLine("================================");
            #endregion

            #region Question 02
            List<int> nums = new List<int>() { 1, 2, 3, 4, 5, 6 };

            List<int> evenNums = GetEvenNumbers(nums);

            Console.WriteLine("Even numbers:");
            foreach (int num in evenNums)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
            Console.WriteLine("=============================");
            #endregion

            #region Question 03
            try
            {
                FixedSizeList<int> list = new FixedSizeList<int>(3);

                list.Add(10);
                list.Add(20);
                list.Add(30);

                Console.WriteLine("Element at index 1: " + list.Get(1));

                // Trying to exceed capacity
                list.Add(40);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            try
            {
                FixedSizeList<string> names = new FixedSizeList<string>(2);
                names.Add("Mohamed");
                names.Add("Alkahlawy");

                Console.WriteLine(names.Get(5)); // Invalid index
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            #endregion
            #region Question 04
            string[] firstLine = Console.ReadLine().Split();
            int n01 = int.Parse(firstLine[0]);
            int q = int.Parse(firstLine[1]);

            int[] arr01 = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            for (int i = 0; i < q; i++)
            {
                int x = int.Parse(Console.ReadLine());
                int count = 0;

                for (int j = 0; j < n01; j++)
                {
                    if (arr01[j] > x)
                        count++;
                }

                Console.WriteLine($"Count: {count}");
            }
            #endregion
            #region Question 05
            int n02 = int.Parse(Console.ReadLine());
            int[] arr02 = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            bool isPalindrome = true;

            for (int i = 0; i < n02 / 2; i++)
            {
                if (arr02[i] != arr02[n02 - i - 1])
                {
                    isPalindrome = false;
                    break;
                }
            }

            Console.WriteLine(isPalindrome ? "YES" : "NO");
            #endregion
            #region Question 06
            int[] arr03 = { 1, 2, 2, 3, 4, 3, 5, 1 };
                int[] uniqueArr = RemoveDuplicates(arr03);

                Console.WriteLine("Array without duplicates:");
                Console.WriteLine(string.Join(" ", uniqueArr));
            #endregion
            #region Question 07
                ArrayList numbers = new ArrayList() { 1, 2, 3, 4, 5, 6, 7, 8 };

                Console.WriteLine("Original ArrayList:");
                foreach (var num in numbers)
                    Console.Write(num + " ");
                Console.WriteLine();

                RemoveOddNumbers(numbers);

                Console.WriteLine("After removing odd numbers:");
                foreach (var num in numbers)
                    Console.Write(num + " ");
            #endregion
        }
    }
}
