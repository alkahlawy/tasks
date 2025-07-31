using System.Runtime.Intrinsics.X86;
using task8_oop3.Classes;
using task8_oop3.Interfaces;
using task8_oop3.Part02_Q02.Classes;
using task8_oop3.Part02_Q02.Interfaces;
using task8_oop3.Part02_Q03.Classes;
using task8_oop3.Part02_Q03.Interfaces;

namespace task8_oop3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Part 01
            //Question 1:
            //What is the primary purpose of an interface in C#?
            //a) To provide a way to implement multiple inheritance
            //b) To define a blueprint for a class
            //c) To declare abstract methods and properties
            //d) To create instances of objects

            // answer is =====> (b) To define a blueprint for a class

            //Question 2:
            //Which of the following is NOT a valid access modifier for interface members in C#?
            //a) private
            //b) protected
            //c) internal
            //d) public

            // answer is =====> (b) private

            //Question 3:
            //Can an interface contain fields in C#?
            //a) Yes
            //b) No
            //c) Only if they are static
            //d) Only if they are readonly

            // answer is =====> (c) Only if they are static

            //Question 4:
            //In C#, can an interface inherit from another interface?
            //a) No, interfaces cannot inherit from each other
            //b) Yes, interfaces can inherit from multiple interfaces
            //c) Yes, but only if they have the same methods
            //d) Only if the interfaces are in the same namespace

            // answer is =====> (b) Yes, interfaces can inherit from multiple interfaces

            //Question 5:
            //Which keyword is used to implement an interface in a class in C#?
            //a) inherit
            //b) use
            //c) extends
            //d) implements

            // answer is =====> (d) implements :

            //Question 6:
            //Can an interface contain static methods in C#?
            //a) Yes
            //b) No
            //c) Only if the interface is sealed
            //d) Only if the methods are private

            // answer is =====> (a) yes

            //Question 7:
            //In C#, can an interface have explicit access modifiers for its members?
            //a) Yes, for all members
            //b) No, all members are implicitly public
            //c) Yes, but only for abstract members
            //d) Only if the interface is sealed

            // answer is =====> (b) No, all members are implicitly public

            //Question 8:
            //What is the purpose of an explicit interface implementation in C#?
            //a) To hide the interface members from outside access
            //b) To provide a clear separation between interface and class members
            //c) To allow multiple classes to implement the same interface
            //d) To speed up method resolution

            // answer is =====> (a) To hide the interface members from outside access

            //Question 9:
            //In C#, can an interface have a constructor?
            //a) Yes, but it must be private
            //b) No, interfaces cannot have constructors
            //c) Yes, but only if the interface is sealed
            //d) Only if the constructor is static

            // answer is =====> (b) No, interfaces cannot have constructors

            //Question 10:
            //How can a C# class implement multiple interfaces?
            //a) By using the "implements" keyword
            //b) By using the "extends" keyword
            //c) By separating interface names with commas
            //d) A class cannot implement multiple interfaces

            // answer is =====> (c) By separating interface names with commas

            #endregion

            #region Part 02
            #region Question 01
            IShape circle = new Circle(5);
            IShape rectangle = new Rectangle(4, 6);

            circle.DisplayShapeInfo();
            Console.WriteLine();

            rectangle.DisplayShapeInfo();
            #endregion
            #region Question 02
            IAuthenticationService authService = new BasicAuthenticationService();

            Console.WriteLine("Authenticating 'admin' with correct password:");
            Console.WriteLine(authService.AuthenticateUser("admin", "admin123")); // True

            Console.WriteLine("\nAuthenticating 'mohamed' with wrong password:");
            Console.WriteLine(authService.AuthenticateUser("mohamed", "wrongpass")); // False

            Console.WriteLine("\nAuthorizing 'salma' as Manager:");
            Console.WriteLine(authService.AuthorizeUser("salma", "Manager")); // True

            Console.WriteLine("\nAuthorizing 'mohamed' as User:");
            Console.WriteLine(authService.AuthorizeUser("mohamed", "User")); // True

            #endregion

            #region Question 03
            INotificationService emailService = new EmailNotificationService();
            INotificationService smsService = new SmsNotificationService();
            INotificationService pushService = new PushNotificationService();

            emailService.SendNotification("salma@gmail.com", "Welcome to our email service!");
            smsService.SendNotification("+201234567890", "Your OTP is 456789.");
            pushService.SendNotification("Kahlawy", "You have a new message in your inbox.");
            #endregion
            #endregion
        }
    }
}
