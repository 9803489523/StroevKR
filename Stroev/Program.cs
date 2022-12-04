namespace Stroev
{
    /*
        Класс для запуска программы
    */
    class Program
    {
        /*
            Функция, в которой запускатся программа 
        */
        static void Main(string[] args)
        {
            var tree = new Tree();
            FileWorker.fileRead(ref tree);
            FileWorker.search(tree);
            Console.ReadLine();
        }
    }
}