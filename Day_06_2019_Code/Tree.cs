using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_06_2019_Code
{
    public class Tree
    {
        private List<TreeNode> _nodes;
        private readonly char _orbitSeparator = ')';
        private TreeNode _rootNode;

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
            if (orbits.Length == 0)
            {
                return;
            }

            _rootNode = new TreeNode("");
            _nodes = new List<TreeNode>();

            foreach (var orbit in orbits)
            {
                var planetOrbit = GetOrbit(orbit);
                TreeNode parent;
                TreeNode child;

                parent = !NodeExists(planetOrbit.ParentPlanet) ? CreateNode(planetOrbit.ParentPlanet) : _nodes.First(x => x.Val == planetOrbit.ParentPlanet);

                child = !NodeExists(planetOrbit.ChildPlanet) ? CreateNode(planetOrbit.ChildPlanet) : _nodes.First(x => x.Val == planetOrbit.ChildPlanet);

                if (parent.Children.All(x => x.Val != child.Val))
                {
                    parent.Children.Add(child);
                }

                child.Parent = parent;
            }

            _rootNode = FindRootNode(_nodes[0]);
        }


        public TreeNode FindRootNode(TreeNode node)
        {
            while (node.Parent != null)
            {
                node = node.Parent;
            }

            return node;
        }

        public bool NodeExists(string nodeId)
        {
            var res = _nodes.Any(x => x.Val == nodeId);
            return _nodes.Any(x => x.Val == nodeId);
        }


        public TreeNode CreateNode(string node)
        {
            var newNode = new TreeNode(node);
            _nodes.Add(newNode);

            return newNode;
        }

        private Orbit GetOrbit(string orbit)
        {
            var parent = orbit.Split(new[] {_orbitSeparator}, StringSplitOptions.RemoveEmptyEntries).First();
            var child = orbit.Split(new[] {_orbitSeparator}, StringSplitOptions.RemoveEmptyEntries).Last();

            return new Orbit(parent, child);
        }

        private void AddOrbit(string orbit)
        {
            var parent = orbit.Split(new[] {_orbitSeparator}, StringSplitOptions.RemoveEmptyEntries).First();
            var child = orbit.Split(new[] {_orbitSeparator}, StringSplitOptions.RemoveEmptyEntries).Last();

            AddNode(parent, child);
        }

        public TreeNode FindNode(TreeNode root, string nodeId)
        {
            if (root == null)
            {
                return null;
            }

            if (root.Val == nodeId)
            {
                return root;
            }

            TreeNode found = null;
            foreach (var c in root.Children)
            {
                found = FindNode(c, nodeId);
                if (found != null)
                {
                    break;
                }
            }

            return found;
        }


        public bool NodeExists(TreeNode root, string nodeId)
        {
            if (root == null)
            {
                return false;
            }

            if (root.Val == nodeId)
            {
                return true;
            }

            var found = false;
            foreach (var c in root.Children)
            {
                found = NodeExists(c, nodeId);
                if (found)
                {
                    break;
                }
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

            if (!root.Children.Any())
            {
                return DistanceToRoot(root);
            }

            count += DistanceToRoot(root);
            foreach (var c in root.Children)
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
            var yoUhops = HopsToNode(intersection, FindNode(_rootNode, "YOU"));
            var sanHops = HopsToNode(intersection, FindNode(_rootNode, "SAN"));

            return yoUhops + sanHops - 2;
        }

        public TreeNode FindIntersection(List<TreeNode> nodes, TreeNode node)
        {
            while (node.Parent != null && nodes.All(x => x.Val != node.Val))
            {
                node = node.Parent;
            }

            return nodes.Any(x => x.Val == node.Val) ? node : null;
        }

        public int HopsToNode(TreeNode root, TreeNode node)
        {
            var count = 0;
            while (node.Val != root.Val && node.Parent != null)
            {
                count++;
                node = node.Parent;
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
            while (node.Parent != null)
            {
                nodes.Add(node);
                node = node.Parent;
            }

            return nodes;
        }
    }
}