namespace Task_Day4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task Day 4");
            Employee Eemp = new Employee();
            Eemp.GetEmployeeDetails();
            Eemp.DisplayDetails();
            Manager Memp = new Manager();
            Memp.DisplayDetails();



        }
    }
}
