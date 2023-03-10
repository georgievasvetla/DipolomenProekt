using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreePrint
{
    internal class Tree<T>
    {
        public T Value { get; set; }
        public Tree<T> Parent { get; private set; }
        public List<Tree<T>> Children { get; private set; }

        public Tree(T value, params Tree<T>[] children)
        {
            this.Value = value;
            if (children == null)
            {
                this.Children = new List<Tree<T>>();
            }
            else
            {
                this.Children = children.ToList();
                foreach (var child in children)
                {
                    child.Parent = this;
                }
            }
        }

        
        public void SetParent(Tree<T> newParent)
        {
            this.Parent = newParent;
        }

        public static void PrintTree(Tree<T> node, int offset)
        {
            Console.WriteLine("{0}{1}", new string(' ', offset * 2), 
                node.Value);
            foreach (var child in node.Children)
            {
                PrintTree(child, offset + 1);
            }
        }
    }
}
