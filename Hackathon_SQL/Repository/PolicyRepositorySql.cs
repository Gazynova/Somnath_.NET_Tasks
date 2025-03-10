using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Hackathon_SQL.Interface;
using Hackathon_SQL.Model;
using Hackathon_SQL.Utility;


namespace Hackathon_SQL.Repository
{
    class PolicyRepositorySql : PolicyInterfaceSql
    {
        //public static List<PolicySql> policies = new List<PolicySql>()

        SqlCommand? cmd = null;
        string connstring = "";
        private object policy;

        public PolicyRepositorySql()
        {
            cmd = new SqlCommand();
            connstring = DbConnUtil.GetConnectionString();
        }



        public List<PolicySql> GetInsured()
        {
            List<PolicySql> insured = new List<PolicySql>();
            Console.WriteLine("Policy ID\t PolicyHolderName\t PolicyType\t StartDate\t EndDate");

            using (SqlConnection sqlConnection = new SqlConnection(connstring))
            {
                cmd.CommandText = "Select * from Insured";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PolicySql insurer = new PolicySql();
                    insurer.PolicyID = (int)reader["PolicyID"];
                    insurer.PolicyHolderName = (string)reader["PolicyHolderName"];
                    insurer.PolicyType = (int)reader["PolicyType"];
                    insurer.StartDate = (DateTime)reader["StartDate"];
                    insurer.EndDate = (DateTime)reader["EndDate"];

                    insured.Add(insurer);

                }
            }
            return insured;
        }

        public int AddInsured(PolicySql policy)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connstring))
            {
                // cmd.Parameters.Clear();
                cmd.CommandText = "Insert into Insured values(@PolicyID,@PolicyHolderName,@PolicyType,@StartDate,@EndDate)";
                cmd.Parameters.AddWithValue("@PolicyID", policy.PolicyID);
                cmd.Parameters.AddWithValue("@PolicyHolderName", policy.PolicyHolderName);
                cmd.Parameters.AddWithValue("@PolicyType", policy.PolicyType);
                cmd.Parameters.AddWithValue("@StartDate", policy.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", policy.EndDate);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                return cmd.ExecuteNonQuery();
                // return cmd.ExecuteScalar();//check this method

            }
        }


        public int DeleteInsured(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connstring))
            {
                cmd.CommandText = "Delete from Insured where PolicyID=@PolicyID";
                cmd.Parameters.AddWithValue("@PolicyID", id);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public int UpdateInsured(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connstring))
            {
                Console.WriteLine("Enter ID");
                Console.WriteLine("What do you want to update\n 1.\tName\n 2.\tPolicyType\n 3.\tEndDate");
                int input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        Console.WriteLine("Enter Your Name\t");
                        string PolicyHolderName = Console.ReadLine();
                        cmd.CommandText = "Update Insured set PolicyHolderName=@PolicyHolderName where PolicyID=@PolicyID";
                        cmd.Parameters.AddWithValue("@PolicyHolderName", PolicyHolderName);
                        cmd.Parameters.AddWithValue("@PolicyID", id);
                        //sqlConnection.Open();
                        break;

                    case 2:
                        Console.WriteLine("Enter Type\t");
                        int type = Convert.ToInt32(Console.ReadLine());
                        cmd.CommandText = "Update Insured set PolicyType=@PolicyType where PolicyID=@PolicyID";
                        cmd.Parameters.AddWithValue("@PolicyType", type);
                        cmd.Parameters.AddWithValue("@PolicyID", id);
                        //sqlConnection.Open();
                        break;

                    case 3:
                        Console.WriteLine("Enter End Date to be Changed (YYYY-MM-DD)\t");
                        DateTime endDate = Convert.ToDateTime(Console.ReadLine());
                        cmd.CommandText = "Update Insured set EndDate=@EndDate where PolicyID=@PolicyID";
                        cmd.Parameters.AddWithValue("@EndDate", endDate);
                        cmd.Parameters.AddWithValue("@PolicyID", id);

                        //sqlConnection.Open();
                        break;

                    default:
                        Console.WriteLine("Invalid selection.");
                        break;
                }
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                return cmd.ExecuteNonQuery();
            }

        }
    }
}
