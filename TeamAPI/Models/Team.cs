using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamAPI.Models
{
    public class Team
    {
        public int id { get; set; }
        public string name { get; set; }

        public List<Player> listOfPlayers { get; set; }
    }
}