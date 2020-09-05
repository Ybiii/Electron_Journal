using ElJournal.Controllers;
using System;
using System.Collections.Generic;
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
                //Directory d -= new Direc
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
