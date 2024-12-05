using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
    public class UserControler
    {
        public static void Usercontroler()
        {
            (IDBManager userDB,IDBManager stationDB,AuthService authService, WalletService walletService, TicketService ticketService, StationService stationService) = Interaction.Reboot("C:/Users/avish/Dev/HafifaTrain/Train/Train/DBs");
            Station station1 = new Station(0, "admin", new GeographicCoordinate(1, 1));
            Station station2 = new Station(0, "admin2", new GeographicCoordinate(2, 2));
            Ticket temp = new Ticket(0,station1,station2 );
            IUser user = new User("Admin",0000,Gender.male,0, temp);
            if (userDB.Get<User>() == null)
                userDB.Save(user);

            int choice = Interaction.WelcomeMessage();

            if (choice == 1)
            {
                while(!Interaction.Registry(user, authService, userDB))
                {
                    user.name = Interaction.GetNameFromUser();
                    user.id = Interaction.GetIdFromUser();
                    authService.RegisterUser(user, userDB);
                }
            }
            else if (choice == 2)
            {
                user = Interaction.TryLogin(authService,userDB);
            }

            while (Interaction.UserAction(user, userDB ,stationDB , authService, walletService, ticketService, stationService))
            {
                
            }

            Console.ReadKey();
        }

        
    }
}
