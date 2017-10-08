using Service.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Service
{
    public class PlayerService
    {
        public List<Domain.T002_Player> RawPlayers { get; }
        public List<Viewmodels.DisplayPlayer> DisplayPlayers { get; }

        public PlayerService()
        {
            RawPlayers = getRawPlayers();
            DisplayPlayers = getDisplayPlayers();

        }

        private List<Domain.T002_Player> getRawPlayers()
        {
            List<Domain.T002_Player> playerlist = new List<Domain.T002_Player>();

            using (var dbc = new Domain.TeamDBEntities())
            {
                return dbc.T002_Player.ToList();
            }
        }

        private List<DisplayPlayer> getDisplayPlayers()
        {
            
            var ts = new TeamService();
            var displayPlayers = new List<DisplayPlayer>();
            foreach (var rawPlayer in RawPlayers)
            {
                var displayPlayer = new DisplayPlayer();
                displayPlayer.importRawPlayer(rawPlayer);
                displayPlayer.TeamName = ts.getTeamNameById(rawPlayer.TeamId);
                displayPlayers.Add(displayPlayer);
            }

            return displayPlayers;
           
        }

        public Domain.T002_Player getPlayerById(int id)
        {
            using (var dbc = new Domain.TeamDBEntities())
            {
                return dbc.T002_Player.Where(player => player.Id == id).First();
            }
        
        
        }

    }
}
