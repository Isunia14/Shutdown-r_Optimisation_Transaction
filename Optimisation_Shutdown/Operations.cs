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

        static public Transaction transactionDuJour(string date, Transaction derniereTransac)
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

        static private string getSymbolLePlusRentable(string date) {
            //Fonction d'utilisation de l'API Yahoo

            return tickerList[0];
        }

    }
}
