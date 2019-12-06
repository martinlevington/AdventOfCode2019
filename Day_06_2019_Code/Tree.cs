using System;
using System.Collections.Generic;
using System.Linq;

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
            Init(orbits);
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
            return CountAllPaths(_rootNode);

        }

        public int CountAllPaths(TreeNode root)
        {

            var count = 0;
            if (root == null)
            {
                return 0;
            }
            else if (root.children.Count() == 0)
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

        // you path to root
        // san path too root
        // find intersection
        // path intersection + path from san to intersection
        public int HopsToSanta()
        {
            var myPathTooRoot = NodesToRoot(FindNode(_rootNode, "YOU"));
            var intersection = FindIntersection(myPathTooRoot, FindNode(_rootNode, "SAN"));
            var YOUhops = HopsToNode(intersection, FindNode(_rootNode, "YOU"));
            var SANHops = HopsToNode(intersection, FindNode(_rootNode, "SAN"));

            return YOUhops + SANHops - 2;
        }

        public TreeNode FindIntersection(List<TreeNode> nodes, TreeNode node)
        {
            while (node.parent != null && !nodes.Where(x => x.val == node.val).Any())
            {
                node = node.parent;
            }

            return nodes.Where(x => x.val == node.val).Any() ? node : null;
        }

        public int HopsToNode(TreeNode root, TreeNode node)
        {
            var count = 0;
            while (node.val != root.val && node.parent != null)
            {
                count++;
                node = node.parent;
            }

            return count;
        }

        public int DistanceToRoot(TreeNode node)
        {
            return HopsToNode(_rootNode, node);
        }

        public List<TreeNode> NodesToRoot(TreeNode node)
        {
            var nodes = new List<TreeNode>();
            while (node.parent != null)
            {
                nodes.Add(node);
                node = node.parent;
            }

            return nodes;
        }


    }
}
