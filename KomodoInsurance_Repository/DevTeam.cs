using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance_Repository
{
    public class DevTeam
    {
        private List<Developer> _listOfTeamDevelopers = new List<Developer>();

        public string TeamName { get; set; }
        public int TeamIdentificationNumber { get; set; }

        public DevTeam() { }


        public DevTeam(string teamName, int teamIdentificationNumber)

        {
            TeamName = teamName;
            TeamIdentificationNumber = teamIdentificationNumber;

        }

        public DevTeam(string teamName, int teamIdentificationNumber, List<Developer> developers)
            : this(teamName,teamIdentificationNumber)

        {
            _listOfTeamDevelopers = developers;
        }

        public bool AddDevToList(Developer developers)
        {
            int initialDevelopers = _listOfTeamDevelopers.Count;

            _listOfTeamDevelopers.Add(developers);

            if (_listOfTeamDevelopers.Count > initialDevelopers)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Developer> GetDevList()
        {
            return _listOfTeamDevelopers;
        }

        public List<Developer> GetDevListWhoNeedPluralSight()
        {
            List<Developer> need = new List<Developer>() { };
            foreach(Developer developer in _listOfTeamDevelopers)
            {
                if (!developer.PluralSight)
                {
                    need.Add(developer);
                }
            }
                
            return need;
        }



        public bool RemoveDevFromList(int identificationNumber)
        {
            Developer content = GetDevById(identificationNumber);

            int initialCount = _listOfTeamDevelopers.Count;

            _listOfTeamDevelopers.Remove(content);

            if (initialCount > _listOfTeamDevelopers.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Developer GetDevById(int identificationNumber)
        {
            foreach (Developer dev in _listOfTeamDevelopers)
            {
                if (dev.IdentificationNumber == identificationNumber)
                {
                    return dev;
                }
            }

            return null;
        }



    }
}
