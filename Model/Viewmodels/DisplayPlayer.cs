using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Viewmodels
{
    public class DisplayPlayer
    {
        public int Id { get; set; }
        public string Prename { get; set; }
        public string Surname { get; set; }
        public int Number { get; set; }
        public int TeamId { get; set; }

        public string TeamName { get; set; }

        public string profilePictureURL { get; set; }

        public void importRawPlayer(Domain.T002_Player rawPlayer)
        {
            Id = rawPlayer.Id;
            Prename = rawPlayer.Prename;
            Surname = rawPlayer.Surname;
            Number = rawPlayer.Number;
            TeamId = rawPlayer.TeamId;
        }
    }




}
