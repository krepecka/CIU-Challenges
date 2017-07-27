namespace queue
{
    class Queue<T>
    {
        public Queue()
        {
            _front = null;
            _tail = null;
        }

        private Node<T> _front;
        private Node<T> _tail;

        public void Enqueue(T item)
        {
            var node = new Node<T>(item, null);

            if (_front == null)
            {
                _front = node;
                _tail = node;
            }
            else
            {
                _tail.next = node;
                _tail = node;
            }
        }

        public T Dequeue()
        {
            if(_front == null)
            {
                return default(T);
            }

            var result = _front.value;
            if(_front == _tail)
            {
                _tail = null;
            }

            _front = _front.next;

            return result;
        }

        public bool IsEmpty()
        {
            return _front == null;
        }
    }

    public class Node<T>
    {
        public T value { get; set; }
        public Node<T> next { get; set; }

        public Node(T value, Node<T> next)
        {
            this.value = value;
            this.next = next;
        }

    }
}