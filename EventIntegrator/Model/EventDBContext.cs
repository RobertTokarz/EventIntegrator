using System;
using System.Data.Entity;
using System.Linq;

namespace EventIntegrator.Model
{
    public class EventDBContext : DbContext
    {

        public EventDBContext()
            : base("name=EventDBContext")
        {
        }

        public DbSet<EventModel> Events { get; set; }

    }

   

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}