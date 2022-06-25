
using System.Linq;
using System.Collections.Generic;

namespace LeetNode
{
    public class Program
    {
        static void Main(string[] args)
        {
            var root = new LeetNode().BuildeTree(new int?[]
            {
                17, 46, 44, 17, null, 21, 23, null, null, 50, 48, 46, 44, 5, null, 7, null, 11, null, 13, null, null, null, null, null, null, null, 17
            });

        }
    }

    /**
 * Definition for a binary tree node. */
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }

        public override string ToString()
        {
            return $"Val: {val}, left: {left?.val.ToString() ?? 'n'.ToString()}, right: {right?.val.ToString() ?? 'n'.ToString()}";
        }
    }

    public class LeetNode
    {
        public TreeNode BuildeTree(int?[] array)
        {
            if (array.Length == 0 || array[0] is null) return null;

            List<TreeNode> level = new List<TreeNode>() { new TreeNode(array[0].Value) };
            int taken = 1;
            var root = level.Single();

            while (level.Count > 0)
            {
                List<TreeNode> nextLevel = new List<TreeNode>();

                foreach (var node in level)
                {
                    if (taken == array.Length) break;

                    var leftVal = array.Skip(taken++).Take(1).Single();
                    if (leftVal != null)
                    {
                        node.left = new TreeNode(leftVal.Value);
                        nextLevel.Add(node.left);
                    }

                    if (taken == array.Length) break;

                    var rigthVal = array.Skip(taken++).Take(1).Single();
                    if (rigthVal != null)
                    {
                        node.right = new TreeNode(rigthVal.Value);
                        nextLevel.Add(node.right);
                    }
                }

                level = nextLevel;
            }

            return root;
        }
    }
}