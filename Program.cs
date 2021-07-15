using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace main
{
    class Program
    {
        public static Organization neman = new Organization("neman");
        static Employee myEmployee = new Employee("demo");
        
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            File file = new File("cities.txt", 2);
            neman.cities = file.DataReadingCities();
            int position = 0;

            foreach (((string, City),(int,int))city in neman.cities.KeyValuePair)
            {
                file = new File("branches.txt", 2);
                city.Item1.Item2.branches = file.DataReadingBranches();

                foreach (((string, Branch), (int, int)) branch in city.Item1.Item2.branches.KeyValuePair)
                {

                    file = new File("departments.txt", 2);
                    branch.Item1.Item2.departments = file.DataReadingDepartments();
                    int depCount = 0;
                    foreach (((string, Department), (int, int)) dep in branch.Item1.Item2.departments.KeyValuePair)
                    {


                        file = new File("groups.txt", 2);
                        dep.Item1.Item2.groups = file.DataReadingGroups();
                        int groupCount = 0;
                        foreach (((string, Group), (int, int)) group in dep.Item1.Item2.groups.KeyValuePair)
                        {

                            file = new File("employees.txt", 2);
                            group.Item1.Item2.employees = file.DataReadingEmployees(position, group.Item1.Item2, dep.Item1.Item2, branch.Item1.Item2, city.Item1.Item2);
                            int flag = 0;
                            foreach (((string, Employee), (int, int)) emp in group.Item1.Item2.employees.KeyValuePair)
                            {
                                if (depCount == 0)
                                {
                                    if (groupCount == 0)
                                    {
                                        if (flag == 0)
                                        {
                                            branch.Item1.Item2.director = emp.Item1.Item2;
                                            emp.Item1.Item2.chiefOfBranch = branch.Item1.Item2;
                                        }
                                    }

                                }


                                if (groupCount == 1)
                                {
                                    if (flag == 1)
                                    {
                                        dep.Item1.Item2.chief = emp.Item1.Item2;
                                        emp.Item1.Item2.chiefOfDep = dep.Item1.Item2;
                                        Console.WriteLine($"city:{city.Item1.Item2.name}|" +
                                            $"branch:{branch.Item1.Item2.name}| dep:{dep.Item1.Item2.name}|chief of dep:{dep.Item1.Item2.chief.name}");
                                    }
                                }

                                if (flag == 2)
                                {
                                    group.Item1.Item2.chief = emp.Item1.Item2;
                                    emp.Item1.Item2.chiefOfGroup = group.Item1.Item2;
                                }
                                flag++;
                            }


                            position += 10;
                            groupCount++;
                        }
                        depCount++;

                    }

                }
            }

            while (true)
            {

                string[] fields2 = Info.GetInfo();
                Info.DrawTable(neman, fields2);
                string str = Console.ReadLine();
                if (str == "e") break;
            }

        }



    }

}
