using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class PeopleViewModel
    {
        public List<Person> People { get; set; } = new List<Person>();
        public Person Person { get; set; }
    }
}