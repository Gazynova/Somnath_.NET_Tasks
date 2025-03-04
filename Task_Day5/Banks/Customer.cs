using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Day5.Banks
{
    class Customer
    {
        public int AccNumber { get; set; }
        public string AccHolder { get; set; }

        public Customer(int accnum, string accname)
        {
            AccHolder = accname;
            AccNumber = accnum;
        }

        //public override string ToString()
        //{
        //    return $"Account Holder Name :{AccHolder}\nAccount Number :{AccNumber}";
        //}
    }
}
