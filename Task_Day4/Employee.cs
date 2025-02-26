using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Day4
{
    class Employee:Company
    {
        public static double Salary;
        public static string Name;


        public void GetEmployeeDetails()
        {
            Console.WriteLine("Enter Employee Name :\t");
            Name = Console.ReadLine();
            Console.WriteLine("Enter Employee Salary :\t");
            Salary = Convert.ToDouble(Console.ReadLine());
        }
        public virtual void DisplayDetails()
        {
            Console.WriteLine($"Employee Name :{Name}\nEmployee Salary:{Salary}");

        }


    }
}
