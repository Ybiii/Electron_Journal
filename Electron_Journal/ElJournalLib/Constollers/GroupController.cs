using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ElJournalLib.Models;

namespace ElJournal.Controllers
{
    public class GroupController
    {
        public Group Group { get; set; }
        public Subject Subject { get; set; }

        public GroupController()
        {

        }

        public GroupController(string groupName)
        {
            Group group = new Group(groupName);
            GroupSave(group);
        }

        private void GroupSave(Group group)
        {
            // создаем объект BinaryFormatter
            BinaryFormatter formatter = new BinaryFormatter();
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream(Directory.GetCurrentDirectory() + "\\Data\\" + group.Name + ".dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, group);
            }
        }

        public Group GroupLoad(string name)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(Directory.GetCurrentDirectory() + "\\Data\\" + name + ".dat", FileMode.OpenOrCreate))
            {
                if (fs.Length != 0)
                {
                    Group group = (Group)formatter.Deserialize(fs);
                    //Group[] deserilizePeople = (Group[])formatter.Deserialize(fs);
                    //foreach (Group g in deserilizePeople)
                    {
                        Console.WriteLine($"Имя: {group.Name}");
                        return group;
                    }
                }
                else
                {
                    throw new Exception("Поток десиреализации пустой");
                }
            }
        }
    }
}