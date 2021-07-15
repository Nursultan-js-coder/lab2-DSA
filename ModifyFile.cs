using System;
using System.IO;

namespace main
{
   public class ModifyFile
    {
        public static void Modify2()
        {
            StreamReader sr = new StreamReader("employees.txt");
            StreamWriter sw = new StreamWriter("employeesJS.txt");
            string str = sr.ReadLine();
            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            string temp = "";
            while (str != null)
            {
                temp = $"{str},";
                sw.Write(str);
                str = sr.ReadLine();

            }
            sr.Close();
            sw.Flush();
            sw.Close();


        }
    }
}