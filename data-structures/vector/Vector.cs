using System;

namespace vector
{
    public class Vector<T>
    {
        private T[] _array;
        private int _capacity = 2;
        private int _size;

        public Vector()
        {
            _array = new T[_capacity];
            _size = 0;
        }

        public int Size
        {
            get{ return _size; }
        }

        public int Capacity
        {
            get{ return _capacity; }
        }

        public bool IsEmpty
        {
            get { return _size == 0; }
        }

        public T At(int index)
        {
            if(index >= _capacity)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                return _array[index];
            }
        }

        public void Push(T item)
        {
            InsertItem(_size, item);
        }

        public void Insert(int index, T item)
        {
            if( index > _size - 1)
            {
                _array[index] = item;
            }
            else
            {
                for(int i = _size; i > index; i--)
                {
                    MoveItem(i, _array[i-1]);
                }

                InsertItem(index, item);
            }
        }

        private void InsertItem(int index, T item)
        {
            MoveItem(index, item);
            _size++;
        }

        private void MoveItem(int index, T item)
        {
            if(_capacity == _size)
            {
                Resize(_capacity*2);
            }

            _array[index] = item;
        }

        private void Resize(int newCapacity)
        {
            Array.Resize(ref _array, newCapacity);
            _capacity = newCapacity;
        }
    }
}