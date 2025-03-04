using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Hackathon_Collections.Interface;
using Hackathon_Collections.Model;
//using Hackathon_Collections.Exception;

namespace Hackathon_Collections.Repository
{
    class PolicyRepository:PolicyInterface
    {
        public static List<Policy> policies = new List<Policy>();

        public void AddPolicy()
        {
            Console.WriteLine("Enter Policy Holder Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Policy Holder Id:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Policy Type:");
            string type = Console.ReadLine();
            PolicyType policyType;
            while (!Enum.TryParse(type, true, out policyType) || !Enum.IsDefined(typeof(PolicyType), type))
            {
                Console.WriteLine("Invalid input. Please enter a valid policy type (Life, Health, Vehicle, Property):");
                type = Console.ReadLine();
            }
            Console.WriteLine("Enter Start Date (YYYY-MM-DD):");
            DateTime startDate = DateTime.Now;

            Console.WriteLine("Enter End Date (YYYY-MM-DD):");
            DateTime endDate = DateTime.Parse(Console.ReadLine());

            Policy newPolicy = new Policy(id, name, policyType, startDate, endDate);
            policies.Add(newPolicy);

            Console.WriteLine("Policy created and added to the list successfully!");
            Console.WriteLine($"Policy ID: {newPolicy.PolicyID}, Holder: {newPolicy.PolicyHolderName}, Type: {newPolicy.PolicyType}, Start: {newPolicy.StartDate}, End: {newPolicy.EndDate}");
        }

        public void DisplayPolicy()
        {
            Console.WriteLine("Displaying Insured Policies");
            if (policies.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n[✖] Error:No policies found.");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($"| {"ID",-10} | {"Name",-15} | {"Type",-10} | {"Start",-10} | {"End",-10} | {"Active",-10} |");
                policies.ForEach(p => {
                    Console.WriteLine(p);
                });
            }
        }
        
        public void FindPolicy(object key)
        {
            if (key is int id)
            {
                if (Finder(id) == -1)
                {
                    Console.WriteLine("No such Insured Found!!!\n");
                    throw new FoundException($"there is No such policy with ID :{id}");
                }
                else
                {
                    Console.WriteLine("Insured Founded Succcessully!!\n");
                    Console.WriteLine(policies);
                }
            }

            if (key is string name)
            {
                int idx = policies.FindIndex(p => p.PolicyHolderName == name);
                if (idx == -1)
                {
                    Console.WriteLine("No such Insured Found!!!\n");
                }
                else
                {
                    //policies.RemoveAt(idx);
                    Console.WriteLine("Insured Founded Succcessully!!\n");
                    Console.WriteLine(policies);
                }
            }
        }

        public int Finder(int id)
        {
            return policies.FindIndex(p => p.PolicyID == id);
        }
        public void UpdatePolicy(int id)
        {
            
                if (Finder(id) == -1)
                {
                    //Console.WriteLine("Exception Found");
                    throw new FoundException($"User Does not Exists with Id : {id}");

                }
                else
                {
                    {
                        Console.WriteLine("Enter The Values You Want to Update Skips Those You Dont Want");
                        Console.WriteLine("Enter Policy Holder Name:");
                        string name = Console.ReadLine();
                        //Console.WriteLine("Enter Policy Holder Id:");
                        //int id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Policy Type:");
                        string type = Console.ReadLine();
                        PolicyType policyType;
                        while (!Enum.TryParse(type, true, out policyType) || !Enum.IsDefined(typeof(PolicyType), type))
                        {
                            Console.WriteLine("Invalid input. Please enter a valid policy type (Life, Health, Vehicle, Property):");
                            type = Console.ReadLine();
                        }
                        Console.WriteLine("Enter Start Date (YYYY-MM-DD):");
                        DateTime startDate = DateTime.Now;

                        Console.WriteLine("Enter End Date (YYYY-MM-DD):");
                        DateTime endDate = DateTime.Parse(Console.ReadLine());

                        if (!string.IsNullOrEmpty(name))
                        {
                            policies[id].PolicyHolderName = name;
                        }
                        if (!string.IsNullOrEmpty(type))
                        {
                            policies[id].PolicyType = policyType;
                        }
                    //if (DateTime.TryParse(startDate, out startDate))
                    //{
                    //    policies[id].StartDate = startDate;
                    //}
                    //if (DateTime.TryParse(enddate, out endDate))
                    //{
                    //    policies[id].EndDate = endDate;
                    //}

                }
            }
            
            
        }

        public void DeletePolicy(object key)
        {

            if(key is  int id )
            {
                if(Finder(id) == -1)
                {
                    Console.WriteLine("No such Insured Found!!!\n");
                    throw new FoundException($"there is No such policy with ID :{id}");
                }
                else
                {
                    policies.RemoveAt(id);
                    Console.WriteLine("Insured Removed Succcessully!!\n");
                }
            }

            if (key is string name)
            {
                int idx = policies.FindIndex(p => p.PolicyHolderName == name);
                if (idx ==  -1)
                {
                    Console.WriteLine("No such Insred Found!!!\n");
                }
                else
                {
                    policies.RemoveAt(idx);
                    Console.WriteLine("Insured Removed Succcessully!!\n");
                }
            }

        }

        public void ViewActivePolicy() 
        {
            foreach (Policy policy in policies)
            {
                if (policy.EndDate > DateTime.UtcNow)
                {
                    Console.WriteLine(policy);
                }
            }
        }










    }
}
