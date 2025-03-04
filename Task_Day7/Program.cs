namespace Task_Day7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task Day 7");

            List<Employee> employees;
            Console.WriteLine("Enter Employee Details\n");
            Console.WriteLine("Enter Name:\t");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Employee Id :\t");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Employee Joining Date:\t");
            var date = Console.ReadLine();
            DateTime dateTime;
            DateTime.TryParse(date, out dateTime);




        }
    }
}
