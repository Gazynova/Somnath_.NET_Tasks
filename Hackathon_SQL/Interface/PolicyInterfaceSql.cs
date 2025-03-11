using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hackathon_SQL.Model;

namespace Hackathon_SQL.Interface
{
    interface PolicyInterfaceSql
    {
        public int AddInsured(PolicySql policy);
        List<PolicySql> GetInsured();

        public int DeleteInsured(int id);
        public int UpdateInsured(int id);
        public bool CheckAvailable(int id);


    }
}