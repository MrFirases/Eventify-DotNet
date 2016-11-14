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

            //Adding a transaction
            /*
            System.Console.WriteLine("Start adding a transaction...");
            Transaction transaction = new Transaction { amount = 20.04f, token = "AX5H4EH4U7" };
            ITransactionService transactionService = new TransactionService();
            transactionService.Add(transaction);
            transactionService.commit();
            transactionService.Dispose();
            System.Console.WriteLine("Transaction added");

            //The End of Adding a transaction




            /*Adding a cateory

            System.Console.WriteLine("Start adding an cateory...");
            Category category = new Category() {categoryName = "Food"};

            ICategoryService categoryService = new CategoryService();
            categoryService.Add(category);
            categoryService.commit();
            categoryService.Dispose();
            System.Console.WriteLine("cateory added");

            The End of Adding a cateory*/

            /*Adding an event 

            System.Console.WriteLine("Start adding an event...");
            Myevent myevent = new Myevent() {title = "MyEventDotnet", createdAt = new DateTime(2016,1,1)};

            IEventService eventService = new EventService();
            eventService.Add(myevent);
            eventService.commit();
            eventService.Dispose();
            System.Console.WriteLine("event added");

            The End of Adding an event*/
            //IEventService eventService = new EventService();
            //System.Console.WriteLine(eventService.GetById(5).createdAt);


            //Testing Message Service
            IMessageService messageService = new MessageService();
            //System.Console.WriteLine("Claim Not Responded  :" + messageService.countClaimNotResponded()o());
            //System.Console.WriteLine("Claim Count  :" + messageService.countClaim());

            //foreach (var message in messageService.getClaimsNotResponded())
            //{
            //    System.Console.WriteLine(message.message1);
            //}

            //Test Reservation Service
            IReservationService reservationService =new ReservationService();

                System.Console.WriteLine("Our Amount " + reservationService.getAllAmount());
            

            

            System.Console.WriteLine("Good Bye Brogrammer");
            System.Console.WriteLine("Good Bye Brogrammers :p ");
            System.Console.ReadKey();
        }
    }
}
