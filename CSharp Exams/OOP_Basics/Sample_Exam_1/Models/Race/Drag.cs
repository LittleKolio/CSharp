using System;

namespace Sample_Exam_1.Models
{
    public class Drag : Race
    {
        public Drag(int length, string route, int prizePool) 
            : base(length, route, prizePool)
        { }

        public override int Points(Car car)
        {
            return car.Horsepower / car.Acceleration;
        }
    }
}
