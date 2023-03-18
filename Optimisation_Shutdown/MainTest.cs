using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Optimisation_Shutdown
{
    internal class MainTest
    {
        static public void Main()
        {
            // Display the number of command line arguments.
            //Console.WriteLine(args.Length);

            Transaction transaction = new Transaction();

            string JSONresult = JsonConvert.SerializeObject(transaction);

            string path = @"..\..\..\transaction.json";

            using (var tw = new StreamWriter(path, true))
            {
                tw.WriteLine(JSONresult.ToString());
                tw.Close();
            }
        }
    }
}
