namespace task9_adv
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Question 1
            // The Bubble Sort algorithm has a time complexity of O(n^2) in its worst and average cases,
            // which makes it inefficient for large datasets.
            // How we can optimize the Bubble Sort algorithm 
            // And implement the code of this optimized bubble sort algorithm

            // Optimization Idea: Early Termination
            // During each pass:
            //      We compare adjacent elements and swap them if they're in the wrong order.
            //      If no swaps occur in a full pass, the array is already sorted, and we can exit early.
            //      This avoids unnecessary iterations in already sorted or nearly sorted arrays.

            int[] numbers = {10, 5, 1, 4, 2, 8, 3};
            Console.WriteLine("Before sorting: " + string.Join(", ", numbers));
            Console.WriteLine("======================================");
            Helper<int>.BubbleSort(numbers);
            Console.WriteLine("After sorting: " + string.Join(", ", numbers));
            #endregion

            #region Question 2
            var intRange = new Range<int>(10, 30);
            Console.WriteLine($"Is 20 in range: {intRange.IsInRange(20)}");  
            Console.WriteLine($"Length: {intRange.Length()}");                

            var doubleRange = new Range<double>(5.5, 8.3);
            Console.WriteLine($"Is 4.1 in range: {doubleRange.IsInRange(4.1)}"); 
            Console.WriteLine($"Length: {doubleRange.Length()}");              
            #endregion
        }
    }
}
