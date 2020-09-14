using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElJournalLib.Models
{
    [Serializable]
    public class Student
    {
        public string Name { get; set; }

        public Student()
        {

        }

        public Student(string name):this()
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя студента не может быть пустым!", nameof(name));
            }
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}