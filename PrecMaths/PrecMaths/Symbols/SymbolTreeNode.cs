using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrecMaths.Symbols
{
    public class SymbolTreeNode
    {
        public SymbolTreeNode LeftNode = null;
        public SymbolTreeNode RightNode = null;
        public Symbol Symbol;
        public SymbolTreeNode(Symbol s)
        {
            this.Symbol = s;
        }
    }
}
