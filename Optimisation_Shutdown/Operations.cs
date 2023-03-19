using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimisation_Shutdown
{
    class Operations
    {
        static public string date_debut;
        static public string date_fin;
        static List<string> tickerList;

        public Operations(List<string> symboles,string debut, string fin) {
            date_debut = debut;
            date_fin = fin;
            tickerList = symboles;
        }

        public Transaction transactionDuJour(string date, Transaction derniereTransac)
        {
            Transaction transaction = new Transaction();
            transaction.date = date;

            //On se place dans une stratégie court terme d'achat et de revente le lendemain

            if (date == date_debut) {
                transaction.action = "BUY";
                //TODO : Changer avec l'API
                transaction.ticker = getSymbolLePlusRentable(date);
                return transaction;

            }
            if (date == date_fin)
            {
                transaction.action = "SELL";
                transaction.ticker = derniereTransac.ticker;
                return transaction;
            }

            //Si ce n'est ni le dernier jour, ni le premier, on fait en fonction de la dernière transaction

            if(derniereTransac.action == "BUY")
            {
                //On peut soit ne rien faire, soit vendre. En accord avec notre stratégie, on va donc vendre

                //Si on décide de vendre :
                transaction.action = "SELL";
                transaction.ticker = derniereTransac.ticker;
                return transaction;
            }

            //On est dans le dernier cas, où on a vendu : soit on achète, soit on ne fait rien

            //Pareil qu'avant
            transaction.action = "BUY";
            //TODO : Changer avec l'API
            transaction.ticker = getSymbolLePlusRentable(date);

            return transaction;
        }

        private string getSymbolLePlusRentable(string date) {
            //Fonction d'utilisation de l'API Yahoo

            return tickerList[0];
        }

        public string changeDate(string date)
        {
            DateTime newDate =DateTime.Parse(date).AddDays(1);
            string formatAChanger = newDate.ToString("d");
            string[] separation = formatAChanger.Split("/");

            return (separation[2] + "-" + separation[1] + "-" + separation[0]);
        }

    }
}
