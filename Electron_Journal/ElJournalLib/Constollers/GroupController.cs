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
        public List<Group> Groups { get; set; }
        public Group CurrentGroup { get; set; }
        public Subject Subject { get; set; }

        public GroupController()
        {
            Groups = GroupsLoad();
        }

        public GroupController(string groupName) : this()
        {
            if (string.IsNullOrWhiteSpace(groupName))
            {
                throw new ArgumentNullException("Имя группы не может быть пустым", nameof(groupName));
            }

            CurrentGroup = Groups.SingleOrDefault(n => n.Name == groupName);
            if (CurrentGroup == null)
            {
                Groups.Add(new Group(groupName));
                GroupsSave(Groups);
            }
            else
            {
                //если такая группа есть то ничего не делаем
                return;
            }
        }

        public void EditGroup()
        {

        }

        private void GroupsSave(List<Group> groups)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(Directory.GetCurrentDirectory() + "\\Data\\groups.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, groups);
            }
        }

        public List<Group> GroupsLoad()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(Directory.GetCurrentDirectory() + "\\Data\\groups.dat", FileMode.OpenOrCreate))
            {
                if (fs.Length != 0)
                {
                    List<Group> groups = (List<Group>)formatter.Deserialize(fs);
                    {
                        return groups;
                    }
                }
                else
                {
                    return new List<Group>();
                }
            }
        }
    }
}