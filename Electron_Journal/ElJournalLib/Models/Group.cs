using ElJournalLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElJournal
{
    [Serializable]
    public class Group
    {
        public string Name { get; set; }
        public List<Subject> Subjects;

        public Group()
        {
            Subjects = new List<Subject>();
        }

        public Group(string name):this()
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Не верное имя группы!", nameof(name));
            }
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}