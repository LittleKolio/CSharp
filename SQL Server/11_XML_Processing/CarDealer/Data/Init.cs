namespace CarDealer.Data
{
    public static class Init
    {
        public static void Initializer()
        {
            var context = new CarDealerContext();
            using (context)
            {
                context.Database.Initialize(true);
            }
        }
    }
}
