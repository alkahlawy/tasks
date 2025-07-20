using System.Reflection.Emit;

namespace task6_oop1
{
    public enum WeekDays
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }

    public enum Season
    {
        Spring, Summer, Autumn, Winter,
    }

    public enum Colors
    {
        Red, Green, Blue,
    }

    [Flags]
    internal enum Permissions : byte
    {
        None = 0,
        Read = 1,
        Write = 2,
        Delete = 4,
        Execute = 8
    }

    public enum SecurityLevel
    {
        Guest,
        Developer,
        Secretary,
        DBA,
    }



    public struct Person
    {
        public string Name;
        public int Age;
    }

    public struct Point
    {
        public double X;
        public double Y;
    }

    public class HiringDate
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public HiringDate(int day, int month, int year)
        {
            if (!IsValidDate(day, month, year))
                throw new ArgumentException("Invalid hire date.");

            Day = day;
            Month = month;
            Year = year;
        }

        private bool IsValidDate(int day, int month, int year)
        {
            return day >= 1 && day <= 31 &&
                   month >= 1 && month <= 12 &&
                   year >= 1900 && year <= DateTime.Now.Year;
        }

        public override string ToString()
        {
            return $"{Day:D2}/{Month:D2}/{Year}";
        }
    }



    public class Employee
    {
        public int ID { get; set; }

        private string name;
        public string Name
        {
            get => name;
            set => name = !string.IsNullOrWhiteSpace(value) ? value : throw new ArgumentException("Name cannot be empty.");
        }

        public SecurityLevel SecurityLevel { get; set; }

        private decimal salary;
        public decimal Salary
        {
            get => salary;
            set => salary = value >= 6_000 ? value : throw new ArgumentException("Salary cannot be negative.");
        }

        public HiringDate HireDate { get; set; }

        private char gender;
        public char Gender
        {
            get => gender;
            set
            {
                if (value != 'M' && value != 'F')
                    throw new ArgumentException("Gender must be 'M' or 'F'");
                gender = value;
            }
        }

        
        public Employee(int id, string name, SecurityLevel securityLevel, decimal salary, HiringDate hireDate, char gender)
        {
            ID = id;
            Name = name;
            SecurityLevel = securityLevel;
            Salary = salary;
            HireDate = hireDate;
            Gender = gender;
        }

        public override string ToString()
        {
            return $"ID: {ID}, Name: {Name}, Security Level: {SecurityLevel}, " +
                   $"Salary: {string.Format("{0:C}", Salary)}, Hire Date: {HireDate}, Gender: {Gender}";
        }
    }



    internal class Program
    {
        static void Main(string[] args)
        {
            #region Part 01
            #region Question 1
            // Create an enum called "WeekDays" with the days of the week (Monday to Sunday)
            // as its members. Then, write a C# program that prints out all the days of the
            // week using this enum.
            string[] weekDays = Enum.GetNames(typeof(WeekDays));
            Console.WriteLine("Days of the week: ");
            foreach (var day in weekDays)
            {
                Console.WriteLine(day);
            }
            #endregion

            #region Question 2
            // Define a struct "Person" with properties "Name" and "Age".
            // Create an array of three "Person" objects and populate it with data.
            // Then, write a C# program to display the details of all the persons in the array.
            Person[] people01 = new Person[3];
            people01[0] = new Person { Name = "Mohamed", Age = 21 };
            people01[1] = new Person { Name = "Ahmed", Age = 23 };
            people01[2] = new Person { Name = "Radwa", Age = 20 };

            Console.WriteLine("People details: ");
            foreach (Person person in people01)
            {
                Console.WriteLine(person.Name);
                Console.WriteLine(person.Age);
                Console.WriteLine("----------------------");
            }
            #endregion

            #region Question 3
            // Create an enum called "Season" with the four seasons
            // (Spring, Summer, Autumn, Winter) as its members.
            // Write a C# program that takes a season name as input from the user
            // and displays the corresponding month range for that season.
            // Note range for seasons ( spring march to may , summer June to august ,
            // autumn September to November , winter December to February)

            Console.WriteLine("Please enter season name: ");
            string input01 = Console.ReadLine();

            if (Enum.TryParse(input01, true, out Season season))
            {
                switch (season)
                {
                    case Season.Spring:
                        Console.WriteLine("Spring : from March to May.");
                        break;
                    case Season.Summer:
                        Console.WriteLine("Summer : from June to August.");
                        break;
                    case Season.Autumn:
                        Console.WriteLine("Autumn : from September to November.");
                        break;
                    case Season.Winter:
                        Console.WriteLine("Winter : from December to February.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid season entered.");
            }
            #endregion

            #region Question 4 
            // Assign the following Permissions (Read, write, Delete, Execute) in a form of Enum.
            // Create Variable from previous Enum to Add and Remove Permission from variable,
            // check if specific Permission is existed inside variable

            Permissions userPermissions = Permissions.None;

            userPermissions |= Permissions.Read;
            userPermissions |= Permissions.Write;

            Console.WriteLine($"Current Permissions is : {userPermissions}");

            if (userPermissions.HasFlag(Permissions.Read))
            {
                Console.WriteLine("User has Read Permission.");
            }
            else
            {
                Console.WriteLine("User doesn't have Read Permission.");
            }

            userPermissions ^= Permissions.Write;

            if (userPermissions.HasFlag(Permissions.Delete))
            {
                Console.WriteLine("User has Delete Permission.");
            }
            else
            {
                Console.WriteLine("User doesn't have Delete Permission.");
            }

            Console.WriteLine($"Current Permissions is : {userPermissions}");

            #endregion

            #region Question 5 
            // 5. Create an enum called "Colors" with the basic colors (Red, Green, Blue)
            // as its members. Write a C# program that takes a color name as input
            // from the user and displays a message indicating whether
            // the input color is a primary color or not.
            Console.WriteLine("Please enter a color: ");
            string input02 = Console.ReadLine();

            if (Enum.TryParse(input02, true, out Colors color))
            {
                Console.WriteLine($"This Color is a primary color!");
            }
            else
            {
                Console.WriteLine($"This Color is not a primary color.");
                Console.WriteLine("Primary colors are: Red, Green, Blue");
            }
            #endregion

            #region Question 6
            //Create a struct called "Point" to represent a 2D point with properties "X" and "Y".
            //Write a C# program that takes two points as input from the user and calculates
            //the distance between them.
            Point point01 = new Point();
            Point point02 = new Point();

            Console.WriteLine("Enter x value for Point 1: ");
            point01.X = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter y value for Point 1: ");
            point01.Y = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter x value for Point 2: ");
            point02.X = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter y value for Point 2: ");
            point02.Y = double.Parse(Console.ReadLine());

            double dx = point02.X - point01.X;
            double dy = point02.Y - point01.Y;
            double distance = Math.Sqrt(dx * dx + dy * dy);

            Console.WriteLine($"Distance between two points: {distance}");
            #endregion

            #region Question 7
            // Create a struct called "Person" with properties "Name" and "Age".
            // Write a C# program that takes details of 3 persons as input from the user and
            // displays the name and age of the oldest person.
            Person[] people02 = new Person[3];

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Enter Person{i + 1} Name: ");
                people02[i].Name = Console.ReadLine();
                Console.WriteLine($"Enter Person{i + 1} Age: ");
                people02[i].Age = int.Parse(Console.ReadLine());
            }

            // Find oldest person
            Person oldest = people02[0];
            for (int i = 1; i < people02.Length; i++)
            {
                if (people02[i].Age > oldest.Age)
                {
                    oldest = people02[i];
                }
            }

            Console.WriteLine($"\nThe oldest person is {oldest.Name}, Age: {oldest.Age}");

            #endregion
            #endregion

            #region Part 02
            try
            {
                Employee[] EmpArr = new Employee[3];

                EmpArr[0] = new Employee(1, "Ahmed", SecurityLevel.Secretary, 125000, new HiringDate(10, 6, 2019), 'M');
                EmpArr[1] = new Employee(2, "Alkahlawy", SecurityLevel.DBA, 30000, new HiringDate(5, 9, 2021), 'M');
                EmpArr[2] = new Employee(3, "Radwa", SecurityLevel.Developer, 160000, new HiringDate(15, 3, 2020), 'F');

                foreach (var emp in EmpArr)
                {
                    Console.WriteLine(emp);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            #endregion
        }
    }
}
