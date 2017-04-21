namespace PlanetHunters.App
{
    using PlanetHunters.Data;
    using Import;

    class Startup
    {
        static void Main()
        {
            //Init.Initializer();

            //Test.ZeroOrNegativeAttribute();

            //Import.ImportAstronomers();
            //Import.ImportTelescopes();
            //Import.ImportPlanets();
            //Import.ImportStars();
            Import.ImportDiscoveries();
        }
    }
}
