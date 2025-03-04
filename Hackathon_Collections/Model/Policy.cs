using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon_Collections.Model
{
    public enum PolicyType { Life, Health, Vehicle, Property }

    class Policy
    {

        public int PolicyID { get; set; }
        public string PolicyHolderName { get; set; }

        public PolicyType PolicyType;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        //private bool IsActive { }
        


        public Policy(int id, string name,PolicyType policy,DateTime start, DateTime end)
        {
            PolicyID = id;
            PolicyHolderName = name;
            PolicyType = policy;
            StartDate = start;
            EndDate = end;
        }
        public override string ToString()
        {
            return $"| {PolicyID,-10} | {PolicyHolderName,-15} | {PolicyType,-10} | {StartDate.ToShortDateString(),-10} | {EndDate.ToShortDateString(),-10} |";
        }

        
    }
}
