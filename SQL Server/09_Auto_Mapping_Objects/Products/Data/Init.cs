namespace Products.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class Init
    {
        public static void Initializer()
        {
            //Database.Delete("ProductsContext");

            using (ProductsContext context = new ProductsContext())
            {
                context.Database.Initialize(true);
            }
        }
    }
}
