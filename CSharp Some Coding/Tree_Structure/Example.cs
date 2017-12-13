using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeStructure
{
    public class Example
    {
        static void Main()
        {
            Tree<int> tree =
                new Tree<int>(
                    7,
                    new Tree<int>(
                        71,
                        new Tree<int>(2),
                        new Tree<int>(22),
                        new Tree<int>(222)
                        ),
                    new Tree<int>(72),
                    new Tree<int>(
                        73,
                        new Tree<int>(3),
                        new Tree<int>(33)
                        )
                    );

            tree.Traverse();
        }
    }
}
