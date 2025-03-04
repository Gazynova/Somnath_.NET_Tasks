using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Day5.Banks;


namespace Task_Day5.Exceptions
{
    class UserDefinedExceptions:ApplicationException
    {
        public UserDefinedExceptions()
        {
            

        }

        public UserDefinedExceptions(string msg ):base(msg)
        {
            Console.WriteLine(value:Customer);
        }
    }
}
