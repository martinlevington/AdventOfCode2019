using System;
using System.Collections.Generic;

namespace Day_06_2019_Code
{

    public class TreeNode
    {
        public string val;
        public TreeNode parent;
        public List<TreeNode> children;
   
        public TreeNode(string x)
        { 
            val = x;
            children = new List<TreeNode>();
            parent = null;
        }

        public void AddChild(TreeNode node)
        {
            children.Add(node);
            node.parent = this;
        }
    }

}
