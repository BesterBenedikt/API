using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamAPI.Models
{
    public class Match
    {
        public int id { get; set; }
        public Team teamHome { get; set; }
        public Team teamAway { get; set; }

        public DateTime kickOff { get; set; }

        public int goalsTeamHome { get; set; }

        public int goalsTeamAway { get; set; }

        public int eventID { get; set; }


    }
}