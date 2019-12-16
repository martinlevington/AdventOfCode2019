using System.Collections.Generic;

namespace Day_06_2019_Code
{
    public class TreeNode
    {
        public List<TreeNode> Children;
        public TreeNode Parent;
        public string Val;

        public TreeNode(string x)
        {
            Val = x;
            Children = new List<TreeNode>();
            Parent = null;
        }

        public void AddChild(TreeNode node)
        {
            Children.Add(node);
            node.Parent = this;
        }
    }
}