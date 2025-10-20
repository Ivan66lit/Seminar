namespace RemoveFromEnd__
{
    using System;

    class Node
    {
        public int Data;
        public Node? Next;

        public Node(int data)
        {
            Data = data;
            Next = null;
        }
    }

    class LinkedList
    {
        private Node? head;

        public void AddToEnd(int value)
        {
            Node newNode = new Node(value);

            if (head == null)
            {
                head = newNode;
                return;
            }

            Node current = head;
            while (current.Next != null)
                current = current.Next;

            current.Next = newNode;
        }

        public void RemoveFromEnd()
        {
            if (head == null)
            {
                Console.WriteLine("Seznam je prázdný!");
                return;
            }

            if (head.Next == null)
            {
                head = null;
                return;
            }

            Node current = head;
            while (current.Next!.Next != null)
            {
                current = current.Next;
            }

            current.Next = null;
        }

        public void Print()
        {
            Node? current = head;
            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main()
        {
            LinkedList list = new LinkedList();

            list.AddToEnd(10);
            list.AddToEnd(20);
            list.AddToEnd(30);
            list.AddToEnd(40);

            Console.WriteLine("Původní seznam:");
            list.Print();

            list.RemoveFromEnd();

            Console.WriteLine("Po odstranění posledního prvku:");
            list.Print();
        }
    }
}
