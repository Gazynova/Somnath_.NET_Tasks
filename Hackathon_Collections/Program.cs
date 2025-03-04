using System.ComponentModel.Design;
using Hackathon_Collections.Interface;
using Hackathon_Collections.Repository;

namespace Hackathon_Collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Collections Hackathon\n");

        MenuCommand:
            Console.WriteLine("MENU:\n");
            Console.WriteLine("1. ADD Insured\n");
            Console.WriteLine("2. UPDATE Insured\n");
            Console.WriteLine("3. REMOVE Insured\n");
            Console.WriteLine("4. SEARCH for Insured\n");
            Console.WriteLine("5. DISPLAY all Insured\n");
            Console.WriteLine("6. View Active Policies\n");
            Console.WriteLine("7. EXIT");
            PolicyInterface insured = new PolicyRepository();
            Console.WriteLine("Enter Your Choice:\t");
            int input = Convert.ToInt32(Console.ReadLine());
            int id;
            object idx;

            switch (input)
            {
                case 1:
                    insured.AddPolicy();
                    goto MenuCommand;
                    //break;
                case 2:
                    Console.WriteLine("Enter policy id to be update\t");
                    id = Convert.ToInt32(Console.ReadLine());
                    insured.UpdatePolicy(id);
                    goto MenuCommand;
                    //break;
                case 3:
                    Console.WriteLine("Enter policy id or Policy name to be Removed\t");
                    idx = Console.ReadLine();
                    insured.DeletePolicy(idx);
                    goto MenuCommand;
                    //break;
                case 4:
                    Console.WriteLine("Enter policy id to be found\t");
                    idx = Console.ReadLine();
                    insured.FindPolicy(idx);
                    goto MenuCommand;
                   //break;
                case 5:
                    insured.DisplayPolicy();
                    goto MenuCommand;
                    //break;
                case 6:
                    insured.ViewActivePolicy();
                    goto MenuCommand;
                    //break;
                case 7:
                    break;
                default:
                    break;

            }

        }
    }
}
