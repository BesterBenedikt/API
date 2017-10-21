using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class TeamService
    {
        public List<T001_Teams> getTeams()
        {
            using (var dbc = new TeamDBEntities())
            {
                return dbc.T001_Teams.ToList();
            }
        }

        public string getTeamNameById(int id)
        {
            using (var dbc = new Domain.TeamDBEntities())
            {
                return getTeams().Where(team => team.Id == id).First().Name;
            }
        }

        public List<T002_Player> getPlayersByTeamId(int id)
        {
            using (var dbc = new Domain.TeamDBEntities())
            {
                return dbc.T002_Player.Where(teamPlayer => teamPlayer.TeamId == id).ToList();
            }
        }

        public int GetTeamIdByTeamName(string name)
        {
            using (var dbc = new Domain.TeamDBEntities())
            {
                return dbc.T001_Teams.Where(team => team.Name == name).First().Id;
            }
        }
    }
}
