using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    class BinarySearchTree
    {
        private class TreeNode
        {
            public TreeNode ParentNode { get; set; }
            public TreeNode[] ChildrenNodes = { null, null };
            public string Data { get; set; }
            public TreeNode(string data, TreeNode parent)
            {
                Data = data;
                ParentNode = parent;
            }
        }

        private TreeNode root;

        BinarySearchTree(string data) 
        {
            root = new TreeNode(data, null);
        }

        void AddChild(TreeNode Child, TreeNode parent)
        {
            for(int i = 0; i< Child.Data.Length && i<parent.Data.Length; i++)
            {
                if (Child.Data[i] < parent.Data[i])
                {
                    if (parent.ChildrenNodes[0] != null)
                    {
                        AddChild(Child, parent.ChildrenNodes[0]);
                    }
                    else
                    {
                        Child.ParentNode = parent;
                        parent.ChildrenNodes[0] = Child;
                    }
                }
                else if (Child.Data[i] > parent.Data[i])
                {
                    if (parent.ChildrenNodes[1] != null)
                    {
                        AddChild(Child, parent.ChildrenNodes[1]);
                    }
                    else
                    {
                        Child.ParentNode = parent;
                        parent.ChildrenNodes[1] = Child;
                    }
                }
            }
            if (Child.Data.Length < parent.Data.Length)
            {
                if (parent.ChildrenNodes[0] != null)
                {
                    AddChild(Child, parent.ChildrenNodes[0]);
                }
                else
                {
                    Child.ParentNode = parent;
                    parent.ChildrenNodes[0] = Child;
                }
            }
            else
            {
                if (parent.ChildrenNodes[1] != null)
                {
                    AddChild(Child, parent.ChildrenNodes[1]);
                }
                else
                {
                    Child.ParentNode = parent;
                    parent.ChildrenNodes[1] = Child;
                }
            }
            
        }

        public void AddNode(string data)
        {
            AddChild(new TreeNode(data, null), root);
        }

        (bool,TreeNode) SearchThroughChildren(string data, TreeNode parent)
        {
            for (int i = 0; i < data.Length && i < parent.Data.Length; i++)
            {
                if (data[i] < parent.Data[i])
                {
                    if (parent.ChildrenNodes[0] != null)
                    {
                        if (parent.ChildrenNodes[0].Data != data)
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
                else if (data[i] > parent.Data[i])
                {
                    if (parent.ChildrenNodes[1] != null)
                    {
                        if (parent.ChildrenNodes[1].Data != data)
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
            if (data.Length < parent.Data.Length)
            {
                if (parent.ChildrenNodes[0] != null)
                {
                    if (parent.ChildrenNodes[0].Data != data)
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
                    if (parent.ChildrenNodes[1].Data != data)
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

        public bool Contains(string data)
        {
            (bool a, TreeNode b) =  SearchThroughChildren(data, root); //Don't care about the treeNode, but it is easier to do it this way
            return a;
        }

        public void Remove(string data)
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
    }
}
