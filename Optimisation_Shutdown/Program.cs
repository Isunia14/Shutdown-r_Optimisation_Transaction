// See https://aka.ms/new-console-template for more information
using Optimisation_Shutdown;

Console.WriteLine("Hello, World!");


DateTime newDate = DateTime.Parse("2023-01-31").AddDays(1);
string formatAChanger = newDate.ToString("d");
string[] separation = formatAChanger.Split("/");

Console.WriteLine(separation[2] + "-" + separation[1] + "-" + separation[0]);


List<string> s = new List<string> { "AAL", "DAL", "UAL", "LUV", "HA" };

MainTest.Main(s,"2023-01-01","2023-02-01");