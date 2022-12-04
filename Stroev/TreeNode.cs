using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stroev
{
    /*
        Перечисление для определения положения узла в дереве 
    */
    public enum Side
    {
        Left,
        Right
    }

    /*
        Класс узла В-дерева
    */
    public class TreeNode
    {
        /*
            Конструктор
        */
        public TreeNode(string data,int id)
        {
            Data = data;
            Id = id;
        }

        /*
            Данные узла
        */
        public string Data { get; set; }

        /*
            Идентификатор узла
        */
        public int Id { get; set; }

        /*
            Левая ветка
        */
        public TreeNode LeftNode { get; set; }

        /*
            Правая ветка
        */
        public TreeNode RightNode { get; set; }

        /*
            Родительский узел
        */
        public TreeNode ParentNode { get; set; }

        /*
            Расположение узла относительно родителя
        */
        public Side? NodeSide =>
            ParentNode == null
            ? (Side?)null
            : ParentNode.LeftNode == this
                ? Side.Left
                : Side.Right;

        /*
            Функция преобразования в строку
        */
        public override string ToString() => Data.ToString();
    }
}
