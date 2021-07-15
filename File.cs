using System;
using System.IO;
using System.Collections.Generic;
namespace main
{
    public class File
    {
        public StreamWriter sw;
        public StreamReader sr;
        public File(string filename, int type)
        {
            if (type == 1)
                sw = new StreamWriter(filename);
            else
                sr = new StreamReader(filename);
        }
        public void DataWriting(string str)
        {
            sw.WriteLine(str);
        }

        public void CloseFile()
        {
            sw.Flush();

            sw.Close();
        }
        public Dictionary<Employee>DataReadingEmployees(int position,Group gr,Department dep,Branch br,City city)
        {
            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            string str = sr.ReadLine();
            Dictionary<Employee> people = new Dictionary<Employee>();
            int count = 0;
            while (count < position && str!=null)
            {
                str=sr.ReadLine();
                count++;
            }
            count = 0;
            while (count < 10 && str != null)
            {
                    people.Add(str, new Employee(str,gr,br,dep,city));
                    str = sr.ReadLine();
                   count++;
            }
            sr.Close();

            return people;

        } public Dictionary<City> DataReadingCities()
        {
            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            string str = sr.ReadLine();
            Dictionary<City> people = new Dictionary<City>();
            while (str != null)
            {
                    people.Add(str, new City(str));
                    str = sr.ReadLine();
            }
            sr.Close();

            return people;

        } public Dictionary<Branch> DataReadingBranches()
        {
            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            string str = sr.ReadLine();
            Dictionary<Branch>people = new Dictionary<Branch>();
            while (str != null)
            {
                    people.Add(str, new Branch(str));
                    str = sr.ReadLine();
            }
            sr.Close();

            return people;

        } public Dictionary<Department> DataReadingDepartments()
        {
            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            string str = sr.ReadLine();
            Dictionary<Department> people = new Dictionary<Department>();
            while (str != null)
            {
                    people.Add(str, new Department(str));
                    str = sr.ReadLine();
            }
            sr.Close();

            return people;

        }
        public Dictionary<Group> DataReadingGroups()
        {
            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            string str = sr.ReadLine();
            Dictionary<Group> people = new Dictionary<Group>();
            while (str != null)
            {
                people.Add(str, new Group(str));
                str = sr.ReadLine();
            }
            sr.Close();

            return people;

        }
        
    }
}
