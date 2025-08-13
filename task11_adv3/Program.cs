namespace task11_adv3
{
    internal class Program
    {
        // Question 01 Functions 
        static void ReverseQueue<T>(Queue<T> queue)
        {
            Stack<T> stack = new Stack<T>();

            while (queue.Count > 0)
            {
                stack.Push(queue.Dequeue());
            }

            while (stack.Count > 0)
            {
                queue.Enqueue(stack.Pop());
            }
        }

        static void PrintQueue<T>(Queue<T> queue)
        {
            foreach (var item in queue)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        // Question 02 Function
        static bool IsBalanced(string str)
        {
            Stack<char> stack = new Stack<char>();

            foreach (char c in str)
            {

                if (c == '(' || c == '[' || c == '{')
                {
                    stack.Push(c);
                }

                else if (c == ')' || c == ']' || c == '}')
                {
                    if (stack.Count == 0) return false; // No matching opening

                    char top = stack.Pop();
                    if ((c == ')' && top != '(') ||
                        (c == ']' && top != '[') ||
                        (c == '}' && top != '{'))
                    {
                        return false; // Mismatched pair
                    }
                }
            }

            // If stack is empty, parentheses are balanced
            return stack.Count == 0;
        }
        static void Main(string[] args)
        {
            #region Question 01
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            Console.WriteLine("Original Queue:");
            PrintQueue(queue);

            ReverseQueue(queue);

            Console.WriteLine("\nReversed Queue:");
            PrintQueue(queue);
            Console.WriteLine();
            #endregion
            #region Question 02
            string input = "[()]{}";

            if (IsBalanced(input))
                Console.WriteLine("Balanced");
            else
                Console.WriteLine("Not Balanced");
            #endregion
        }
    }
}
