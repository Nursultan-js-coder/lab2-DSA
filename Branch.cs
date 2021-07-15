using System;
using System.Collections.Generic;

namespace main
{
    public class Branch
    {
        public string name { get; set; }
        public Employee director;
        public Dictionary<Department> departments;
        public Branch(string name)
        {
            this.name = name;
            this.departments=new  Dictionary<Department>();

    }
}
}
