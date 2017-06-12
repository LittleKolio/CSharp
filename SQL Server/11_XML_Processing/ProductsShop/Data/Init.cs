namespace ProductsShop.Data
{
    public static class Init
    {
        public static void InitializerDB()
        {
            var context = new ProductsShopContext();
            context.Database.Initialize(true);
        }
    }
}
