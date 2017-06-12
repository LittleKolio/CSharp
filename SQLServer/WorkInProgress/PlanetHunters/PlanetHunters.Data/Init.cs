namespace PlanetHunters.Data
{
    public class Init
    {
        public static void Initializer()
        {
            var context = new PlanetHuntersContext();
            context.Database.Initialize(true);
        }
    }
}
