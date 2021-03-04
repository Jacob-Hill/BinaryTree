using System;
using System.Collections.Generic;
using System.Linq;

namespace BinaryTree
{
    class BinarySearchTree<T> where T : IComparable<T>
    {
        private class TreeNode
        {
            public TreeNode ParentNode;
            public TreeNode[] ChildrenNodes = { null, null };
            public T Data;
            public TreeNode(T data, TreeNode parent)
            {
                Data = data;
                ParentNode = parent;
            }
        }

        private TreeNode root;

        public BinarySearchTree(T data) 
        {
            root = new TreeNode(data, null);
        }

        void AddChild(TreeNode child, TreeNode parent)
        { 
            for(int i = 0; i< child.Data.ToString().Length && i<parent.Data.ToString().Length; i++)
            {
                if (child.Data.ToString()[i] < parent.Data.ToString()[i])
                {
                    if (parent.ChildrenNodes[0] != null)
                    {
                        AddChild(child, parent.ChildrenNodes[0]);
                        return;
                    }
                    else
                    {
                        child.ParentNode = parent;
                        parent.ChildrenNodes[0] = child;
                        return;
                    }
                }
                else if (child.Data.ToString()[i] > parent.Data.ToString()[i])
                {
                    if (parent.ChildrenNodes[1] != null)
                    {
                        AddChild(child, parent.ChildrenNodes[1]);
                        return;
                    }
                    else
                    {
                        child.ParentNode = parent;
                        parent.ChildrenNodes[1] = child;
                        return;
                    }
                }
                else if(i==child.Data.ToString().Length-1 || i == parent.Data.ToString().Length - 1)
                {
                    if (child.Data.ToString().Length < parent.Data.ToString().Length)
                    {
                        if (parent.ChildrenNodes[0] != null)
                        {
                            AddChild(child, parent.ChildrenNodes[0]);
                            return;
                        }
                        else
                        {
                            child.ParentNode = parent;
                            parent.ChildrenNodes[0] = child;
                            return;
                        }
                    }
                    else
                    {
                        if (parent.ChildrenNodes[1] != null)
                        {
                            AddChild(child, parent.ChildrenNodes[1]);
                            return;
                        }
                        else
                        {
                            child.ParentNode = parent;
                            parent.ChildrenNodes[1] = child;
                            return;
                        }
                    }
                }
            }
        }

        public void AddNode(T data)
        {
            AddChild(new TreeNode(data, null), root);
        }

        (bool,TreeNode) SearchThroughChildren(T data, TreeNode parent)
        {
            for (int i = 0; i < data.ToString().Length && i < parent.Data.ToString().Length; i++)
            {
                if (data.ToString()[i] < parent.Data.ToString()[i])
                {
                    if (parent.ChildrenNodes[0] != null)
                    {
                        if (!parent.ChildrenNodes[0].Data.Equals(data))
                        {
                            SearchThroughChildren(data, parent.ChildrenNodes[0]);
                        }
                        else
                        {
                            return (true, parent.ChildrenNodes[0]);
                        }
                    }
                    else
                    {
                        return (false,null);
                    }
                }
                else if (data.ToString()[i] > parent.Data.ToString()[i])
                {
                    if (parent.ChildrenNodes[1] != null)
                    {
                        if (!parent.ChildrenNodes[1].Data.Equals(data))
                        {
                            SearchThroughChildren(data, parent.ChildrenNodes[1]);
                        }
                        else
                        {
                            return (true, parent.ChildrenNodes[1]);
                        }
                    }
                    else
                    {
                        return (false, null);
                    }
                }
            }
            if (data.ToString().Length < parent.Data.ToString().Length)
            {
                if (parent.ChildrenNodes[0] != null)
                {
                    if (!parent.ChildrenNodes[0].Data.Equals(data))
                    {
                        SearchThroughChildren(data, parent.ChildrenNodes[0]);
                    }
                    else
                    {
                        return (true, parent.ChildrenNodes[0]);
                    }
                }
                else
                {
                    return (false, null);
                }
            }
            else
            {
                if (parent.ChildrenNodes[1] != null)
                {
                    if (!parent.ChildrenNodes[1].Data.Equals(data))
                    {
                        SearchThroughChildren(data, parent.ChildrenNodes[1]);
                    }
                    else
                    {
                        return (true, parent.ChildrenNodes[1]);
                    }
                }
                else
                {
                    return (false, null);
                }
            }
            return (false, null); //Code should never reach this point, but visual studio complains if it is not here
        }

        public bool Contains(T data)
        {
            (bool a, TreeNode b) =  SearchThroughChildren(data, root); //Don't care about the treeNode, but it is easier to do it this way
            return a;
        }

        public void Remove(T data)
        {
            (bool a, TreeNode b) = SearchThroughChildren(data, root);
            if (a) //Runs if the specified bit of data is in the tree
            {
                if (b.ChildrenNodes[0] != null && b.ChildrenNodes[1] != null)
                {
                    AddChild(b.ChildrenNodes[0], b.ParentNode);
                    AddChild(b.ChildrenNodes[1], b.ParentNode);
                }
                else if (b.ChildrenNodes[0] != null)
                {
                    if (b.ParentNode.ChildrenNodes[0] == b)
                    {
                        b.ParentNode.ChildrenNodes[0] = b.ChildrenNodes[0];
                    }
                    else
                    {
                        b.ParentNode.ChildrenNodes[1] = b.ChildrenNodes[0];
                    }
                }
                else if (b.ChildrenNodes[1] != null)
                {
                    if (b.ParentNode.ChildrenNodes[0] == b)
                    {
                        b.ParentNode.ChildrenNodes[0] = b.ChildrenNodes[1];
                    }
                    else
                    {
                        b.ParentNode.ChildrenNodes[1] = b.ChildrenNodes[1];
                    }
                }
                else
                {
                    if (b.ParentNode.ChildrenNodes[0] == b)
                    {
                        b.ParentNode.ChildrenNodes[0] = null;
                    }
                    else
                    {
                        b.ParentNode.ChildrenNodes[1] = null;
                    }
                }
            }
        }

        List<T> InOrder(List<T> data, TreeNode node)
        {
            if (node.ChildrenNodes[0] != null)
            {
                data.Union(InOrder(data, node.ChildrenNodes[0]));
            }
            else
            {
                data.Add(node.Data);
            }
            if (node.ChildrenNodes[1] != null)
            {
                data.Union(InOrder(data, node.ChildrenNodes[1]));
            }
            return (data);
        }

        public List<T> InOrder(T StartPoint)
        {
            (bool a, TreeNode b) = SearchThroughChildren(StartPoint, root);
            return InOrder(new List<T> { }, b);
        }
    }
}
