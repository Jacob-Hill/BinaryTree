using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    class BinarySearchTree
    {
        private class TreeNode
        {
            TreeNode ParentNode { get; set; }
            public TreeNode[] ChildrenNodes = new TreeNode[2];
            public string Data { get; set; }
            public TreeNode(string data, TreeNode parent)
            {
                Data = data;
                ParentNode = parent;
                ChildrenNodes = [null, null];
            }
        }

        private TreeNode root;

        BinarySearchTree(string data) 
        {
            root = new TreeNode(data, null);
        }

        void AddChild(string data, TreeNode parent)
        {
            for(int i = 0; i<data.Length && i<parent.Data.Length; i++)
            {
                if (data[i] < parent.Data[i])
                {
                    if (parent.ChildrenNodes[0] != null)
                    {
                        AddChild(data, parent.ChildrenNodes[0]);
                    }
                    else
                    {
                        TreeNode newNode = new TreeNode(data, parent);
                    }
                }
                else if (data[i] > parent.Data[i])
                {
                    if (parent.ChildrenNodes[1] != null)
                    {
                        AddChild(data, parent.ChildrenNodes[1]);
                    }
                    else
                    {
                        TreeNode newNode = new TreeNode(data, parent);
                    }
                }
            }
            if (data.Length < parent.Data.Length)
            {
                if (parent.ChildrenNodes[0] != null)
                {
                    AddChild(data, parent.ChildrenNodes[0]);
                }
                else
                {
                    TreeNode newNode = new TreeNode(data, parent);
                }
            }
            else
            {
                if (parent.ChildrenNodes[1] != null)
                {
                    AddChild(data, parent.ChildrenNodes[1]);
                }
                else
                {
                    TreeNode newNode = new TreeNode(data, parent);
                }
            }
            
        }

        public void AddNode(string data)
        {
            AddChild(data, root);
        }
    }
}
