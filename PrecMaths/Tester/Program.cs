using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PrecMaths;
using PrecMaths.Symbols;
using PrecMaths.Numbers;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            OperatorSymbol mul = new OperatorSymbol(MathOperator.Multiply);
            SymbolTreeNode s = new SymbolTreeNode(mul);
            SymbolTreeNode sr = new SymbolTreeNode(new PiSymbol(1));
            SymbolTreeNode sl = new SymbolTreeNode(new RationalSymbol(3, 1));
            s.RightNode = sr;
            s.LeftNode = sl;
            SymbolTree st = new SymbolTree(s);
            SymbolicCalculation sc = new SymbolicCalculation(st);
            
            Console.ReadLine();

        }
    }
}
