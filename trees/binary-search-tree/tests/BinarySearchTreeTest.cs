using BST;
using Xunit;

namespace tests
{
    public class BinarySearchTreeTest
    {
        [Fact]
        public void TestNodeCount()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>(19);
            tree.Insert(5);
            tree.Insert(7);
            tree.Insert(99);

            Assert.Equal(4, tree.GetNodeCount());
        }

        [Fact]
        public void TestDepthLinear()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>(19);
            tree.Insert(10);
            tree.Insert(9);
            tree.Insert(8);
            tree.Insert(7);
            tree.Insert(6);
            tree.Insert(5);
            tree.Insert(4);
            tree.Insert(3);
            tree.Insert(2);
            tree.Insert(1);

            Assert.Equal(11, tree.GetTreeDepth());
        }

        [Fact]
        public void TestDepthBalanced()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>(19);
            tree.Insert(15);
            tree.Insert(25);
            tree.Insert(10);
            tree.Insert(17);
            tree.Insert(9);
            tree.Insert(12);
            tree.Insert(16);
            tree.Insert(18);
            tree.Insert(22);
            tree.Insert(24);
            tree.Insert(30);
            tree.Insert(28);
            tree.Insert(35);
            

            Assert.Equal(4, tree.GetTreeDepth());
        }

        [Fact]
        public void TestIsValueInTree()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>(19);
            tree.Insert(15);
            tree.Insert(25);
            tree.Insert(10);
            tree.Insert(35);

            Assert.True(tree.IsInTree(15));
        }

        [Fact]
        public void TestIsValueNotInTree()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>(19);
            tree.Insert(15);
            tree.Insert(25);
            tree.Insert(10);
            tree.Insert(35);

            Assert.False(tree.IsInTree(21));
        }

        [Fact]
        public void TestMinValueRoot()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>(19);

            Assert.Equal(19, tree.GetMinValue());
        }
        
        [Fact]
        public void TestMinValue()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>(19);

            tree.Insert(-12);
            tree.Insert(1);
            tree.Insert(0);
            tree.Insert(35);

            Assert.Equal(-12, tree.GetMinValue());
        }

        [Fact]
        public void TestMaxValueRoot()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>(19);

            Assert.Equal(19, tree.GetMaxValue());
        }
        
        [Fact]
        public void TestMaxValue()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>(19);

            tree.Insert(-12);
            tree.Insert(1);
            tree.Insert(0);
            tree.Insert(35);

            Assert.Equal(35, tree.GetMaxValue());
        }

        [Fact]
        public void TestSuccessorSimple()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>(19);

            tree.Insert(15);
            tree.Insert(25);
            tree.Insert(10);
            tree.Insert(35);

            Assert.Equal(35, tree.GetSuccessor(25));
        }

        [Fact]
        public void TestSuccessor()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>(19);

            tree.Insert(15);
            tree.Insert(25);
            tree.Insert(10);
            tree.Insert(35);
            tree.Insert(27);
            tree.Insert(37);
            tree.Insert(26);

            Assert.Equal(26, tree.GetSuccessor(25));
        }

        [Fact]
        public void TestSuccessorRoot()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>(19);

            tree.Insert(15);
            tree.Insert(25);
            tree.Insert(10);
            tree.Insert(35);
            tree.Insert(27);
            tree.Insert(37);
            tree.Insert(26);

            Assert.Equal(25, tree.GetSuccessor(19));
        }

        [Theory]
        [InlineData(27, 26)]
        [InlineData(35, 32)] //when it's not instant parent
        [InlineData(0, 37)]
        public void TestSuccessorNoRightBranch(int expectedSuccessor, int value)
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>(19);

            tree.Insert(15);
            tree.Insert(25);
            tree.Insert(10);
            tree.Insert(35);
            tree.Insert(27);
            tree.Insert(37);
            tree.Insert(26);
            tree.Insert(32);

            Assert.Equal(expectedSuccessor, tree.GetSuccessor(value));
        }

        [Theory]
        [InlineData(26, 45)]
        [InlineData(25, 37)]
        [InlineData(15, 10)]
        [InlineData(35, 32)]
        [InlineData(37, 26)]
        [InlineData(25, 32)]
        public void TestRemove(int value, int value2)
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>(19);

            tree.Insert(15);
            tree.Insert(25);
            tree.Insert(10);
            tree.Insert(35);
            tree.Insert(27);
            tree.Insert(37);
            tree.Insert(26);
            tree.Insert(32);
            tree.Insert(45);

            tree.Remove(value);

            Assert.False(tree.IsInTree(value));
            Assert.True(tree.IsInTree(value2));
        }
    }
}
