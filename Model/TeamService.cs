using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class TeamService
    {
        public List<Domain.T001_Teams> teams { get; }

        public TeamService()
        {
            teams = getTeams();

        }

        private List<Domain.T001_Teams> getTeams()
        {
            using (var dbc = new Domain.TeamDBEntities())
            {
                return dbc.T001_Teams.ToList();
            }
        }

        public string getTeamNameById(int id)
        {
            return teams.Where(team => team.Id == id).First().Name;
        }
    }
}
