using Eventify.Data.Models;
using Eventify.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventify.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Start Working...");

            /*Adding a transaction*/

            System.Console.WriteLine("Start adding a transaction...");
            Transaction transaction = new Transaction { amount=20.04f,token="AX5H4EH4U7"};
            ITransactionService transactionService = new TransactionService();
            transactionService.Add(transaction);
            transactionService.commit();
            transactionService.Dispose();
            System.Console.WriteLine("Transaction added");

            /*The End of Adding a transaction*/

            System.Console.WriteLine("Good Bye Brogrammer");
            System.Console.ReadKey();
        }
    }
}
