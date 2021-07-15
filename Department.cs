using System;
using System.Collections.Generic;
namespace main
{
    public class Department
    {
        public string name { get; set; }
        public Employee chief;
        public Dictionary<Group> groups;
        public Department(string name)
        {
            this.name = name;
            this.groups = new Dictionary<Group>();

        }
    }
}
