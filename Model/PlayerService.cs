using Service.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;

namespace Service
{
    public class PlayerService
    {
        public T002_Player insertPlayer { get; set; }
        private TeamService ts;
        private StorageService.StorageService ss;

        public PlayerService()
        {
            insertPlayer = new T002_Player();
            ts = new TeamService();
            ss = new StorageService.StorageService();
        }

        public void ImportInsertPlayer(string preName, string surName, int number, int teamId )
        {
            insertPlayer.Prename = preName;
            insertPlayer.Surname = surName;
            insertPlayer.Number = number;
            insertPlayer.TeamId = teamId;
        }
        private List<T002_Player> getRawPlayers()
        {
            using (var dbc = new TeamDBEntities())
            {
                return dbc.T002_Player.ToList();
            }
        }

        public void Create(T002_Player player, string imageUrl)
        {
            using (var dbc = new TeamDBEntities())
            {
                dbc.T002_Player.Add(player);
                dbc.SaveChanges();
            }

            ss.UploadElement(imageUrl, player.Id);
        }


        public List<DisplayPlayer> getDisplayPlayers()
        {

            List<DisplayPlayer> displayPlayers = new List<DisplayPlayer>();
            foreach (var rawPlayer in getRawPlayers())
            {
                var displayPlayer = new DisplayPlayer();
                displayPlayer.importRawPlayer(rawPlayer);
                displayPlayer.TeamName = ts.getTeamNameById(rawPlayer.TeamId);
                displayPlayer.profilePictureURL = ss.getURL(rawPlayer.Id.ToString());
                displayPlayers.Add(displayPlayer);
            }
            return displayPlayers;
        }

        public T002_Player getPlayerById(int id)
        {
            using (var dbc = new TeamDBEntities())
            {
                return dbc.T002_Player.Where(player => player.Id == id).First();
            }
        }

        public List<T002_Player> getPlayersByTeam(T001_Teams team)
        {
            return team.T002_Player.ToList();
        }
    }
}
