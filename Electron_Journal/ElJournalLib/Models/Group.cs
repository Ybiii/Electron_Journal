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

        public Group()
        {

        }

        public Group(string name)
        {
            Name = name;

            //Subjects = new ICollection<Student>();
        }

        ///////////////////////////////////
        //public int Id { get; set; }

        //public ICollection<Student> Students { get; set; }
    }
}