namespace BinaryTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Example
    {
        public static void Main()
        {
            BinaryTree<int> tree =
                new BinaryTree<int>(31,
                    new BinaryTree<int>(41,
                        new BinaryTree<int>(51),
                        new BinaryTree<int>(52,
                            new BinaryTree<int>(61),
                            new BinaryTree<int>(62)
                            )
                        ),
                    new BinaryTree<int>(42,
                        new BinaryTree<int>(51),
                        null
                    )
                );

            tree.Print(); 
        }
    }
}
