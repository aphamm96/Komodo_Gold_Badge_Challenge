using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KomodoBadge
{
    public class ProgramUIBadge
    {
        private readonly BadgeRepo _badgerepo = new BadgeRepo();
        public void Run()
        {
            _badgerepo.SeedContent();
            RunMenu();
        }
        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Hello admin. Please select an option:\n" +
                    "1. List all badges\n" +
                    "2. Add a badge\n" +
                    "3. Edit a badge");

                string selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        ShowBadges();
                        Console.ReadKey();
                        break;
                    case "2":
                        AddABadge();
                        break;
                    case "3":
                        EditABadge();
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option.\n");
                        Thread.Sleep(2000);
                        break;
                }
            }
        }

        private void ShowBadges()
        {
            Console.Clear();
            Console.WriteLine($"{"Badge ID",-9} Accessible Doors");
            Dictionary<int, List<string>> listOfBadges = _badgerepo.GetList();
            foreach (int badgeID in listOfBadges.Keys)
            {
                DisplayContent(badgeID, listOfBadges[badgeID]);
            }
        }
        private void DisplayContent(int badgeID, List<string> doors)
        {
            Console.Write($"{badgeID,-10}");
            foreach (string doorCode in doors)
            {
                Console.Write($"{doorCode} ");
            }
            Console.WriteLine("\n");
        }

        private void AddABadge()
        {
            Console.Clear();
            Console.WriteLine("What is the badge ID?");
            int badgeID = Convert.ToInt32(Console.ReadLine());
            //Dictionary.Add(badgeID, new List<string>());
            Console.WriteLine("Enter what door it has access to:");
            List<string> doors= new List<string>();//Create a new empty list here
            bool doorSelection = true;
            while (doorSelection)
            {
                string doorID = Console.ReadLine();
                doors.Add(doorID);
                Console.WriteLine("Do you want to add another door? Y/N");
                string addAnother = Console.ReadLine().ToUpper();
                if (addAnother == "Y")
                {
                    Console.WriteLine("Enter what door it has access to:");
                }
                else if (addAnother == "N")
                {
                    Console.WriteLine("Badge has been added. Returning to menu...");
                    Thread.Sleep(3000);
                    doorSelection = false;
                }
                else
                {
                    Console.WriteLine("That was not a yes or no. Returning to menu...");
                    Thread.Sleep(3000);
                    doorSelection = false;
                }
            }
            //AddBadgeToList();
            _badgerepo.AddBadgeToList(badgeID, doors); //reference empty list here
        }

        private void EditABadge()
        {
            Console.Clear();
            Console.WriteLine("Select a badge to update:");
            Console.WriteLine($"{"Badge ID",-9} Accessible Doors");
            Dictionary<int, List<string>> listOfBadges = _badgerepo.GetList();
            foreach (int badgeID in listOfBadges.Keys)
            {
                DisplayContent(badgeID, listOfBadges[badgeID]);
            }
            Console.WriteLine("\n");
            int selectedBadgeID = Convert.ToInt32(Console.ReadLine());
            List<string> doors= _badgerepo.GetBadgeByNumber(selectedBadgeID);
            if (doors.Count == 0)
            {
                Console.WriteLine("Returning to main menu...");
                Thread.Sleep(3000);
                RunMenu();
            }
            else
            {
            Console.Clear();
            Console.Write($"{selectedBadgeID,-10}");
            
            foreach (string doorCode in doors)
            {
                Console.Write($"{doorCode} ");
            }
            Console.WriteLine("Select an option:\n" +
                "1. Add a door\n" +
                "2. Remove a door\n" +
                "3. Return to home menu");
            string selection = Console.ReadLine();

            switch (selection)
            {
                case "1":
                    AddTheDoor(selectedBadgeID, doors);
                    break;
                case "2":
                    RemoveTheDoor(selectedBadgeID, doors);
                    break;
                case "3":
                    RunMenu();
                    break;
                default:
                    Console.WriteLine("Please enter a valid option.\n");
                    Thread.Sleep(2000);
                    break;
            }
            }
        }

        private void AddTheDoor(int selectedBadgeID, List<string> doors)
        {
            Console.WriteLine("Enter a door to add:");
            string doorInput = Console.ReadLine().ToUpper();
            doors.Add(doorInput);
            _badgerepo.UpdateBadgeList(selectedBadgeID, doors);

        }
        private void RemoveTheDoor(int selectedBadgeID, List<string> doors)
        {
            Console.WriteLine("Enter a door to remove:");
            string doorInput = Console.ReadLine().ToUpper();
            doors.Remove(doorInput);
            _badgerepo.UpdateBadgeList(selectedBadgeID, doors);

        }
    }
}
