namespace Sample_Exam_1.Models
{
    using System.Collections.Generic;

    public abstract class Race
    {
        protected Dictionary<int, int> participants;
        public Race(int length, string route, int prizePool)
        {
            this.Length = length;
            this.Route = route;
            this.PrizePool = prizePool;
            this.participants = new Dictionary<int, int>();
        }
        public int Length { get; set; }
        public string Route { get; set; }
        public int PrizePool { get; set; }

        public abstract int Points(Car car);

        public void AddParticipant(int id, Car car)
        {
            this.participants.Add(id, this.Points(car));
        }
    }
}
