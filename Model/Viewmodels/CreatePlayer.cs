using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using System.Web;

namespace Model.Viewmodels
{
    public class CreatePlayer
    {
        public T002_Player player { get; set; }
        public List<T001_Teams> teamList { get; set; }
        public string FilePath { get; set; }

        public HttpPostedFileBase File { get; set; }


        public string Team { get; set; }

        public CreatePlayer()
        {
            var ts = new TeamService();
            teamList = ts.getTeams();
        }

    }
}
