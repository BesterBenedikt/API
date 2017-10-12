using System.Linq;
using Domain;
using System.Collections.Generic;

namespace Service
{
    public class EventService
    {
        public T003_Event getEventById(int id)
        {
            using (var dbc = new TeamDBEntities())
            {
                return dbc.T003_Event.Where(ev => ev.Id == id).First();
            }
        }

        public List<T003_Event> GetEvents()
        {
            using (var dbc = new TeamDBEntities())
            {
                return dbc.T003_Event.ToList();
            }
        }

        public void CreateEvent(T003_Event ev)
        {
            using (var dbc = new TeamDBEntities())
            {
                dbc.T003_Event.Add(ev);
                dbc.SaveChanges();
            }
        }

        public void DeleteEvent(int id)
        {
            using (var dbc = new TeamDBEntities())
            {
                    var ev = dbc.T003_Event.Where(e => e.Id == id).First();
                    dbc.T003_Event.Remove(ev);
            }
        }
    }
}
