namespace BookCatalog.Data
{
    public static class Init
    {
        public static void InitDB()
        {
            var context = new BookCatalogContext();
            context.Database.Initialize(true);
        }
    }
}
