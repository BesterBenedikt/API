using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Service
{
    public class MatchService
    {
        public IEnumerable<T004_Match> GetAllMatches()
        {
            using (var dbc = new TeamDBEntities())
            {
                return dbc.T004_Match.ToList();
            }
        }
    }
}
