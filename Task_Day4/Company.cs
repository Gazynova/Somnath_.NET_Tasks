using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Day4
{
    class Company
    {
        static int count = 0;
        public Company()
        {
            count++;
            Console.WriteLine("Employee Count: "+ count);
        }

        
    }
}
