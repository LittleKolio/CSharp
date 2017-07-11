using System;

namespace Sample_Exam_1.Models
{
    public class Drift : Race
    {
        public Drift(int length, string route, int prizePool) 
            : base(length, route, prizePool)
        { }

        public override int Points(Car car)
        {
            return car.Suspension + car.Durability;
        }
    }
}
