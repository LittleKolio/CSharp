namespace Sample_Exam_1.Models
{
    using System.Collections.Generic;

    public abstract class Race
    {
        private List<Car> participants;
        public Race(int length, string route, int prizePool)
        {
            this.Length = length;
            this.Route = route;
            this.PrizePool = prizePool;
            this.participants = new List<Car>();
        }
        public int Length { get; set; }
        public string Route { get; set; }
        public int PrizePool { get; set; }
    }
}
