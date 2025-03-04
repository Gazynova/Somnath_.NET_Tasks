using System.ComponentModel.Design;
using System.Linq.Expressions;

namespace Task_Day_6
{
    internal class Program
    {
        static void Main(string[] args)
        {

        #region part 1
        Menu:
            Console.WriteLine("Hello, World!\n");
            Console.WriteLine("Menu:\n");
            Console.WriteLine("1. Get Token \n");
            Console.WriteLine("2. See Next Token");
            Console.WriteLine("3. Add Token");
            Console.WriteLine("4. Exit");

            Bank bank = new Bank();

            int opt = Convert.ToInt32(Console.ReadLine());
            switch (opt)
            {
                case 1:
                    bank.GetToken();
                    break;
                case 2:
                    bank.NextToken();
                    break;
                case 3:
                    Console.WriteLine("enter the token Id");
                    int id = Convert.ToInt32(Console.ReadLine());
                    bank.AddToken(id);
                    break;
                case 4:
                    Console.WriteLine("EXit Taken");
                    break;
                default:
                    goto Menu;
            }

            #endregion

            #region part2


            #endregion
        }
    }
}
