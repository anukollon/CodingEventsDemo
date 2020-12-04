using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEventsDemo.Models
{
    public class EventCategory
    {
        public int Id { get; set; }
        public String Name { get; set; }

        public EventCategory()
        {

        }

        public EventCategory(String s)
        {
            Name = s;
        }
    }
}
