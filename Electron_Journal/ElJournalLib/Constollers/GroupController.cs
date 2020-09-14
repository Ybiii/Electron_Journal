using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ElJournal.Controllers
{
    public class GroupController
    {
        private Group group;

        public GroupController()
        {
            group = new Group();
        }

        public GroupController(string name)
        {
            group = new Group(name);
            Save(group);
        }

        public Group GroupLoad(string name)
        {
            return Load(name);
        }

        //public void GroupSave(string name)
        //{

        //}

        private void Save(Group group)
        {
            // создаем объект BinaryFormatter
            BinaryFormatter formatter = new BinaryFormatter();
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream(Directory.GetCurrentDirectory() + "\\Data\\" + group.Name + ".dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, group);
            }
        }

        private Group Load(string name)
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
