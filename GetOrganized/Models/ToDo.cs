using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GetOrganized.Models
{
    public class ToDo
    {
        public bool Completed { get; set; }
        public string Title { get; set; }

        public static List<ToDo> ThingsToBeDone = new List<ToDo>
        {
            new ToDo{Title = "Get Milk", Completed=false}, 
            new ToDo{Title="Bring Home Bacon", Completed=false}
        };

    }
}