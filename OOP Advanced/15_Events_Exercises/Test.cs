using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events_Exercises
{
    public class Test
    {
        public delegate void DelegateExample(int num, EnumType enumType);


        static void Main()
        {
            DelegateExample dele1 = HandlerExample;
            dele1(1, EnumType.e1);

            DelegateExample dele2 = new DelegateExample(HandlerExample);
            dele2(2, EnumType.e2);

            MethodTest(HandlerExample);

            DelegateExample dele4 = HandlerExample;
            dele4 += dele1;
            dele4(4, EnumType.e4);

            DelegateExample dele4 = () => Console.WriteLine($"Number : {num} / Enum : {enumType}");
        }

        static void MethodTest(DelegateExample dele3)
        {
            dele3(3, EnumType.e3);
        }


        static public void HandlerExample(int num, EnumType enumType)
        {
            Console.WriteLine($"Number : {num} / Enum : {enumType}");
        }
    }
}
