namespace MassDefect.Data
{
    public static class Init
    {
        public static void Initialize()
        {
            var context = new MassDefectContext();
            using (context)
            {
                context.Database.Initialize(true);
            }
        }
    }
}
