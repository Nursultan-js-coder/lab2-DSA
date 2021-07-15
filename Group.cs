using System;
using System.Collections.Generic;
namespace main
{
    public class Group
    {

        public string name { get; set; }
        public Employee chief;
        public Dictionary<Employee> employees;
        public Group(string name)
        {
           
            this.name = name;
            this.employees = new Dictionary<Employee>();
        }
        public Dictionary<string,string> Employees
        {
            get;set;
        }

     

    }
}
