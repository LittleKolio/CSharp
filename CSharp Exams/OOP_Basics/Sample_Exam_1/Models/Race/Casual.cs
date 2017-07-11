using System;

namespace Sample_Exam_1.Models
{
    public class Casual : Race
    {
        public Casual(int length, string route, int prizePool) 
            : base(length, route, prizePool)
        { }

        public override int Points(Car car)
        {
            return car.Horsepower / car.Acceleration + 
                car.Suspension + car.Durability;
            
        }
    }
}
