using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
    public class Interaction
    {
        public static (IDBManager,IDBManager,AuthService,WalletService,TicketService,StationService) Reboot(string DBPath)
        {
            IDBManager userDB = new DBManager($"{DBPath}/UsersDB.json");
            IDBManager stationDB = new DBManager($"{DBPath}/StationDB.json");
            AuthService authService = new AuthService();
            WalletService walletService = new WalletService();
            TicketService ticketService = new TicketService();
            StationService stationService = new StationService();
            return (userDB, stationDB, authService, walletService, ticketService, stationService);
        }
        public static int WelcomeMessage()
        {
            Console.WriteLine("Welcome to our Train system!");
            Console.WriteLine("Please select the action you want to perform:");
            Console.WriteLine("1. Create a new user");
            Console.WriteLine("2. Log in with an existing user");

            if (int.TryParse(Console.ReadLine(), out int choice) && (choice == 1 || choice == 2))
            {
                return choice;
            }

            Console.WriteLine("Invalid input. Please enter 1 or 2.");
            return WelcomeMessage(); // Recursively retry
        }

        public static (int, string) GetParamsFromUser()
        {
            string name = GetNameFromUser();
            int id = GetIdFromUser();
            return (id, name);
        }

        public static void SetUserParams(IUser user)
        {
            Console.WriteLine("Enter the following details:");

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Gender:");
            Console.WriteLine("1. Male");
            Console.WriteLine("2. Female");
            Console.WriteLine("3. joe");
            int genderChoice = int.Parse(Console.ReadLine());
            Gender gender = (Gender)(genderChoice - 1);

            user.name = name;
            user.id = id;
            user.Gender = gender;
            user.Wallet = 0;

            Console.WriteLine($"Hi your user is: {user.name}, ID: {user.id}, Gender: {user.Gender}, Balance: {user.Wallet}");
        }

        public static int GetIdFromUser()
        {
            Console.Write("Enter ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                return id;
            }
            Console.WriteLine("Invalid ID. Please enter a valid number.");
            return GetIdFromUser(); // Retry
        }
        public static string GetNameFromUser()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            return name;
        }

        public static bool Registry(IUser user,AuthService authService, IDBManager db)
        {
            try
            {
                SetUserParams(user);
                authService.RegisterUser(user, db);
            }
            catch (Exception ex) // Catch any exception thrown by authService.RegisterUser or db.Save
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        public static (int, string) IncorectUserParams()
        {
            Console.WriteLine("Incorrect username or ID, please try again");
            return GetParamsFromUser();
        }

        public static void AddMoneyToWallet(IUser user, IDBManager db, WalletService walletService)
        {
            try
            {
                Console.WriteLine("Enter the amount of money you want to add to your wallet:");
                if (int.TryParse(Console.ReadLine(), out int amount) && amount > 0)
                {
                    walletService.LoadMoney(user, amount, db);
                    Console.WriteLine("Money successfully added to your wallet.");
                }
                else
                {
                    Console.WriteLine("Invalid amount. Please enter a positive number.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding money: {ex.Message}");
            }
        }

        public static void DeductMoneyFromWallet(IUser user, IDBManager db, WalletService walletService)
        {
            try
            {
                Console.WriteLine("Enter the amount of money you want to deduct from your wallet:");
                if (int.TryParse(Console.ReadLine(), out int amount) && amount > 0)
                {
                    walletService.DeductMoney(user, amount, db);
                    Console.WriteLine("Money successfully deducted from your wallet.");
                }
                else
                {
                    Console.WriteLine("Invalid amount. Please enter a positive number.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deducting money: {ex.Message}");
            }
        }

        //func that the user choos 2 station from options from the stathion DB, soece station and destenation station and buy a ticket for him that means that the user will pay for the ticket and the ticket will be added to the user tickes
        public static void BuyTicket(IUser user, IDBManager userDB, IDBManager stationDB, WalletService walletService, TicketService ticketService, StationService stationService)
        {
            try
            {
                Console.WriteLine("Please select the station you want to depart from:");
                // Get stations from DB

                List<Station> stations = stationDB.Get<Station>();
                for (int i = 0; i < stations.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {stations[i].name}");
                }
                if (int.TryParse(Console.ReadLine(), out int sourceIndex) && sourceIndex > 0 && sourceIndex <= stations.Count)
                {
                    IStation sourceStation = stations[sourceIndex - 1];
                    Console.WriteLine("Please select the station you want to arrive at:");
                    for (int i = 0; i < stations.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {stations[i].name}");
                    }
                    if (int.TryParse(Console.ReadLine(), out int destIndex) && destIndex > 0 && destIndex <= stations.Count)
                    {
                        IStation destStation = stations[destIndex - 1];
                        Console.WriteLine($"You selected to travel from {sourceStation.name} to {destStation.name}.");

                        Console.WriteLine("The ticket price is:");
                        double distance = sourceStation.location.DistanceTo(destStation.location);
                        int price = ticketService.CalculatePrice(distance);
                        ITicket ticket = new Ticket(price,destStation, sourceStation);
                        Console.WriteLine(price);
                        
                        if (ticket.price > (userDB.GetByAtt<User>("name", user.name)).Wallet)
                        {
                            throw new Exception("you dont have enough money to buy the ticket");
                        }
                        ticketService.BuyTicket(user, sourceStation, destStation, stationService, userDB);
                        
                        userDB.UpdateAtt(user,"name", "Ticket", ticket);
                        user = userDB.GetByAtt<IUser>("name", user.name);
                        Console.WriteLine("Ticket successfully purchased!");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while buying a ticket: {ex.Message}");
            }
        }


        public static bool UserAction(IUser user, IDBManager userDB , IDBManager stationDB, AuthService authService, WalletService walletService,TicketService ticketService, StationService stationService)
        {
            try
            {
                Console.WriteLine("Please select the action you want to perform:");
                Console.WriteLine("1. Add money to wallet");
                Console.WriteLine("2. Buy a Ticket");
                Console.WriteLine("3. See how much money you have");
                Console.WriteLine("4. Exit");

                user = Refresh(user.name, userDB);

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            
                            AddMoneyToWallet(user, userDB, walletService);
                            return true;
                        case 2:
                            BuyTicket(user, userDB, stationDB ,walletService, ticketService, stationService);
                            return true;
                        case 3:
                            Console.WriteLine($"Your balance is: {user.Wallet}");
                            return true;
                        case 4:
                            Console.WriteLine("Goodbye!");
                            return false;
                        default:
                            Console.WriteLine("Invalid choice. Please select a valid option.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
            return true; // Retry menu
        }
        public static IUser TryLogin(AuthService authService, IDBManager db)
        {
            try
            {
                (int id, string name) = GetParamsFromUser();
                while (!authService.SignInUser(name, id, db))
                {
                    Console.WriteLine("Login failed. Incorrect username or ID.");
                    (id, name) = IncorectUserParams();
                }
                Console.WriteLine("Login successful!");
                return db.GetByAtt<User>("name", name);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during login: {ex.Message}");
                return null;
            }
        }

        public static IUser Refresh(string userName, IDBManager userDB)
        {
            IUser user = new User();
            user = userDB.GetByAtt<IUser>("name", userName);
            return user;
        }
    }


}
