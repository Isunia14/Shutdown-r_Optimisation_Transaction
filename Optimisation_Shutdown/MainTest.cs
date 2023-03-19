using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Optimisation_Shutdown
{
    internal class MainTest
    {
        static public void Main(List<string> symboles,string debut, string fin)
        {
            // Display the number of command line arguments.
            //Console.WriteLine(args.Length);

            //On initialise notre transaction
            Operations op = new Operations(symboles,debut,fin);
            List<Transaction> transactionEffectuees = new List<Transaction>();

            //Puis, pour chaque date entre la date de début et la date de fin, on doit effectuer une transaction

            string date = debut;
            Transaction derniereTransac = null;

            while (date != fin)
            {
                derniereTransac = op.transactionDuJour(date, derniereTransac);
                transactionEffectuees.Add(derniereTransac);
                date = op.changeDate(date);
            }


            //Enfin, on convertit tout ça dans un fichier, trouvable à la racine du projet

            string path = @"..\..\..\..\transaction.json";

            foreach (Transaction transaction in transactionEffectuees)
            {
                string JSONresult = JsonConvert.SerializeObject(transaction);

                using (var tw = new StreamWriter(path, true))
                {
                    tw.WriteLine(JSONresult.ToString());
                }
            }
            //Et on pense à fermer le fichier
            using (var tw = new StreamWriter(path, true))
            {
                tw.Close();
            }


        }
    }
}
