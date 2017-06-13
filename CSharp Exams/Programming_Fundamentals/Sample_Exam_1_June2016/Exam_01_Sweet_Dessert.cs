using System;

namespace Sample_Exam_1_June2016
{
    class Exam_01_Sweet_Dessert
    {
        public static void Main()
        {
            decimal cash = decimal.Parse(Console.ReadLine());
            int guests = int.Parse(Console.ReadLine());
            decimal pBan = decimal.Parse(Console.ReadLine());
            decimal pEgg = decimal.Parse(Console.ReadLine());
            decimal pBerKg = decimal.Parse(Console.ReadLine());

            decimal for6 = 2m * pBan + 4m * pEgg + 0.2m * pBerKg;
            decimal desserts = Math.Ceiling(guests / 6m);
            if (desserts * for6 <= cash)
            {
                Console.WriteLine("Ivancho has enough money - it would cost {0:F2}lv.", desserts * for6);
            }
            else
            {
                Console.WriteLine("Ivancho will have to withdraw money - he will need {0:F2}lv more.", desserts * for6 - cash);
            }
        }
    }
}
