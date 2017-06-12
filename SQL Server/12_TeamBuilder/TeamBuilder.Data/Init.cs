namespace TeamBuilder.Data
{
    public class Init
    {
        public static void Initializer()
        {
            var context = new TeamBuilderContext();
            using (context)
            {
                context.Database.Initialize(true);
            }
        }
    }
}
