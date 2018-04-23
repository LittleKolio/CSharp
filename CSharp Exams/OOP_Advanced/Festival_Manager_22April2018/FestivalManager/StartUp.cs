namespace FestivalManager
{
    using System.IO;
    using System.Linq;
    using Core;
    using Core.Contracts;
    using Core.Controllers;
    using Core.Controllers.Contracts;
    using Core.IO;
    using Core.IO.Contracts;
    using Entities;
    using Entities.Contracts;
    using Entities.Factories.Contracts;
    using Entities.Factories;

    public static class StartUp
	{
		public static void Main(string[] args)
		{
            //Repo
			IStage stage = new Stage();

            //Factories
            IInstrumentFactory instrumentFactory = new InstrumentFactory();
            ISetFactory setFactory = new SetFactory();

            //Controllers
            IFestivalController festivalController = new FestivalController(
                stage, instrumentFactory, setFactory);
			ISetController setController = new SetController(stage);

            //IO
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

			IEngine engine = new Engine(
                festivalController, 
                setController,
                stage,
                reader,
                writer);

			engine.Run();
		}
	}
}