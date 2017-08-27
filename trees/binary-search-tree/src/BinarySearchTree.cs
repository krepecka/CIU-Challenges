using System;

namespace BST
{
    public class BinarySearchTree<T> where T : IComparable
    {
        private Node<T> root;

        public BinarySearchTree(T rootValue)
        {
            root = new Node<T>(null, rootValue);
        }

        public void Insert(T value)
        {
            Insert(root, null, value);
        }

        public void PrintInOrder()
        {
            PrintInOrder(root);
        }

        public int GetNodeCount()
        {
            return GetNodeCount(root) - 1;
        }

        public int GetTreeDepth()
        {
            return GetTreeDepth(root) - 1;
        }

        public bool IsInTree(T value)
        {
            return IsInTree(root, value);
        }

        public T GetMinValue()
        {
            return GetMinValue(root);
        }

        public T GetMaxValue()
        {
            return GetMaxValue(root);
        }

        public T GetSuccessor(T afterValue)
        {
            return GetSuccessor(root, afterValue);
        }

        private void Insert(Node<T> currentNode, Node<T> parent, T searchValue)
        {
            if (currentNode == null)
            {
                int compResult = searchValue.CompareTo(parent.value);
                var newNode = new Node<T>(parent, searchValue);

                if (compResult > 0)
                {
                    parent.right = newNode;
                }
                else
                {
                    parent.left = newNode;
                }
            }
            else
            {
                int compResult = searchValue.CompareTo(currentNode.value);
                var nextNode = compResult > 0 ? currentNode.right : currentNode.left;

                Insert(nextNode, currentNode, searchValue);
            }
        }

        private void PrintInOrder(Node<T> currentNode)
        {
            if (currentNode == null)
            {
                return;
            }
            PrintInOrder(currentNode.left);
            System.Console.WriteLine(String.Format(" {0} ", currentNode.value));
            PrintInOrder(currentNode.right);
        }

        private int GetNodeCount(Node<T> currentNode)
        {
            if (currentNode == null)
            {
                return 1;
            }

            return GetNodeCount(currentNode.left) + GetNodeCount(currentNode.right);
        }

        private int GetTreeDepth(Node<T> currentNode)
        {
            if (currentNode == null)
            {
                return 1;
            }

            return 1 + Math.Max(GetTreeDepth(currentNode.left), GetTreeDepth(currentNode.right));
        }

        private bool IsInTree(Node<T> currentNode, T searchValue)
        {
            if (currentNode == null)
            {
                return false;
            }

            int compValue = searchValue.CompareTo(currentNode.value);

            if (compValue == 0)
            {
                return true;
            }
            else if (compValue > 0)
            {
                return IsInTree(currentNode.right, searchValue);
            }
            else
            {
                return IsInTree(currentNode.left, searchValue);
            }
        }

        private T GetMinValue(Node<T> currentNode)
        {
            if (currentNode.left == null)
            {
                return currentNode.value;
            }

            return GetMinValue(currentNode.left);
        }

        private T GetMaxValue(Node<T> currentNode)
        {
            if (currentNode.right == null)
            {
                return currentNode.value;
            }

            return GetMaxValue(currentNode.right);
        }

        private T GetSuccessor(Node<T> currentNode, T afterValue)
        {
            if (currentNode == null)
            {
                return default(T);
            }

            if (currentNode.value.Equals(afterValue))
            {
                if (currentNode.right != null)
                {
                    return GetMinValue(currentNode.right);
                }
                else
                {
                    return currentNode.parent != null ? currentNode.parent.value : default(T);
                }
            }
            else
            {
                int compValue = afterValue.CompareTo(currentNode.value);

                if (compValue > 0)
                {
                    return GetSuccessor(currentNode.right, afterValue);
                }
                else
                {
                    return GetSuccessor(currentNode.left, afterValue);
                }
            }
        }
    }

    class Node<T> where T : IComparable
    {
        public Node<T> parent { get; set; }
        public Node<T> left { get; set; }
        public Node<T> right { get; set; }

        public T value { get; set; }

        public Node(Node<T> parent, T value)
        {
            this.parent = parent;
            this.value = value;
            this.left = null;
            this.right = null;
        }

        public override string ToString()
        {
            return "value is " + this.value.ToString();
        }
    }
}