namespace FestivalManager.Entities.Sets
{
	using System;

	public class Medium : Set
	{
        private const int durationMin = 40;

        public Medium(string name)
			: base(name, new TimeSpan(0, durationMin, 0))
		{
		}
	}
}