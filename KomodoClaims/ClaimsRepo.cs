using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KomodoClaims
{
    public class ClaimsRepo
    {
        private List<ClaimsList> _claimscontents = new List<ClaimsList>();
        public bool AddClaimToList(ClaimsList claim)
        {
            int startingCount = _claimscontents.Count;
            _claimscontents.Add(claim);
            bool wasAdded = _claimscontents.Count == startingCount + 1;
            return wasAdded;
        }

        public List<ClaimsList> GetList()
        {
            return _claimscontents;
        }

        public ClaimsList GetClaimByNumber(int claimID)
        {
            foreach (ClaimsList claimItem in _claimscontents)
            {
                if (claimItem.ClaimID == claimID)
                {
                    return claimItem;
                }
            }
            return null;
        }

        public void ClaimSelection(int claimNumber)
        {
            Console.Clear();
            ClaimsList claim = GetClaimByNumber(claimNumber);
            Console.WriteLine($"{"Claim ID",-8} {"Claim Type",-11} {"Description",-25} {"Amount",-7} {"Date of Accident",-17} {"Date of Claim",-15} Claim Valid?");
            Console.WriteLine($"{claim.ClaimID,-8} {claim.ClaimType,-11} {claim.ClaimDescribe,-25} {claim.ClaimAmount,-7} {claim.ClaimAccident.ToString("MM/dd/yyyy"),-17} {claim.ClaimDate.ToString("MM/dd/yyyy"),-15} {claim.ClaimValid}\n");
            Console.WriteLine("Do you wish to take this claim?\n" +
                "Y/N");

            string consoleResponse = Console.ReadLine().ToUpper();

            if (consoleResponse == "Y")
            {
                Console.WriteLine("Claim accepted. Press any key to return to the menu.");
                RemoveClaimFromList(claimNumber);
                Console.ReadKey();
            }
            else if (consoleResponse == "N")
            {
                Console.WriteLine("Claim not accepted. Press any key to return to the menu.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("That is not a valid input.");
                Console.ReadKey();
            }

        }

        public bool RemoveClaimFromList(int claimNumber)
        {
            ClaimsList removal = GetClaimByNumber(claimNumber);

                _claimscontents.Remove(removal);
                return true;
        }
    }
}
