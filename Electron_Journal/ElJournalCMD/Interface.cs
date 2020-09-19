using ElJournal;
using ElJournal.Controllers;
using System;

namespace ElJournalCMD
{
    class Interface
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                GroupController g = new GroupController();
                Console.WriteLine("\t Имеющиеся группы");
                Console.WriteLine("---------------------------------------");
                foreach (var gr in g.Groups)
                {
                    Console.WriteLine(gr.Name);
                }
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("\t Используем имеющуюся группу? (1)");
                Console.WriteLine("\t Создаем новую группу? (2)");
                int choise;              
                Int32.TryParse(Console.ReadLine(), out choise);
                switch (choise)
                {
                    case 1:
                        Console.WriteLine("Вводи название группы? ");
                        GroupController gController = new GroupController(Console.ReadLine());
                        //Если выбрали группу то работаем с ней иначе начинаем с начала
                        if (gController.CurrentGroup != null)
                            EditGroup(gController.CurrentGroup);
                        else
                            continue;
                        break;
                    case 2:
                        Console.WriteLine("Вводи имя группы которую создаем?");
                        g = new GroupController(Console.ReadLine());
                        break;
                }


            }
        }

        public static void EditGroup(Group g)
        {
            Console.WriteLine(g.Name);
            Console.ReadKey();
        }
    }
}
