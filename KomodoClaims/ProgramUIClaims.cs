using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims
{
    public class ProgramUIClaims
    {
        public readonly ClaimsRepo _repo = new ClaimsRepo();
        public void Run()
        {
            SeedContentList();
            RunMenu();
        }
        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Please select an option:\n" +
                    "1. Show all claims\n" +
                    "2. Select a claim\n" +
                    "3. Add a claim");

                string selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        ShowMenu();
                        Console.ReadKey();
                        break;
                    case "2":
                        SelectClaim();
                        break;
                    case "3":
                        AddClaim();
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option.\n");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine($"{"Claim ID",-8} {"Claim Type",-11} {"Description",-25} {"Amount",-7} {"Date of Accident",-17} {"Date of Claim",-15} Claim Valid?");
            List<ClaimsList> listOfClaims = _repo.GetList();
            foreach (ClaimsList claimshow in listOfClaims)
            {
                DisplayContent(claimshow);
            }
        }
        private void DisplayContent(ClaimsList claim)
        {
            Console.WriteLine($"{claim.ClaimID,-8} {claim.ClaimType,-11} {claim.ClaimDescribe,-25} {claim.ClaimAmount,-7} {claim.ClaimAccident.ToString("MM/dd/yyyy"),-17} {claim.ClaimDate.ToString("MM/dd/yyyy"),-15} {claim.ClaimValid}");
        }

        private void DisplayContentID(ClaimsList claim)
        {
            Console.WriteLine($"{claim.ClaimID, -8} {claim.ClaimValid}");
        }

        private void SelectClaim()
        {
            Console.WriteLine("Select a claim ID:");
            List<ClaimsList> claimMenu = _repo.GetList();
            Console.WriteLine($"{"Claim ID", -8} {"Claim Valid?"}");
            foreach (ClaimsList ID in claimMenu)
            {
                DisplayContentID(ID);
            }
            int claimNumber = Convert.ToInt32(Console.ReadLine());
            _repo.ClaimSelection(claimNumber);
        }

        private void AddClaim()
        {
            Console.Clear();
            Console.WriteLine("Enter the claim ID:");
            int claimID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the claim type:");
            string claimType = Console.ReadLine();

            Console.WriteLine("Enter a short description of the claim:");
            string claimDescribe = Console.ReadLine();

            Console.WriteLine("Enter the amount of the claim:");
            double claimAmount = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the date of the accident (MM/DD/YYYY): ");
            bool claimAccidentNotValid = true;
            DateTime claimAccident = new DateTime();
            while (claimAccidentNotValid)
            {
                if (DateTime.TryParse(Console.ReadLine(), out claimAccident))
                {
                    claimAccidentNotValid = false;
                }
                else
                {
                    Console.WriteLine("You have entered an incorrect value.");
                }
            }

            Console.WriteLine("Enter the date of the claim (MM/DD/YYYY):");
            bool claimDateNotValid = true;
            DateTime claimDate = new DateTime();
            while (claimDateNotValid)
            {
                if (DateTime.TryParse(Console.ReadLine(), out claimDate))
                {
                    claimDateNotValid = false;
                }
                else
                {
                    Console.WriteLine("You have entered an incorrect value.");
                }
            }


            ClaimsList newClaimItem = new ClaimsList(claimID, claimType, claimDescribe, claimAmount, claimAccident, claimDate);

            _repo.AddClaimToList(newClaimItem);
        }

        private void SeedContentList()
        {
            ClaimsList majorOof = new ClaimsList(3448, "Car", "Car accident on 465", 400.00, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27));
            ClaimsList oohBurn = new ClaimsList(9723, "Home", "House fire in kitchen", 4000.00, new DateTime(2018, 4, 11), new DateTime(2018, 4, 12));
            ClaimsList seriouslyPancakes = new ClaimsList(6666, "Theft", "Stolen Pancakes", 400.00, new DateTime(2018, 4, 27), new DateTime(2018, 6, 01)); //Raise his rates. Why would you file a claim for stolen pancakes over a month later?

            _repo.AddClaimToList(majorOof);
            _repo.AddClaimToList(oohBurn);
            _repo.AddClaimToList(seriouslyPancakes);


        }

    }
}
