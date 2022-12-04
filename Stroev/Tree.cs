using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stroev
{
    /*
        Класс В-дерева
    */
    public class Tree
    {
 
        /*
            Корень В-дерева
        */
        public TreeNode RootNode { get; set; }

        /*
            Функция добавления узла
        */
        private TreeNode Add(TreeNode node, TreeNode currentNode = null)
        {
            if (RootNode == null)
            {
                node.ParentNode = null;
                return RootNode = node;
            }

            currentNode = currentNode ?? RootNode;
            node.ParentNode = currentNode;
            int result;
            return (result = node.Id.CompareTo(currentNode.Id)) == 0
                ? currentNode
                : result < 0
                    ? currentNode.LeftNode == null
                        ? (currentNode.LeftNode = node)
                        : Add(node, currentNode.LeftNode)
                    : currentNode.RightNode == null
                        ? (currentNode.RightNode = node)
                        : Add(node, currentNode.RightNode);
        }

        /*
             Добавление элемента в В-дерево (для пользователя)
        */
        public TreeNode Add(string data,int id)
        {
            return Add(new TreeNode(data,id));
        }

        /*
            Поиск узла по идентификатору
        */
        public TreeNode FindNode(int id, TreeNode startWithNode = null)
        {
            startWithNode = startWithNode ?? RootNode;
            int result;
            return (result = id.CompareTo(startWithNode.Id)) == 0
                ? startWithNode
                : result < 0
                    ? startWithNode.LeftNode == null
                        ? null
                        : FindNode(id, startWithNode.LeftNode)
                    : startWithNode.RightNode == null
                        ? null
                        : FindNode(id, startWithNode.RightNode);
        }


        /*
            Вывод В-дерева на консоль (для пользователей)
        */
        public void PrintTree()
        {
            PrintTree(RootNode);
        }

        /*
           Вывод В-дерева на консоль
        */
        private void PrintTree(TreeNode startNode, string indent = "", Side? side = null)
        {
            if (startNode != null)
            {
                var nodeSide = side == null ? "+" : side == Side.Left ? "L" : "R";
                Console.WriteLine($"{indent} [{nodeSide}]- {startNode.Id}:{startNode.Data}");
                indent += new string(' ', 3);
                //рекурсивный вызов для левой и правой веток
                PrintTree(startNode.LeftNode, indent, Side.Left);
                PrintTree(startNode.RightNode, indent, Side.Right);
            }
        }
    }
}
