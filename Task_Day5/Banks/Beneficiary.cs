using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Day5.Exceptions;

namespace Task_Day5.Banks
{
    class Beneficiary
    {


        List<Customer> details; 

        public Beneficiary()
        {
            details = new List<Customer>
            {
                //new Customer(){AccNumber:123, AccHolder:"Pranav"},
                //new Customer(){AccNumber:123, AccHolder:"Pranav"},
                new Customer(123,"Sanket"),
                new Customer(1234,"UK"),
                new Customer(124,"TEJAS")

            };
        }

        public void AddBeneficiary()
        {
            Console.WriteLine("Add Beneficary Name and Account Number:\t");
            string accHolder = Console.ReadLine();
            int accNumber = Convert.ToInt32(Console.ReadLine());
            

            try
            {
                Customer search = FindBeneficiary(accHolder);
                if (search == null)
                {
                    details.Add(new Customer(accNumber, accHolder));

                }
                else
                {
                    throw new UserDefinedExceptions($"{accHolder} name already exits");
                }
            }
            catch(UserDefinedExceptions userex)
            {
                Console.WriteLine(userex.Message);
            }
        }

        public List<Customer> GetAllBeneficiary()
        {
            return details;
        }

        public Customer FindBeneficiary(string name)
        {
            return details.Find(d => d.AccHolder == name);
            
            
        }



    }
}
