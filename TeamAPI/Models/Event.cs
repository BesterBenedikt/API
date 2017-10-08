using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamAPI.Models;
namespace TeamAPI.Models
{
    public abstract class Event
    {
        public int id { get; set; }

        public string name { get; set; }
        public List <Match> matches{ get; set; }


    }
}