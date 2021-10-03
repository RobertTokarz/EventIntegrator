using Microsoft.EntityFrameworkCore;
using System;

using System.Linq;

namespace EventIntegrator.Model
{
    public class EventDBContext : DbContext
    {

        public EventDBContext(DbContextOptions<EventDBContext> options) : base(options) { }

     
        public DbSet<EventModel> Events { get; set; }

    }

   

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}