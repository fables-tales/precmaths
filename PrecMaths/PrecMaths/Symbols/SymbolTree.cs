using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrecMaths.Symbols
{
    public class SymbolTree
    {
        public SymbolTreeNode RootNode;
        public SymbolTree(SymbolTreeNode s)
        {
            this.RootNode = s;
        }
        public List<Symbol> PostOrderTraverse()
        {
            List<Symbol> result = new List<Symbol>();
            SymbolTreeNode n = this.RootNode;
            
            if (n.LeftNode != null)
            {
                result.AddRange(new SymbolTree(n.LeftNode).PostOrderTraverse());
            }
            if (n.RightNode != null)
            {
                result.AddRange(new SymbolTree(n.RightNode).PostOrderTraverse());
            }
            result.Add(n.Symbol);
            return result;
        }
    }
}
