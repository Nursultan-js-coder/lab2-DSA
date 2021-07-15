using System;
using System.Collections.Generic;
namespace main
{
    public class Info
    {
        static int TableWidth=205;
        public Info()
        {
        }
        public static string[] GetInfo()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintLine();
            PrintRow("Data Base Administration Center");
            PrintLine();
            PrintRow("enter data:", "            ");
            PrintLine();
            Console.SetCursorPosition(105, 3);
            string data;
            data = Console.ReadLine();
            data = data.TrimEnd(' ');
            data = data.TrimStart(' ');
            string[] res = data.Split(" ");
            Console.SetCursorPosition(0, 4);
            Console.ForegroundColor = ConsoleColor.White;

            return res;

        }
        public static void PrintLine()
        {
            Console.WriteLine(new string('-', TableWidth));
        }

        public static void PrintRow(params string[] columns)
        {
            int width = (TableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        public static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
        public static void DrawTable(Organization neman, params string[] fields)
        {
            Console.ForegroundColor = ConsoleColor.White;


            switch (fields.Length)
            {
                case 1:

                    PrintLine();
                    PrintRow("branches of City: " + fields[0], "Director: ");
                    PrintLine();
                    foreach (((string, Branch),(int,int)) branch in neman.cities.Get(fields[0]).branches.KeyValuePair)
                    {

                        PrintLine();
                        PrintRow(branch.Item1.Item1, branch.Item1.Item2.director.name);
                        PrintLine();
                    }
                    break;
                case 2:

                    Branch br = neman.cities.Get(fields[0]).branches.Get(fields[1]);
                    PrintLine();
                    PrintRow("Departments of branch : " + fields[1], "Chief : ");
                    PrintLine();
                    foreach (((string, Department),(int,int)) dep in br.departments.KeyValuePair)
                    {

                        PrintLine();


                        PrintRow(dep.Item1.Item1, dep.Item1.Item2.chief.name);
                        PrintLine();
                    }
                    break;
                case 3:

                    //if(Convert.ToInt32(fields[2])>=1960&& Convert.ToInt32(fields[2]) <= 2002)
                    if (int.TryParse(fields[2], out _))
                    {
                        try
                        {
                            Employee employee = Employee.people.Get(String.Join(' ', fields));
                            if (employee.chiefOfBranch != null || employee.chiefOfDep != null||employee.chiefOfGroup!=null)
                            {
                                if (employee.chiefOfBranch != null)
                                {
                                    PrintLine();
                                    PrintRow(" employee (chief of branch): ", "branch: ", "group: ", "department : ", "city: ");
                                    PrintLine();
                                    PrintLine();
                                    PrintRow(employee.name, employee.branch.name, employee.group.name, employee.department.name, employee.city.name);
                                    PrintLine();
                                    //Console.WriteLine($"chief of branch :{employee.chiefOfBranch.name}");
                                }
                                else if(employee.chiefOfDep!=null)
                                {
                                    PrintLine();
                                    PrintRow(" employee (chief of department): ", "department: ", "group: ", "branch : ", "city: ");
                                    PrintLine();
                                    PrintLine();
                                    PrintRow(employee.name, employee.department.name, employee.group.name, employee.branch.name, employee.city.name);
                                    PrintLine();
                                }
                                else
                                {
                                    PrintLine();
                                    PrintRow(" employee (chief of group): ", "department: ", "group: ", "branch : ", "city: ");
                                    PrintLine();
                                    PrintLine();
                                    PrintRow(employee.name, employee.department.name, employee.group.name, employee.branch.name, employee.city.name);
                                    PrintLine();
                                }
                            }
                            else
                            {
                                PrintLine();
                                PrintRow(" employee: ", "group  : ", "department: ", "branch : ", "city: ");
                                PrintLine();
                                PrintLine();
                                PrintRow(employee.name, employee.group.name, employee.department.name, employee.branch.name, employee.city.name);
                                PrintLine();
                            }

                        }
                        catch (ArgumentNullException)
                        {
                            PrintLine();
                            PrintRow("does not exists");
                            PrintLine();
                        }

                    }
                    else
                    {

                        PrintLine();
                        PrintRow(" Groups of department: " + fields[2], "Chief  : ");
                        PrintLine();
                        Department department = neman.cities.Get(fields[0]).branches.Get(fields[1]).departments.Get(fields[2]);
                        foreach (((string, Group),(int,int)) gr in department.groups.KeyValuePair)
                        {
                            PrintLine();
                            PrintRow(gr.Item1.Item1, gr.Item1.Item2.chief.name);
                            PrintLine();
                        }
                    }
                    break;
                case 4:
                    PrintLine();
                    PrintRow("Employee of group: " + fields[3]);
                    PrintLine();
                    Group group = neman.cities.Get(fields[0]).branches.Get(fields[1]).departments.Get(fields[2]).groups.Get(fields[3]);
                    foreach (((string, Employee),(int,int))emp in group.employees.KeyValuePair)
                    {
                        PrintLine();
                        PrintRow(emp.Item1.Item2.name);
                        PrintLine();
                    }

                    break;
                default:

                    PrintLine();
                    PrintRow("Enter valid data : ");
                    PrintLine();


                    break;





            }



            Console.ForegroundColor = ConsoleColor.White;






        }


    }
}
