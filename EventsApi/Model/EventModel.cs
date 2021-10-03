using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventIntegrator.Model
{
    [Table("Events")]
    public class EventModel
    {
        [Key]
        [Required]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string EventId { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Venue { get; set; }
        public string Promoter { get; set; }
    }
}
