using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Threading;
using static task13_linq1.ListGenerator;
namespace task13_linq1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region LINQ - Element Operators
            #region Question 01
            // 1. Get first Product out of Stock 
            var result01 = ProductList.Where(p => p.UnitsInStock == 0).FirstOrDefault();
            Console.WriteLine($"first Product out of Stock: {result01}");
            #endregion
            #region Question 02
            // 2. Return the first product whose Price > 1000, unless there is no match,
            // in which case null is returned.
            var result02 = ProductList.Where(p => p.UnitPrice > 1000).FirstOrDefault();
            Console.WriteLine($"first Product whose Price > 1000: {result02}");
            #endregion
            #region Question 03
            // 3. Retrieve the second number greater than 5
            int[] Arr01 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var result03 = Arr01.Where(n => n > 5).Skip(1).FirstOrDefault();
            Console.WriteLine($"second number greater than 5: {result03}");
            #endregion
            #endregion

            #region LINQ - Aggregate Operators
            #region Question 01
            // 1. Uses Count to get the number of odd numbers in the array
            int[] Arr02 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var result04 = Arr02.Count(n => n % 2 == 1);
            Console.WriteLine($"Number of odd numbers: {result04}");
            #endregion
            #region Question 02
            // 2. Return a list of customers and how many orders each has.
            var result05 = CustomerList.Select(c => new
            {
                c.CustomerID,
                OrderCount = c.Orders.Count()
            });
            foreach (var item in result05)
            {
                Console.WriteLine($"CustomerID: {item.CustomerID}, OrderCount: {item.OrderCount}");
            }
            #endregion
            #region Question 03
            // 3. Return a list of categories and how many products each has
            var result06 = from p in ProductList
                           group p by p.Category into g
                           select new
                           {
                               Category = g.Key,
                               ProductCount = g.Count()
                           };
            foreach (var item in result06)
            {
                Console.WriteLine($"Category: {item.Category}, ProductCount: {item.ProductCount}");
            }
            #endregion
            #region Question 04
            // 4.Get the total of the numbers in an array.
            int[] Arr03 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var result07 = Arr03.Sum();
            Console.WriteLine($"Total of the numbers: {result07}");
            #endregion
            #region Question 05
            // 5. Get the total number of characters of all words in dictionary_english.txt
            // (Read dictionary_english.txt into Array of String First).
            string[] words01 = System.IO.File.ReadAllLines("dictionary_english.txt");
            var result08 = words01.Sum(w => w.Length);
            Console.WriteLine($"Total number of characters: {result08}");
            #endregion
            #region Question 06
            // 6. Get the length of the shortest word in dictionary_english.txt
            // (Read dictionary_english.txt into Array of String First).
            var result09 = words01.Min(w => w.Length);
            Console.WriteLine($"Length of the shortest word: {result09}");
            #endregion
            #region Question 07
            // 7. Get the length of the longest word in dictionary_english.txt
            // (Read dictionary_english.txt into Array of String First).
            var result10 = words01.Max(w => w.Length);
            Console.WriteLine($"Length of the longest word: {result10}");
            #endregion
            #region Question 08
            // 8.Get the average length of the words in dictionary_english.txt
            // (Read dictionary_english.txt into Array of String First).
            var result11 = words01.Average(w => w.Length);
            Console.WriteLine($"Average length of the words: {result11}");
            #endregion
            #region Question 09
            // 9. Get the total units in stock for each product category.
            var result12 = from p in ProductList
                           group p by p.Category into g
                           select new
                           {
                               Category = g.Key,
                               TotalUnitsInStock = g.Sum(p => p.UnitsInStock)
                           };
            foreach (var item in result12)
            {
                Console.WriteLine($"Category: {item.Category}, Total Units In Stock: {item.TotalUnitsInStock}");
            }
            #endregion
            #region Question 10
            // 10. Get the cheapest price among each category's products
            var result13 = from p in ProductList
                           group p by p.Category into g
                           select new
                           {
                               Category = g.Key,
                               CheapestPrice = g.Min(p => p.UnitPrice)
                           };
            foreach (var item in result13)
            {
                Console.WriteLine($"Category: {item.Category}, Cheapest Price: {item.CheapestPrice}");
            }
            #endregion
            #region Question 11
            // 11. Get the products with the cheapest price in each category (Use Let)
            var result14 = from p in ProductList
                           group p by p.Category into g
                           let minPrice = g.Min(p => p.UnitPrice)
                           select new
                           {
                               Category = g.Key,
                               CheapestProducts = g.Where(p => p.UnitPrice == minPrice)
                           };
            foreach (var item in result14)
            {
                Console.WriteLine($"Category: {item.Category}");
                foreach (var prod in item.CheapestProducts)
                {
                    Console.WriteLine($"\tProductID: {prod.ProductID}, ProductName: {prod.ProductName}, UnitPrice: {prod.UnitPrice}");
                }
            }
            #endregion
            #region Question 12
            // 12. Get the most expensive price among each category's products.
            var result15 = from p in ProductList
                           group p by p.Category into g
                           select new
                           {
                               Category = g.Key,
                               MostExpensivePrice = g.Max(p => p.UnitPrice)
                           };
            foreach (var item in result15)
            {
                Console.WriteLine($"Category: {item.Category}, Most Expensive Price: {item.MostExpensivePrice}");
            }
            #endregion
            #region Question 13
            // 13. Get the products with the most expensive price in each category.
            var result16 = from p in ProductList
                           group p by p.Category into g
                           let maxPrice = g.Max(p => p.UnitPrice)
                           select new
                           {
                               Category = g.Key,
                               MostExpensiveProducts = g.Where(p => p.UnitPrice == maxPrice)
                           };
            foreach (var item in result16)
            {
                Console.WriteLine($"Category: {item.Category}");
                foreach (var prod in item.MostExpensiveProducts)
                {
                    Console.WriteLine($"\tProductID: {prod.ProductID}, ProductName: {prod.ProductName}, UnitPrice: {prod.UnitPrice}");
                }
            }
            #endregion
            #region Question 14
            // 14. Get the average price of each category's products.
            var result17 = from p in ProductList
                           group p by p.Category into g
                           select new
                           {
                               Category = g.Key,
                               AveragePrice = g.Average(p => p.UnitPrice)
                           };
            foreach (var item in result17)
            {
                Console.WriteLine($"Category: {item.Category}, Average Price: {item.AveragePrice}");
            }
            #endregion
            #endregion

            #region LINQ - Ordering Operators
            #region Question 01
            // 1. Sort a list of products by name
            var sortedByNameList = ProductList.OrderBy(p => p.ProductName);
            Console.WriteLine("Products sorted by name:");
            foreach (var product in sortedByNameList)
            {
                Console.WriteLine(product);
            }
            #endregion
            #region Question 02
            // 2. Uses a custom comparer to do a case-insensitive sort of the
            // words in an array.
            string[] Arr04 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            Array.Sort(Arr04, StringComparer.OrdinalIgnoreCase);
            Console.WriteLine("Words sorted (case-insensitive):");
            foreach (var word in Arr04)
            {
                Console.WriteLine(word);
            }
            #endregion
            #region Question 03
            // 3. Sort a list of products by units in stock from highest to lowest.
            var sortedByUnitsInStockList = ProductList.OrderByDescending(p => p.UnitsInStock);
            Console.WriteLine("Products sorted by units in stock (highest to lowest):");
            foreach (var product in sortedByUnitsInStockList)
            {
                Console.WriteLine(product);
            }
            #endregion
            #region Question 04
            // 4. Sort a list of digits, first by length of their name,
            // and then alphabetically by the name itself.
            string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            Array.Sort(Arr, (x, y) =>
            {
                int result = x.Length.CompareTo(y.Length);
                return result == 0 ? x.CompareTo(y) : result;
            });
            Console.WriteLine("Digits sorted by name length and then alphabetically:");
            foreach (var digit in Arr)
            {
                Console.WriteLine(digit);
            }
            #endregion
            #region Question 05
            // 5. Sort first by-word length and then by a case-insensitive sort
            // of the words in an array.
            string[] Arr05 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            Array.Sort(Arr05, (x, y) =>
            {
                int result = x.Length.CompareTo(y.Length);
                return result == 0 ? StringComparer.OrdinalIgnoreCase.Compare(x, y) : result;
            });
            Console.WriteLine("Words sorted by length and then alphabetically (case-insensitive):");
            foreach (var word in Arr05)
            {
                Console.WriteLine(word);
            }
            #endregion
            #region Question 06
            // 6. Sort a list of products, first by category, and then by unit price,
            // from highest to lowest.
            var sortedByCategoryAndPriceList = ProductList
                .OrderBy(p => p.Category)
                .ThenByDescending(p => p.UnitPrice);
            Console.WriteLine("Products sorted by category and then by unit price (highest to lowest):");
            foreach (var product in sortedByCategoryAndPriceList)
            {
                Console.WriteLine(product);
            }
            #endregion
            #region Question 07
            // 7.Sort first by-word length and then by a case -insensitive descending sort of the words in an array.
            string[] Arr06 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            Array.Sort(Arr06, (x, y) =>
            {
                int result = x.Length.CompareTo(y.Length);
                return result == 0 ? StringComparer.OrdinalIgnoreCase.Compare(y, x) : result;
            });
            Console.WriteLine("Words sorted by length and then alphabetically (case-insensitive, descending):");
            foreach (var word in Arr06)
            {
                Console.WriteLine(word);
            }
            #endregion
            #region Question 08
            // 8.Create a list of all digits in the array whose second letter is 'i' that is reversed from the order in the original array.
            string[] Arr07 = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var result = Arr07.Where(x => x.Length > 1 && x[1] == 'i').Reverse();
            Console.WriteLine("Digits with 'i' as the second letter (reversed):");
            foreach (var digit in result)
            {
                Console.WriteLine(digit);
            }
            #endregion
            #endregion

            #region LINQ – Transformation Operators
            #region Question 01
            // 1. Return a sequence of just the names of a list of products.
            var productNames = ProductList.Select(p => p.ProductName);
            Console.WriteLine("Product Names:");
            foreach (var name in productNames)
            {
                Console.WriteLine(name);
            }
            #endregion
            #region Question 02
            // 2. Produce a sequence of the uppercase and lowercase versions of
            // each word in the original array (Anonymous Types).
            string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };
            var upperLowerWords = words.Select(w => new
            {
                Upper = w.ToUpper(),
                Lower = w.ToLower()
            });
            Console.WriteLine("Uppercase and Lowercase Versions:");
            foreach (var item in upperLowerWords)
            {
                Console.WriteLine($"Upper: {item.Upper}, Lower: {item.Lower}");
            }
            #endregion
            #region Question 03
            // 3. Produce a sequence containing some properties of Products,
            // including UnitPrice which is renamed to Price in the resulting type.
            var productDetails = ProductList.Select(p => new
            {
                p.ProductID,
                p.ProductName,
                p.UnitPrice
            });
            Console.WriteLine("Product Details:");
            foreach (var item in productDetails)
            {
                Console.WriteLine($"ID: {item.ProductID}, Name: {item.ProductName}, Price: {item.UnitPrice}");
            }
            #endregion
            #region Question 04
            // 4. Determine if the value of int in an array matches their position in the array.
            int[] Arr08 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var positionMatches = Arr08.Select((value, index) => new
            {
                Value = value,
                Index = index,
                IsMatch = value == index
            });
            Console.WriteLine("Value and Position Matches:");
            foreach (var item in positionMatches)
            {
                Console.WriteLine($"Value: {item.Value}, Index: {item.Index}, IsMatch: {item.IsMatch}");
            }
            #endregion
            #region Question 05
            // 5. Returns all pairs of numbers from both arrays such that the number
            // from numbersA is less than the number from numbersB.
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };
            var pairs = numbersA.SelectMany(a => numbersB.Where(b => a < b), (a, b) => new { A = a, B = b });
            Console.WriteLine("Pairs (A, B) where A < B:");
            foreach (var pair in pairs)
            {
                Console.WriteLine($"({pair.A}, {pair.B})");
            }
            #endregion
            #region Question 06
            // 6. Select all orders where the order total is less than 500.00.
            var smallOrders = CustomerList.SelectMany(c => c.Orders)
                                          .Where(o => o.Total < 500.00m);
            Console.WriteLine("Orders with Total < 500.00:");
            foreach (var order in smallOrders)
            {
                Console.WriteLine($"OrderID: {order.OrderID}, Total: {order.Total}");
            }
            #endregion
            #region Question 07
            // 7. Select all orders where the order was made in 1998 or later.
            var recentOrders = CustomerList.SelectMany(c => c.Orders)
                                           .Where(o => o.OrderDate.Year >= 1998);
            Console.WriteLine("Orders made in 1998 or later:");
            foreach (var order in recentOrders)
            {
                Console.WriteLine($"OrderID: {order.OrderID}, OrderDate: {order.OrderDate.ToShortDateString()}");
            }
            #endregion
            #endregion
        }
    }
}
