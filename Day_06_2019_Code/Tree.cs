using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day_06_2019_Code
{
    public class Tree
    {
        private TreeNode _rootNode;
        private List<TreeNode> _nodes;
        private char orbitSeparator = ')';

        public Tree(string input)
        {
            _nodes = new List<TreeNode>();
            _rootNode = new TreeNode(input);
            _nodes.Add(_rootNode);
        }

  

        public Tree(string[] orbits)
        {
            this.Init(orbits);
        }

            public void Init(string[] orbits)
        {

            if (orbits.Length == 0) return;

            _rootNode = new TreeNode("");
            _nodes = new List<TreeNode>();

            foreach (var orbit in orbits)
            {
                var planetOrbit = GetOrbit(orbit);
                TreeNode parent;
                TreeNode child;

                if (!NodeExists(planetOrbit.parentPlanet))
                {
                    parent = CreateNode(planetOrbit.parentPlanet);
                }
                else
                {
                    parent = _nodes.First(x => x.val == planetOrbit.parentPlanet);
                }

                if (!NodeExists(planetOrbit.childPlanet))
                {
                    child = CreateNode(planetOrbit.childPlanet);
                }
                else
                {
                    child = _nodes.First(x => x.val == planetOrbit.childPlanet);
                }

                if (!parent.children.Where(x => x.val == child.val).Any()) parent.children.Add(child);
                child.parent = parent;
            }


            _rootNode = FindRootNode(_nodes[0]);

        }



        public TreeNode FindRootNode(TreeNode node)
        {
            while (node.parent != null)
            {
              
                node = node.parent;
            }


            return node;
        }



        public bool NodeExists(string nodeId)
        {
            var res = _nodes.Where(x => x.val == nodeId).Any();
            return _nodes.Where(x => x.val == nodeId).Any();
        }


        public TreeNode CreateNode(string node)
        {
            var newNode = new TreeNode(node);
            _nodes.Add(newNode);

            return newNode;
        }

        private Orbit GetOrbit(string orbit)
        {
            var parent = orbit.Split(new[] { orbitSeparator }, StringSplitOptions.RemoveEmptyEntries).First();
            var child = orbit.Split(new[] { orbitSeparator }, StringSplitOptions.RemoveEmptyEntries).Last();

           return new Orbit(parent, child);

        }

        private void AddOrbit(TreeNode parent, TreeNode child)
        {
          
            AddNode(parent, child);

        }


        private void AddOrbit(string orbit)
        {
            var parent = orbit.Split(new[] { orbitSeparator }, StringSplitOptions.RemoveEmptyEntries).First();
            var child = orbit.Split(new[] { orbitSeparator }, StringSplitOptions.RemoveEmptyEntries).Last();

            AddNode(parent, child);

        }

        public TreeNode FindNode(TreeNode root, string nodeId)
        {
            if (root == null)
            {
                return null;
            }
            else if (root.val == nodeId)
            {
                return root;
            }

            TreeNode found = null;
            foreach (var c in root.children)
            {
                found = FindNode(c, nodeId);
                if (found != null) break;
            }


            return found;

        }

    
        public bool NodeExists(TreeNode root, string nodeId)
        {
            if (root == null)
            {
                return false;
            }
            else if (root.val == nodeId)
            {
                return true;
            }

            bool found = false;
            foreach (var c in root.children)
            {
                found = NodeExists(c, nodeId);
                if (found) break;
            }


            return found;

        }

        public void AddNode(string parentId, string childId)
        {
            var parentNode = FindNode(_rootNode, parentId);

            AddNode(parentNode, new TreeNode(childId));
        }

        private void AddNode(TreeNode parent, TreeNode child)
        {
            parent.AddChild(child);
        }

        public TreeNode GetRootNode()
        {
            return _rootNode;
        }

        public int CountAllPaths()
        {
            return CountAllPaths(_rootNode );

        }

        public int CountAllPaths(TreeNode root)
        {

            var count = 0;
            if (root == null)
            {
                return 0;
            }
            else if (root.children.Count() == 0 )
            {
                return DistanceToRoot(root);
            }

            count += DistanceToRoot(root);
            foreach (var c in root.children)
            {
                count += CountAllPaths(c);             
            }

            return count;
        }

        public int DistanceToRoot(TreeNode node)
        {
            var count = 0;
            while (node.parent != null)
            {
                count++;
                node = node.parent;
            }

            return count;
        }



    }
}
