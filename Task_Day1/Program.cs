// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
string name;
int age;
double percentage;

Console.WriteLine("Enter Your Name : ");
name = Console.ReadLine();
Console.WriteLine("Enter Your Age :");

bool result;
result = int.TryParse(Console.ReadLine(), out age);
while (!result)
{
    Console.WriteLine("Write Numeric Age Correctly.");
    result = int.TryParse(Console.ReadLine(), out age);

}

//result = int.TryParse(Console.ReadLine(), out age);
//if (!result)
//{
//    Console.WriteLine("Write Numeric Age Correctly.");
//}

Console.WriteLine("Enter Your Percentage :");
percentage = Convert.ToDouble(Console.ReadLine());



String? email=null;
Console.WriteLine("Enter Your Email Address :");
email = Console.ReadLine();

if (email == null || email == "")
{
    Console.WriteLine("This field cant be empty :");
    email = Console.ReadLine();

}
//string? date=null;
//Console.WriteLine("Enter Registration Date :");
//Console.WriteLine(date);
//date = Console.ReadLine();
DateOnly date;
if(date==null)
{
    //date = "not discharged";
    Console.WriteLine(date);
}



Console.WriteLine("Student Values");
Console.WriteLine($"Name::{name}\nAge::{age}\nPercentage::{percentage}\nEmail::{email}\n Discharged Date::{date}");



