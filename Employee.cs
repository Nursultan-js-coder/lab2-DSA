using System;
using System.Collections.Generic;

namespace main
{
    public class Employee
    {
        public static Dictionary<Employee> people;
        public string name { get; set; }
        public Group group;
        public Department department;
        public Branch branch;
        public City city;
        public Department chiefOfDep;
        public Branch chiefOfBranch;
        public Group chiefOfGroup;

        public Employee(string name)
        {
            people = new Dictionary<Employee>();
            this.name = name;
        }
        
        public Employee(string name,Group group,Branch br,Department dep,City city)
        {
            
            this.name = name;
            this.group = group;
            this.branch = br;
            this.department = dep;
            this.city = city;
            people.Add(name,this);
        } 
   
        public static Employee GetPerson(string name)
        {
            return people.Get(name);
        }
        

        

    }
}
