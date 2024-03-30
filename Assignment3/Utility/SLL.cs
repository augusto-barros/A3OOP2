// Object-Oriented Programming 2 (CPRG - 211 - D) - Assignment 3
// Assignment: Singly Linked Lists, Serialization and Testing
// Names: Augusto Antunes Barros and Akshar Patel
//
//
// 
using System;
using System.Runtime.Serialization;

namespace Assignment3
{
    [Serializable, KnownType(typeof(User))]
    public class SLL : ILinkedListADT
    {
        public Node Head { get; set; }
        public Node Tail { get; set; }
        private int _count = 0;

        public SLL()
        {
            this.Head = null;
            this.Tail = null;
            this._count = 0;
        }

        public void Add(User value, int index)
        {
            if (index < 0 || index > _count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            Node newNode = new Node();
            newNode.Value = value;

            if (_count == 0)  // List is empty
            {
                Head = newNode;
                Tail = newNode;
            }
            else if (index == 0)  // Add at the beginning
            {
                newNode.Next = Head;
                Head = newNode;
            }
            else if (index == _count)  // Add at the end
            {
                Tail.Next = newNode;
                Tail = newNode;
            }
            else  // Add in the middle
            {
                Node node = Head;
                for (int i = 0; i < index - 1; i++)
                {
                    node = node.Next;
                }
                newNode.Next = node.Next;
                node.Next = newNode;
            }

            _count++;
        }

        public void AddFirst(User value)
        {
            Add(value, 0);
        }

        public void AddLast(User value)
        {
            Add(value, _count);
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            _count = 0;
        }

        public bool Contains(User value)
        {
            Node node = Head;
            while (node != null)
            {
                if (node.Value.Id == value.Id)
                {
                    return true;
                }
                node = node.Next;
            }
            return false;
        }

        public int Count()
        {
            return _count;
        }

        public User GetValue(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            Node node = Head;
            for (int i = 0; i < index; i++)
            {
                node = node.Next;
            }
            return node.Value;
        }

        public int IndexOf(User value)
        {
            Node node = Head;
            int index = 0;
            while (node != null)
            {
                if (node.Value.Equals(value))
                {
                    return index;
                }
                node = node.Next;
                index++;
            }
            return -1;
        }

        public bool IsEmpty()
        {
            return _count == 0;
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            if (_count == 1)  // Only one element in the list
            {
                Head = null;
                Tail = null;
            }
            else if (index == 0)  // Remove the first element
            {
                Head = Head.Next;
            }
            else if (index == _count - 1)  // Remove the last element
            {
                Node node = Head;
                for (int i = 0; i < index - 1; i++)
                {
                    node = node.Next;
                }
                node.Next = null;
                Tail = node;
            }
            else  // Remove from the middle
            {
                Node node = Head;
                for (int i = 0; i < index - 1; i++)
                {
                    node = node.Next;
                }
                node.Next = node.Next.Next;
            }

            _count--;
        }

        public void RemoveFirst()
        {
            Remove(0);
        }

        public void RemoveLast()
        {
            Remove(_count - 1);
        }

        public void Replace(User value, int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            Node node = Head;
            for (int i = 0; i < index; i++)
            {
                node = node.Next;
            }

            node.Value = value;
        }

        public void Reverse()
        {
            if (_count <= 1)
            {
                return;
            }

            Node prev = null;
            Node current = Head;
            Node next = null;

            while (current != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }

            Head = prev;
        }
    }
}
