using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadge
{
    public class BadgeRepo
    {

        private Dictionary<int, List<string>> _badgeCollection =
    new Dictionary<int, List<string>>();

        public void SeedContent()
        {
            _badgeCollection.Add(12345, new List<string>() { "A1" });
            _badgeCollection.Add(54321, new List<string> { "A7", "B3" });
            _badgeCollection.Add(21483, new List<string> { "A1", "B2", "A3", "B4", "4F", });

        }
        //_badgeCollection.Add(54321, new List<string>{"A7", "B3"});


        public bool AddBadgeToList(int badgeID, List<string> doors)
        {  
            int startingCount = _badgeCollection.Count;
            _badgeCollection.Add(badgeID, doors);
            bool wasAdded = _badgeCollection.Count == startingCount + 1;
            return wasAdded;
        }

        public void UpdateBadgeList(int badgeID, List<string> doors)
        {
            _badgeCollection[badgeID] = doors;
        }

        public Dictionary<int, List<string>> GetList()
        {
            return _badgeCollection;
        }

        public List<string> GetBadgeByNumber(int badgeID)
        {

            if (_badgeCollection.ContainsKey(badgeID))
            {
                return _badgeCollection[badgeID];
            }
            Console.WriteLine("That badge doesn't exist");
            return new List<string>();
            //foreach (BadgeList badgeItem in _badgeCollection)
            //{
            //    if (badgeItem.BadgeID == badgeID)
            //    {
            //        return badgeItem;
            //    }
            //}
        }
    }
}
