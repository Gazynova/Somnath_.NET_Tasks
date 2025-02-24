namespace Task_Day2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine("Enter your Basic Salary:\t");
            double salary = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Tax Deducted 10% of Basic Salary:\t");
            double tax = Convert.ToDouble(salary*0.1);
            Console.WriteLine($"Tax Deducted::\t{tax}");
            Console.WriteLine($"Write the Performance Rating:\t");
            double rating = Convert.ToDouble(Console.ReadLine());
            double Bonus;
            if (rating >= 8)
            {
                Bonus = Convert.ToDouble(salary * 0.2);
                Console.WriteLine($"Bonus Given::{Bonus}");
            }
            else if(rating >= 5)
            {
                Bonus = Convert.ToDouble(salary * 0.1);
                Console.WriteLine($"Bonus Given::{Bonus}");
            }
            else
            {
                Bonus = 0;
                Console.WriteLine("No Bonus");
            }


            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Final Salary::{salary + Bonus - tax}");


        }
    }
}
