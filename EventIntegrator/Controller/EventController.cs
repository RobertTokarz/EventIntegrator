using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventIntegrator.Model;

namespace EventIntegrator.Controller
{
    public class EventController
    {
        private EventDBContext _db;

        public void Add(List<EventModel> items)
        {
            using( _db = new EventDBContext())
            {
                foreach (var item in items)
                {
                    //update or add new event
                    var existingEvent = _db.Events.SingleOrDefault(x => x.Id == item.Id);
                    if (existingEvent != null)
                    {
                        _db.Entry(existingEvent).CurrentValues.SetValues(item);
                    }
                    else
                    {
                        _db.Events.Add(item);
                    }
                }
                _db.SaveChanges();

            }
           

        }


    }
}
