using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Day_6
{
    class Bank
    {
        Queue<int> queue = new Queue<int>();

        public void AddToken(int num)
        {
            queue.Enqueue(num);
        }

        public void GetToken()
        {
            Console.WriteLine($"The Next Token:\t{ queue.Peek()}");
            //return queue.Peek();
        }


        public int NextToken()
        {
            if(queue.)
            return queue.Dequeue();
        }

        
    }
}
