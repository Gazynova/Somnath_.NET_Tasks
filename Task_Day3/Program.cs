using System.Text.RegularExpressions;
using System.Transactions;
using Task_Day3.Model;

namespace Task_Day3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            #region part 1

            CarDetails car = new CarDetails();

            Console.WriteLine("\nDefault Constructr Using");
            //car.GetDetails();

            car.DisplayDetails();
            Console.WriteLine("\nParametrized Constructr Using");
            CarDetails car1 = new CarDetails(1,"Tesla","TE1",12345,DateTime.Now);
            car1.DisplayDetails();




            #endregion

            #region

            Console.WriteLine("Enter Password for the login:\t");
            string password = Console.ReadLine();
            string pattern = @"[A-Z]+[a-z]+\d[0-9]+";
            Regex rg = new Regex(pattern);

            

            if (rg.IsMatch(password) && password.Length > 6)
            {
                Console.WriteLine("Accepted");

            }
            else
            {
                Console.WriteLine("Rejected");
            }

            #endregion
        }
    }
}
