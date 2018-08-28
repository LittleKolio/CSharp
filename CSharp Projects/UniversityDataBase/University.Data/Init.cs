namespace University.Data
{
    public class Init
    {
        public static void Initializer()
        {
            UniversityContext context = new UniversityContext();
            using (context)
            {
                context.Database.Initialize(true);
            }
        }
    }
}
