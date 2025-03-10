using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon_Collections.Interface
{
    interface PolicyInterface
    {
        public void AddPolicy() { }
        public void DisplayPolicy() { }
        public void UpdatePolicy(int id) { }
        public void FindPolicy(object? idx) { }
        public void DeletePolicy(object? idx) { }
        public void ViewActivePolicy() { }


    }
}