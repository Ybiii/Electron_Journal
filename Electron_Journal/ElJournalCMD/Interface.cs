using ElJournal.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElJournalCMD
{
    class Interface
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\t Имеющиеся группы:");
                Console.WriteLine("------------------------------------------------");
                var currentDirectory = Directory.GetCurrentDirectory();
                Console.WriteLine(Directory.GetCurrentDirectory());
                //Console.WriteLine(Directory.GetCurrentDirectory() + "\\Data\\" + "6A" + ".dat");
                var d = Directory.GetFiles(currentDirectory+"\\Data");
                foreach(var s in d.Where(k=>k.EndsWith(".dat".ToLower())))
                {
                    var name = s.Split('\\').LastOrDefault();
                    name = name.Remove(name.Length - 4);
                    Console.WriteLine(name);
                }
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("\t Загружаем имеющуюся группу? (1)");
                Console.WriteLine("\t Создаем новую группу? (2)");
                int choise;
                GroupController g = new GroupController();
                Int32.TryParse(Console.ReadLine(), out choise);
                switch (choise)
                {
                    case 1:
                        Console.WriteLine("Вводи название загружаемой группы? ");
                        g.GroupLoad(Console.ReadLine());
                        break;
                    case 2:
                        Console.WriteLine("Вводи имя группы которую создаем?");
                        g = new GroupController(Console.ReadLine());
                        break;
                }


            }
        }
    }
}
