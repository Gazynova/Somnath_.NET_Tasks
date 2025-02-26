using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Day4
{
    class Manager:Employee
    {
        public static double Bonus = 1000;
        
        public new void DisplayDetails()
        {
            //Salary = Employee.Salary + Bonus;
            
            Console.WriteLine($"Employee Name :{Employee.Name}\nEmployee Salary after Bonus:{Employee.Salary+Bonus}");

        }


    }
}
