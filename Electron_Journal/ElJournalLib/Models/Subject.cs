using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElJournalLib.Models
{
    [Serializable]
    public class Subject
    {
        public string Name { get; set; }
        public List<Student> Students;

        public Subject()
        {
            Students = new List<Student>();
        }

        public Subject(string name):this()
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя предмета не может быть пустым!", nameof(name));
            }
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}