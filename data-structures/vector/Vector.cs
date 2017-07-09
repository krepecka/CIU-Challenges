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
            get { return _size; }
        }

        public int Capacity
        {
            get { return _capacity; }
        }

        public bool IsEmpty
        {
            get { return _size == 0; }
        }

        public T At(int index)
        {
            if (index >= _capacity)
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
            if (index < _size)
            {
                for (int i = _size; i > index; i--)
                {
                    MoveItem(i, _array[i - 1]);
                }
            }

            InsertItem(index, item);
        }

        private void Resize(int newCapacity)
        {
            Array.Resize(ref _array, newCapacity);
            _capacity = newCapacity;
        }

        public void Prepend(T item)
        {
            Insert(0, item);
        }

        public T Pop()
        {
            T value = _array[_size - 1];
            RemoveItem(_size - 1);

            return value;
        }

        public void Delete(int index)
        {
            //Shift all
            for (int i = index; i < _size - 1; i++)
            {
                _array[i] = _array[i + 1];
            }

            //Delete last item
            RemoveItem(_size - 1);
        }

        //O(n^2)
        public void Remove(T item)
        {
            for(int i = 0; i < _size; i++)
            {
                if(_array[i].Equals(item))
                {
                    Delete(i);
                    i--;
                }
            }

        }

        public int Find(T item)
        {
            for(int i = 0; i < _size; i++)
            {
                if(_array[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        private void InsertItem(int index, T item)
        {
            MoveItem(index, item);
            _size++;
        }

        private void RemoveItem(int index)
        {
            _size--;
            MoveItem(index, default(T));
        }

        private void MoveItem(int index, T item)
        {
            if (_capacity == _size)
            {
                Resize(_capacity * 2);
            }
            else if(_size <= _capacity / 4)
            {
                Resize(_capacity / 2);
            }

            _array[index] = item;
        }
    }
}