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

        public void Remove(T value)
        {
            Remove(value, root);
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

        private void Remove(T value, Node<T> currentNode)
        {
            if (currentNode == null)
            {
                return;
            }

            int compResult = value.CompareTo(currentNode.value);

            if (compResult == 0)
            {
                bool isLeftChild = currentNode.parent.left != null && currentNode.Equals(currentNode.parent.left);
                Node<T> newParentRef;

                //if there's no right branch
                if (currentNode.right == null)
                {
                    //if it's a leaf node
                    if (currentNode.left == null)
                    {
                        newParentRef = null;
                    }
                    else
                    {
                        newParentRef = currentNode.left;
                        currentNode.left.parent = currentNode.parent;
                    }
                }
                else
                {
                    Node<T> replacement = GetNextMinNode(currentNode.right);

                    //Reset old parent's link to replacement node
                    if (replacement.parent.left != null && replacement.parent.left.Equals(replacement))
                        replacement.parent.left = null;
                    else
                        replacement.parent.right = null;

                    newParentRef = replacement;
                    replacement.parent = currentNode.parent;
                    replacement.left = currentNode.left;

                    if (currentNode.left != null)
                        currentNode.left.parent = replacement;

                    if (replacement.right == null)
                        replacement.right = currentNode.right;
                }

                if (isLeftChild)
                    currentNode.parent.left = newParentRef;
                else
                    currentNode.parent.right = newParentRef;

            }
            else if (compResult > 0)
            {
                Remove(value, currentNode.right);
            }
            else
            {
                Remove(value, currentNode.left);
            }
        }

        private Node<T> GetNextMinNode(Node<T> currentNode)
        {
            if (currentNode.left == null)
            {
                return currentNode;
            }

            return GetNextMinNode(currentNode.left);
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