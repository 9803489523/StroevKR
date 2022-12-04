using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stroev
{
    /*
        Класс для чтения данных из файла и поиска в дереве
    */
    internal static class FileWorker
    {
        /*
            Чтения данных из файла и запись в дерево
        */
        public static void fileRead(ref Tree tree)
        {
            StreamReader streamReader = new StreamReader("dictionary.txt");
            string res = streamReader.ReadToEnd();
            string[] arr = res.Split(new char[] { '\n' });
            string[] parse;
            foreach (var s in arr)
            {
                parse=s.Split(new char[] { ' ' });
                tree.Add(parse[1],int.Parse(parse[0]));
            }
        }

        /*
            Запуск поиска данных в дереве
        */
        public static void search(Tree tree)
        {
            TreeNode res;
            bool state = true;
            int id;
            while (state)
            {
                Console.WriteLine("Введите идентификатор: ");
                id=int.Parse(Console.ReadLine());
                res = tree.FindNode(id);
                if (res == null)
                {
                    Console.WriteLine("Результаты не найдены.");
                    Console.WriteLine("Сформированное на основании данных из файла дерево: ");
                    tree.PrintTree();
                    state = false;
                }
                else
                    Console.WriteLine("Результат поиска: {0}", res);
           
            }
        }
    }
}
