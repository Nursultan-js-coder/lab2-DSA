using System;
using System.Collections.Generic;
namespace main
{
    public class City
    {

        public string name { get; set; }
        public Dictionary<Branch> branches;

        public City(string name)
        {
            this.name = name;
            this.branches = new Dictionary<Branch>();
        }


    }
}
