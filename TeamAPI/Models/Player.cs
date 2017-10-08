using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamAPI.Models
{
    public class Player
    {
        public int id { get; set; }
        public string name { get; set; }

        public int teamId { get; set; }
    }
}