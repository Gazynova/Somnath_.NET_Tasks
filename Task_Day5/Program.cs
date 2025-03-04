using Task_Day5.Banks;

namespace Task_Day5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task Day 5");
            #region Part 1
            Beneficiary beneficiary = new Beneficiary();
            //beneficiary.AddBeneficiary();
            Console.WriteLine();

            beneficiary.AddBeneficiary();
            beneficiary.GetAllBeneficiary();
            List<Customer>custdata = beneficiary.GetAllBeneficiary();

            foreach(Customer cust in custdata)
            {
                Console.WriteLine(cust.AccNumber+cust.AccHolder);
            }


            #endregion





        }
    }
}
