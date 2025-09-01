using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using static System.Net.Mime.MediaTypeNames;
using static task14_linq2.ListGenerator;

namespace task14_linq2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region LINQ - Element Operators
            #region Question 01
            // 1. Get first Product out of Stock
            var firstOutOfStock = ProductList.Where(p => p.UnitsInStock == 0).FirstOrDefault();
            Console.WriteLine($"First product out of stock: {firstOutOfStock?.ProductName ?? "None"}");
            #endregion
            #region Question 02
            // 2. Return the first product whose Price > 1000, unless there is no match,
            // in which case null is returned.
            var firstExpensiveProduct = ProductList.Where(p => p.UnitPrice > 1000).FirstOrDefault();
            Console.WriteLine($"First product with price > 1000: {firstExpensiveProduct?.ProductName ?? "None"}");
            #endregion
            #region Question 03
            // 3. Retrieve the second number greater than 5 
            int[] Arr01 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var secondNumber = Arr01.Where(x => x > 5).Skip(1).FirstOrDefault();
            Console.WriteLine($"Second number greater than 5: {secondNumber}");
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

            #region LINQ - Set Operators
            #region Question 01
            // 1. Find the unique Category names from Product List
            var uniqueCategories = ProductList.Select(p => p.Category).Distinct();
            foreach (var category in uniqueCategories)
            {
                Console.WriteLine($"Category: {category}");
            }
            #endregion
            #region Question 02
            // 2. Produce a Sequence containing the unique first letter from both product and customer names.
            var uniqueFirstLetters = ProductList.Select(p => p.ProductName[0])
                                        .Union(CustomerList.Select(c => c.CustomerName[0]))
                                        .OrderBy(letter => letter);

            foreach (var letter in uniqueFirstLetters)
            {
                Console.WriteLine($"First letter: {letter}");
            }
            #endregion
            #region Question 03
            // 3. Create one sequence that contains the common first letter from both product and customer names.
            var commonFirstLetters = ProductList.Select(p => p.ProductName[0])
                                            .Intersect(CustomerList.Select(c => c.CustomerName[0]))
                                            .OrderBy(letter => letter);
            foreach (var letter in commonFirstLetters)
            {
                Console.WriteLine($"Common first letter: {letter}");
            }
            #endregion
            #region Question 04
            // 4. Create one sequence that contains the first letters of product names that are not also
            // first letters of customer names.
            var productOnlyFirstLetters = ProductList.Select(p => p.ProductName[0])
                                                .Except(CustomerList.Select(c => c.CustomerName[0]))
                                                .OrderBy(letter => letter);
            foreach (var letter in productOnlyFirstLetters)
            {
                Console.WriteLine($"Product-only first letter: {letter}");
            }
            #endregion
            #region Question 05
            // 5. Create one sequence that contains the last Three Characters in each name of
            // all customers and products, including any duplicates
            var lastThreeChars = ProductList.Select(p => p.ProductName.Length >= 3 ? p.ProductName.Substring(p.ProductName.Length - 3) : p.ProductName)
                        .Concat(CustomerList.Select(c => c.CustomerName.Length >= 3 ? c.CustomerName.Substring(c.CustomerName.Length - 3) : c.CustomerName));
            foreach (var str in lastThreeChars)
            {
                Console.WriteLine($"Last three characters: {str}");
            }
            #endregion
            #endregion

            #region LINQ - Quantifiers
            #region Question 01
            // 1. Determine if any of the words in dictionary_english.txt
            // (Read dictionary_english.txt into Array of String First) contain the substring 'ei'.
            string[] words02 = System.IO.File.ReadAllLines("dictionary_english.txt");
            var containsEi = words02.Any(w => w.Contains("ei"));
            Console.WriteLine($"Any word contains 'ei': {containsEi}");
            #endregion
            #region Question02
            // 2. Return a grouped a list of products only for categories that have at least
            // one product that is out of stock.
            var categoriesWithOutOfStock = from p in ProductList
                                           group p by p.Category into g
                                           where g.Any(p => p.UnitsInStock == 0)
                                           select new
                                           {
                                               Category = g.Key,
                                               Products = g.ToList()
                                           };
            foreach (var category in categoriesWithOutOfStock)
            {
                Console.WriteLine($"Category: {category.Category}");
                foreach (var product in category.Products)
                {
                    Console.WriteLine($"\tProductID: {product.ProductID}, ProductName: {product.ProductName}, UnitsInStock: {product.UnitsInStock}");
                }
            }
            #endregion
            #region Question 03
            // 3. Return a grouped a list of products only for categories that have all of their products in stock.
            var categoriesAllInStock = from p in ProductList
                                       group p by p.Category into g
                                       where g.All(p => p.UnitsInStock > 0)
                                       select new
                                       {
                                           Category = g.Key,
                                           Products = g.ToList()
                                       };
            foreach (var category in categoriesAllInStock)
            {
                Console.WriteLine($"Category: {category.Category}");
                foreach (var product in category.Products)
                {
                    Console.WriteLine($"\tProductID: {product.ProductID}, ProductName: {product.ProductName}, UnitsInStock: {product.UnitsInStock}");
                }
            }
            #endregion
            #endregion

            #region LINQ – Grouping Operators
            #region Question 01
            // 1. Use group by to partition a list of numbers by their remainder when divided by 5
            List<int> numbers = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            var groupedByRemainder = numbers.GroupBy(n => n % 5);

            foreach (var group in groupedByRemainder)
            {
                Console.WriteLine($"Numbers with a remainder of {group.Key} when divided by 5:");
                foreach (var number in group)
                {
                    Console.WriteLine(number);
                }
            }
            #endregion
            #region Question 02
            // 2. Uses group by to partition a list of words by their first letter.
            // Use dictionary_english.txt for Input
            string[] words = System.IO.File.ReadAllLines("dictionary_english.txt");
            var groupedByFirstLetter = words.GroupBy(w => w[0]);

            foreach (var group in groupedByFirstLetter)
            {
                Console.WriteLine($"Words that start with '{group.Key}':");
                foreach (var word in group)
                {
                    Console.WriteLine(word);
                }
            }
            #endregion
            #region Question 03
            // Consider this Array as an Input
            // Use Group By with a custom comparer that matches words that are consists of
            // the same Characters Together
            string[] arr = { "from", "salt", "earn", " last", "near", "form" };
            var groupedByCharacters = arr.GroupBy(word => new string(word.OrderBy(c => c).ToArray()));

            foreach (var group in groupedByCharacters)
            {
                Console.WriteLine($"Words with characters '{group.Key}':");
                foreach (var word in group)
                {
                    Console.WriteLine(word);
                }
                Console.WriteLine("...."); 
            }
            #endregion
            #endregion
        }
    }
}
