using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon_SQL.Model
{
    public enum PolicyType { Life, Health, Vehicle, Property }

    class PolicySql
    {

        public int PolicyID { get; set; }
        public string PolicyHolderName { get; set; }

        public int PolicyType;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        //private bool IsActive { }

        public PolicySql()
        {

        }

        public override string ToString()
        {
            
            return $"| {PolicyID,-15} | {PolicyHolderName,-15} | {PolicyType,-15} | {StartDate.ToShortDateString(),-15} | {EndDate.ToShortDateString(),-15} |";
        }


    }
}
