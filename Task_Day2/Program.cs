namespace Task_Day2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Part 1
            Console.WriteLine("Hello, World!");
            Console.WriteLine("Enter your Basic Salary:\t");
            double salary = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Tax Deducted 10% of Basic Salary:\t");
            double tax = Convert.ToDouble(salary * 0.1);
            Console.WriteLine($"Tax Deducted::\t{tax}");
            Console.WriteLine($"Write the Performance Rating:\t");
            double rating = Convert.ToDouble(Console.ReadLine());
            double Bonus;
            if (rating >= 8)
            {
                Bonus = Convert.ToDouble(salary * 0.2);
                Console.WriteLine($"Bonus Given::{Bonus}");
            }
            else if (rating >= 5)
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

            #endregion part1

            #region part2

            Console.WriteLine("ONLINE TICKET BOOKING");
            Console.WriteLine("Ticket types:\n 1:\tGeneral-200rs\n 2:\tAC-1000rs\n 3:\tSleeper-500 \n4:\tExit");
            Console.WriteLine("Enter Number and type of ticket to Book(write firt Capital letter of the type):");
            string type = Console.ReadLine();
            int count = 0; 
            //Console.WriteLine($"{count} ticket {type}");
            int amount = 0;
            while (type != "E")
            {
                Console.WriteLine("Enter the number of tickets to book:\t");
                
                if(type == "G")
                {
                    count = Convert.ToInt32(Console.ReadLine());
                    amount = Convert.ToInt32(amount+200*count);
                    Console.WriteLine("would  you like to book more or exit");
                    //bool flag = Console.ReadLine();
                }
                else if (type == "A")
                {
                    count = Convert.ToInt32(Console.ReadLine());
                    amount = Convert.ToInt32(amount + 1000 * count);
                }
                else if (type == "S")
                {
                    count = Convert.ToInt32(Console.ReadLine());
                    amount = Convert.ToInt32(amount + 500 * count);
                }
            }

            Console.WriteLine(amount);

            #endregion


            #region Part3
            string[] users = { "Somnath", "Pratik", "Tejas" };
            float[] wallet = { 1000, 2000, 3000 };


        returnto:
            Console.WriteLine("enter username :\t");
            string user = Console.ReadLine();
            int index = Array.FindIndex(users, u => u == user);

            if (index != -1)
            {
                Console.WriteLine($"");
            }
            else
            {
                Console.WriteLine("User not found. Enter Valid user");
                goto returnto;// This line will execute if the index is -1
            }

            #endregion

            #region

            //int[,] stuMarks = new int[2, 2];
            int[,] stuMarks1 =
            {
                {1,1000 },
                {2,8000000 },
                {3,8000000 },
                {4,8000000 },
                {5,8000000 },
                {6,8000000 },
                {7,8000000 },
                {8,8000000 },
                {9,8000000 }
            };
            Console.WriteLine("enter user id:\t");
            int id = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < stuMarks1.GetLength(1); i++)
            {
                if (stuMarks1[i, 0] == id)
                {
                    Console.WriteLine($"Salary of Employee-{id}is:\t{stuMarks1[i, 1]}");
                    break;
                }
                else
                {
                    Console.WriteLine("Enter Valid UserName");
                }
            }

        //returnto:
            
        //    (int row, int col) = ArFindIndex(stuMarks1, id);
        //    if (Array.FindIndex(stuMarks1,u=>u==id){

        //    }

            #endregion
        }
    }
}