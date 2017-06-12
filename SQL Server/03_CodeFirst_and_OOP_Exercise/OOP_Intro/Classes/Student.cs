using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Intro.Classes
{
    class Student
    {

        private string name;
        public static int number;

        public string Name { get; set; }

        public Student(string name)
        {
            this.Name = name;
            number++;
        }

        public Student() : this("No name") { }
    }
}
