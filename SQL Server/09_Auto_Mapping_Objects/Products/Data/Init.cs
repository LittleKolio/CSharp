namespace Products.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class Init
    {
        public static void Initializer()
        {
            ProductsContext context = new ProductsContext();
            using (context)
            {
                context.Database.Initialize(true);
            }
        }
    }
}
