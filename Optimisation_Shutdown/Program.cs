// See https://aka.ms/new-console-template for more information
using Optimisation_Shutdown;

List<string> s = new List<string> { "AAL", "DAL", "UAL", "LUV", "HA" };
List<string> sFinal = new List<string> { "GOOG", "AMZN", "META", "MSFT", "AAPL" };

MainTest.Main(s,"2023-01-01","2023-02-01");

MainFinal.Main(sFinal,"2023-01-01", "2023-02-01");