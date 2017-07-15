using System;

namespace linkedList
{
    public class LinkedList<T>
    {
        object _head;
        object _tail;
        int _size;

        public LinkedList()
        {
            _size = 0;
            _head = null;
            _tail = null;
        }

        public int Size
        {
            get { return _size; }
        }

        public bool Empty
        {
            get { return _size == 0; }
        }

        public T ValueAt(int index)
        {
            if (_head == null || index >= _size)
            {
                throw new IndexOutOfRangeException();
            }

            Node<T> result = GetElementAt(index);

            return result.Value;
        }

        public void PushFront(T value)
        {
            Node<T> newNode = new Node<T>();
            newNode.Value = value;
            newNode.Next = _head;
            _head = newNode;

            _size++;
        }

        public T PopFront()
        {
            Node<T> node = (Node<T>)_head;
            _head = node.Next;
            _size--;

            if (node == null)
            {
                return default(T);
            }

            return node.Value;
        }

        public void PushBack(T value)
        {
            Node<T> newNode = new Node<T>();
            newNode.Value = value;
            newNode.Next = null;

            if (_head == null)
            {
                _head = newNode;
            }
            else
            {
                Node<T> lastNode = (Node<T>)_tail;
                lastNode.Next = newNode;
            }

            _tail = newNode;
            _size++;
        }

        public T PopBack()
        {
            if (_head == null)
            {
                return default(T);
            }

            Node<T> node = (Node<T>)_tail;

            if (_head == _tail)
            {
                _head = null;
                _tail = null;
            }
            else
            {
                Node<T> beforeLast = GetElementAt(_size - 2);

                beforeLast.Next = null;
                _tail = beforeLast;
            }
            _size--;
            return node.Value;
        }

        public T Front()
        {
            if (_head == null)
            {
                return default(T);
            }

            return ((Node<T>)_head).Value;
        }

        public T Back()
        {
            if (_head == null)
            {
                return default(T);
            }

            return ((Node<T>)_tail).Value;
        }

        public void Insert(int index, T value)
        {
            if (index > _size)
            {
                throw new IndexOutOfRangeException();
            }
            else if (index == _size)
            {
                PushBack(value);
                return;
            }
            else if (index == 0)
            {
                PushFront(value);
                return;
            }

            Node<T> newNode = new Node<T>();
            newNode.Value = value;

            Node<T> before = GetElementAt(index - 1);

            newNode.Next = before.Next;
            before.Next = newNode;
            _size++;
        }

        public void Erase(int index)
        {
            if (index >= _size)
            {
                throw new IndexOutOfRangeException();
            }
            else if (index == _size - 1)
            {
                PopBack();
                return;
            }
            else if (index == 0)
            {
                PopFront();
                return;
            }

            Node<T> node = GetElementAt(index);
            Node<T> before = GetElementAt(index - 1);

            before.Next = node.Next;
            node = null;
            _size--;
        }

        public void Reverse()
        {
            Node<T> node = (Node<T>)_head;
            Node<T> next = (Node<T>)node.Next, tmp;

            node.Next = null;
            _tail = node;

            while (next != null)
            {
                tmp = (Node<T>)next.Next;
                
                next.Next = node;

                node = next;
                next = tmp;
            }

            _head = node;
        }

        private Node<T> GetElementAt(int index)
        {
            int i = 0;
            Node<T> result = (Node<T>)_head;

            while (i < index)
            {
                result = (Node<T>)result.Next;
                i++;
            }
            return result;
        }
    }

    internal class Node<T>
    {
        internal object Next { get; set; }
        internal T Value { get; set; }
    }

}