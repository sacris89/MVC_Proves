using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Models
{
    public class Categories
    {


        int id;
        String name, description;

        public Categories(int id, string name, string description)
        {
            this.id = id;
            this.name = name;
            this.description = description;
        }


        public Categories() { }



        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
    }
}
