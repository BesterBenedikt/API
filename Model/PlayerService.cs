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


        public void Edit(EditPlayer editPlayer)
        {

            T002_Player player;
                using (var dbc = new TeamDBEntities())
                {
                player = dbc.T002_Player.Where(p => p.Id == editPlayer.Id).First();
                player.Surname = editPlayer.Surname;
                player.Prename = editPlayer.Prename;
                player.Number = editPlayer.Number;
                player.TeamId = editPlayer.TeamId;
                dbc.SaveChanges();

                }
       
        }

        public void Delete(int Id)

        {
            T002_Player player;
            using (var dbc = new TeamDBEntities())
            {
                player = dbc.T002_Player.Where(p => p.Id == Id).First();
                dbc.T002_Player.Remove(player);
                dbc.SaveChanges();
            }
        }


public List<DisplayPlayer> getDisplayPlayers()
        {

            List<DisplayPlayer> displayPlayers = new List<DisplayPlayer>();
            foreach (var rawPlayer in getRawPlayers())
            {
                var displayPlayer = GetDisplayPlayer(rawPlayer.Id);
                displayPlayers.Add(displayPlayer);
            }
            return displayPlayers;
        }


        public DisplayPlayer GetDisplayPlayer(int id)
        {
            DisplayPlayer displayPlayer = new DisplayPlayer();
            T002_Player rawPlayer = new T002_Player();

            using (var dbc = new TeamDBEntities())
            {
                rawPlayer = dbc.T002_Player.Where(p => p.Id == id).First();

            }
            displayPlayer.importRawPlayer(rawPlayer);
            displayPlayer.TeamName = ts.getTeamNameById(rawPlayer.TeamId);
            displayPlayer.profilePictureURL = ss.getURL(rawPlayer.Id.ToString());

            return displayPlayer;
 
        }

        public List<T002_Player> getPlayersByTeam(T001_Teams team)
        {
            return team.T002_Player.ToList();
        }


    }
}
