using Eventify.Data.Models;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eventify.Data.Infrastructure;
using Microsoft.AspNet.Identity;
using Twilio;

namespace Eventify.Service
{
    public class UserService : MyServiceGeneric<User>, IUserService
    {
        private static IDataBaseFactory dbfac = new DataBaseFactory();

        private static IUnitOfWork itw = new UnitOfWork(dbfac);


        public UserService() : base(itw)
        {
        }

        public int AllActivedUsersNumber()
        {
            return this.GetMany(u => u.accountState == "ACTIVATED").Count();
        }

        public int AllBanndUsersNumber()
        {
            return this.GetMany(u => u.banState == 1).Count();
        }

        public int AllUnbannedUsersNumber()
        {
            return this.GetMany(u => u.banState == 0).Count();
        }

        public int AllUsersNumber()
        {
            return this.GetMany().Count();
        }

      

        public Dictionary<string, int> GetPieChartStat()
        {
            Dictionary<String, Int32> data = new Dictionary<String, Int32>();
            
            foreach (var line in this.GetMany().GroupBy(info => info.country)
                       .Select(group => new {
                           country = group.Key,
                           Count = group.Count()
                       })
                       .OrderBy(x => x.country))

            {
                data.Add(line.country, line.Count);


            }

            return data;


        }

        public Dictionary<string, int> GetUsersByDateChart()
        {

            Dictionary<String, Int32> data = new Dictionary<String, Int32>();

            foreach (var line in this.GetMany().GroupBy(info => info.creationDate.Value.ToString("yyyy"))
                       .Select(group => new {
                           year = group.Key,
                           Count = group.Count()
                       })
                       .OrderBy(x => x.year))

            {
                data.Add(line.year, line.Count);
                System.Diagnostics.Debug.WriteLine("{0} {1}", line.year, line.Count);

            }

            return data;



        }

        public List<Myevent> GetEventThatUserParticipateIn(int idUser)
        {
            var query2 = from users in this.GetMany()
                         join reservations in dbfac.DBcontext.reservations on users.Id equals reservations.user_id
                         join tickets in dbfac.DBcontext.tickets.ToList() on reservations.ticket_id equals tickets.id
                         join events in dbfac.DBcontext.myevents.ToList() on tickets.event_id equals events.id
                         where users.Id == idUser && reservations.reservationState == "CONFIRMED" && reservations.timerState == "FINISHED"
                         select events;

            /*
            IEventService eventService = new EventService();
            IReservationService reservationService = new ReservationService();
            
            List<Myevent> myevents = new List<Myevent>();
            List<Ticket> mytickets = new List<Ticket>();
            List<Reservation> myreservations = new List<Reservation>();
            
                        IEnumerable<Myevent> query = from events in dbfac.DBcontext.myevents
                                    join tickets in dbfac.DBcontext.tickets on events.id equals tickets.event_id
                                    join reservations in dbfac.DBcontext.reservations on tickets.id equals reservations.ticket_id
                                    join users in this.GetMany() on reservations.user_id equals 1
                                    select events;
            */
            var query1 = from users in this.GetMany()
             join reservations in dbfac.DBcontext.reservations on users.Id equals reservations.user_id
                          join tickets in dbfac.DBcontext.tickets.ToList() on reservations.ticket_id equals tickets.id
                          join events in dbfac.DBcontext.myevents.ToList() on tickets.event_id equals events.id
                          where users.Id == idUser && reservations.reservationState == "CONFIRMED" && reservations.timerState == "FINISHED"
                          select events ;

            System.Diagnostics.Debug.WriteLine("**********************************************************");
            /*
            foreach (var obj in query)
            {
                System.Diagnostics.Debug.WriteLine("Title Query: " + obj.title);
            }
            */

            foreach (var obj in query1)
            {
                System.Diagnostics.Debug.WriteLine("Title Query True: " + obj.title);
            }
            List<Myevent> list_course = query1.ToList();
            System.Diagnostics.Debug.WriteLine("***********************************************************");
            return list_course;
        }

        public bool SendSMS(string userPhoneNumber)
        {
            var accountSid = "ACc01a36028ee877166424ab96c711cf34"; // Your Account SID from www.twilio.com/console
            var authToken = "cd3ddc33390ff747859d9733f8a22055";  // Your Auth Token from www.twilio.com/console

            var twilio = new TwilioRestClient(accountSid, authToken);
            var message = twilio.SendMessage(
                "(413) 776-4608", // From (Replace with your Twilio number)
                "+21653851047", // To (Replace with your phone number)
                "Unfortunately! You have been banned from eventify. Please feel free to contact us for more informations."
                );

            if (message.RestException != null)
            {
                var error = message.RestException.Message;
                Console.WriteLine(error);
                Console.Write("Press any key to continue.");
                Console.ReadKey();
                return false;
            }
            return true;
        }
    }
}
