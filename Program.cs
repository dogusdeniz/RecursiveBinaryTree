// See https://aka.ms/new-console-template for more information
namespace BTSExample
{
    public class Node
    {
        public Node(int val)
        {
            Val = val;
        }

        public int Val { get; set; }

        public Node LeftNode { get; set; }

        public Node RightNode { get; set; }
    }

    public static class Program
    {
        public static Node AddNode(Node parentNode, int value)
        {
            if (parentNode == null) return new Node(value);
            if (value < parentNode.Val)
                parentNode.LeftNode = AddNode(parentNode.LeftNode, value);
            else if (value > parentNode.Val)
                parentNode.RightNode = AddNode(parentNode.RightNode, value);
            return parentNode;
        }

        public static void Traverse(Node parentNode)
        {
            if (parentNode != null)
            {
                Traverse(parentNode.LeftNode);
                Console.WriteLine(parentNode.Val + " ");
                Traverse(parentNode.RightNode);
            }
        }

        public static Node Find(Node parentNode, int value)
        {
            if (parentNode == null || parentNode.Val == value)
                return parentNode;
            if (value < parentNode.Val) return Find(parentNode.LeftNode, value);
            return Find(parentNode.RightNode, value);
        }

        public static int FindIndex(Node parentNode, int value)
        {
            if (parentNode == null) return -1;
            if (parentNode.Val == value) return 1; // index 1
            int left = FindIndex(parentNode.LeftNode, value);
            if (left != -1) return left + 1;
            int right = FindIndex(parentNode.RightNode, value);
            if (right != -1) return right + 1;
            return -1;
        }

        public static void Main()
        {
            Node root = new Node(8);
            AddNode(root, 6);
            AddNode(root, 3);
            AddNode(root, 10);
            AddNode(root, 1);
            AddNode(root, 4);
            AddNode(root, 7);
            AddNode(root, 14);
            AddNode(root, 13);

            Traverse (root);

            Node result = Find(root, 8);
            Console.WriteLine("Founded : " + result.Val);

            int result2 = FindIndex(root, 8);
            Console.WriteLine("FindIndex : " + result2);

            Node result3 = Find(root, 10);
            Console.WriteLine("Founded : " + result3.Val);

            int result4 = FindIndex(root, 10);
            Console.WriteLine("FindIndex : " + result4);
        }
    }
}
