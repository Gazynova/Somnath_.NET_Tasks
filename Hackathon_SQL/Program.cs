using System;
using System.ComponentModel.Design;
using Hackathon_SQL.Interface;
using Hackathon_SQL.Model;
using Hackathon_SQL.Repository;

namespace Hackathon_SQL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Collections Hackathon\n");

            PolicyInterfaceSql insured = new PolicyRepositorySql();

            while (true)
            {
                Console.WriteLine("MENU:\n");
                Console.WriteLine("1. ADD Insured\n");
                Console.WriteLine("2. UPDATE Insured\n");
                Console.WriteLine("3. REMOVE Insured\n");
                Console.WriteLine("4. SEARCH for Insured\n");
                Console.WriteLine("5. DISPLAY all Insured\n");
                Console.WriteLine("6. View Active Policies\n");
                Console.WriteLine("7. EXIT");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter PolicyID:");
                        int policyID = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter PolicyHolderName:");
                        string policyHolderName = Console.ReadLine();
                        Console.WriteLine("Enter PolicyType:");
                        int policyType = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter StartDate (YYYY-MM-DD):");
                        DateTime startDate = Convert.ToDateTime(Console.ReadLine());
                        Console.WriteLine("Enter EndDate (YYYY-MM-DD):");
                        DateTime endDate = Convert.ToDateTime(Console.ReadLine());

                        PolicySql newPolicy = new PolicySql
                        {
                            PolicyID = policyID,
                            PolicyHolderName = policyHolderName,
                            PolicyType = policyType,
                            StartDate = startDate,
                            EndDate = endDate
                        };

                        int addStatus = insured.AddInsured(newPolicy);
                        Console.WriteLine(addStatus > 0 ? "Insured Added successfully" : "Insured not Added!!!");
                        break;

                    case 2:
                        Console.WriteLine("Enter PolicyID to update:");
                        int updatePolicyID = Convert.ToInt32(Console.ReadLine());
                        insured.UpdateInsured(updatePolicyID);
                        break;
                    case 3:
                        Console.WriteLine("Enter PolicyID to remove:");
                        int removePolicyID = Convert.ToInt32(Console.ReadLine());
                        insured.DeleteInsured(removePolicyID);
                        break;

                    //case 4:
                    //    Console.WriteLine("Enter PolicyID to search:");
                    //    int searchPolicyID = Convert.ToInt32(Console.ReadLine());
                    //    PolicySql searchedPolicy = insured.GetInsuredByID(searchPolicyID);
                    //    Console.WriteLine(searchedPolicy != null ? searchedPolicy.ToString() : "Insured not found.");
                    //    break;

                    case 5:
                        List<PolicySql> policies = insured.GetInsured();
                        foreach (PolicySql item in policies)
                        {
                            Console.WriteLine(item);
                        }
                        break;

                    //case 6:
                    //    List<PolicySql> activePolicies = insured.GetActivePolicies();
                    //    foreach (PolicySql item in activePolicies)
                    //    {
                    //        Console.WriteLine(item);
                    //    }
                    //    break;

                    case 7:
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
        }
    }
}
