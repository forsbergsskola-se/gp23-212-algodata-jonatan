using System;
using System.Collections.Generic;

public class TurboBinarySearchTree
{
    private class Node
    {
        public int Value;
        public Node Left;
        public Node Right;

        public Node(int value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }

    private Node root;

    public TurboBinarySearchTree()
    {
        root = null;
    }

    public void Insert(int value)
    {
        root = InsertRec(root, value);
    }

    private Node InsertRec(Node root, int value)
    {
        if (root == null)
        {
            root = new Node(value);
            return root;
        }

        if (value < root.Value)
        {
            root.Left = InsertRec(root.Left, value);
        }
        else if (value > root.Value)
        {
            root.Right = InsertRec(root.Right, value);
        }

        return root;
    }

    public bool Search(int value)
    {
        return SearchRec(root, value);
    }

    private bool SearchRec(Node root, int value)
    {
        if (root == null)
        {
            return false;
        }

        if (root.Value == value)
        {
            return true;
        }

        if (value < root.Value)
        {
            return SearchRec(root.Left, value);
        }
        else
        {
            return SearchRec(root.Right, value);
        }
    }

    public bool Delete(int value)
    {
        bool found = false;
        root = DeleteRec(root, value, ref found);
        return found;
    }

    private Node DeleteRec(Node root, int value, ref bool found)
    {
        if (root == null)
        {
            return root;
        }

        if (value < root.Value)
        {
            root.Left = DeleteRec(root.Left, value, ref found);
        }
        else if (value > root.Value)
        {
            root.Right = DeleteRec(root.Right, value, ref found);
        }
        else
        {
            found = true;

            if (root.Left == null)
            {
                return root.Right;
            }
            else if (root.Right == null)
            {
                return root.Left;
            }

            root.Value = MinValue(root.Right);
            root.Right = DeleteRec(root.Right, root.Value, ref found);
        }

        return root;
    }

    private int MinValue(Node root)
    {
        int minValue = root.Value;
        while (root.Left != null)
        {
            minValue = root.Left.Value;
            root = root.Left;
        }
        return minValue;
    }

    public IEnumerable<int> InOrderTraversal()
    {
        return InOrderTraversalRec(root);
    }

    private IEnumerable<int> InOrderTraversalRec(Node root)
    {
        if (root != null)
        {
            foreach (var val in InOrderTraversalRec(root.Left))
            {
                yield return val;
            }

            yield return root.Value;

            foreach (var val in InOrderTraversalRec(root.Right))
            {
                yield return val;
            }
        }
    }
}

class Program
{
    static void Main()
    {
        TurboBinarySearchTree tree = new TurboBinarySearchTree();

        // fill the tree with a lot of even numbers
        for (int i = 0; i < 1000000; i += 2)
        {
            tree.Insert(i);
        }

        Console.WriteLine("Found 50000: " + tree.Search(50000)); // should return true
        Console.WriteLine("Deleted 50000: " + tree.Delete(50000)); // should return true
        Console.WriteLine("Found 50000: " + tree.Search(50000)); // should return false
        Console.WriteLine("Found 50001: " + tree.Search(50001)); // should return false
        Console.WriteLine("Deleted 50001: " + tree.Delete(50001)); // should return false
        Console.WriteLine("Found 50001: " + tree.Search(50001)); // should return false

        tree.Insert(50002);
        Console.WriteLine("Found 50002: " + tree.Search(50002)); // should return true
        Console.WriteLine("Deleted 50002: " + tree.Delete(50002)); // should return true
        Console.WriteLine("Found 50002: " + tree.Search(50002)); // should return true
        Console.WriteLine("Deleted 50002: " + tree.Delete(50002)); // should return true
        Console.WriteLine("Found 50002: " + tree.Search(50002)); // should return false
    }
}
