using System;
using System.Collections.Generic;
namespace main
{
    public class Organization
    {
        public string name { get; set; }
        //List<Branch> branches;
        public Dictionary<City> cities;
        public Organization(string name)
        {
            this.name = name;
            this.cities = new Dictionary<City>();
        }

    }
}
