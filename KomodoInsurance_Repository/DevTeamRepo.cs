using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance_Repository
{
    public class DevTeamRepo
    {
        private List<DevTeam> _listOfTeams = new List<DevTeam>();

        //Create
        public void AddTeamToList(DevTeam content)
        {
            _listOfTeams.Add(content);
        }


        //Read
        public List<DevTeam> GetTeamList()
        {
            return _listOfTeams;
        }

        //Update
        public bool UpdateExistingContent(string originalTitle, DevTeam newContent)
        {
            //Find the content
            DevTeam oldContent = GetTeamByName(originalTitle);

            //Update the content
            if (oldContent != null)
            {
                oldContent.TeamName = newContent.TeamName;
                oldContent.TeamIdentificationNumber = newContent.TeamIdentificationNumber;
                return true;
            }
            else
            {
                return false;
            }

        }


        //Delete
        public bool RemoveTeamFromList(string teamName)
        {
            DevTeam content = GetTeamByName(teamName);

            if (content == null)
            {
                return false;
            }

            int initialCount = _listOfTeams.Count;
            _listOfTeams.Remove(content);

            if (initialCount > _listOfTeams.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //Helper method
        public DevTeam GetTeamByName(String teamName)
        {
            foreach (DevTeam content in _listOfTeams)
            {
                if (content.TeamName.ToLower() == teamName.ToLower())
                {
                    return content;
                }
            }

            return null;
        }
    }
}
