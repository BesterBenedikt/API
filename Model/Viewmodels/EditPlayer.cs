using System;
using System.Collections.Generic;
using Domain;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Viewmodels
{
    public class EditPlayer:DisplayPlayer
    {

        public List<T001_Teams> TeamList { get; }
        private TeamService ts;
        private PlayerService ps;
        public EditPlayer()
        {
            ts = new TeamService();
            ps = new PlayerService();
            TeamList = ts.getTeams();
        }
        public void ImportPlayer(int id)
        {
            DisplayPlayer displayPlayer = new DisplayPlayer();
            displayPlayer = ps.GetDisplayPlayer(id);

            Id = displayPlayer.Id;
            Prename = displayPlayer.Prename;
            Surname = displayPlayer.Surname;
            Number = displayPlayer.Number;
            TeamId = displayPlayer.TeamId;
            TeamName = displayPlayer.TeamName;
            profilePictureURL = displayPlayer.profilePictureURL;
        }
    }


}
