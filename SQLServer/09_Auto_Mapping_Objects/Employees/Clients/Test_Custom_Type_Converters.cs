namespace Employees.Clients
{
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Test_Custom_Type_Converters
    {
        static void Main()
        {
            var source = new Source
            {
                Value1 = "5",
                Value2 = "01/01/2000",
                //Value3 = "AutoMapperSamples.GlobalTypeConverters.GlobalTypeConverters+Destination"
            };

            Mapper.Initialize(cfg => {
                cfg.CreateMap<string, int>()
                    //.ConvertUsing(Convert.ToInt32);
                    .ConvertUsing(x => int.Parse(x));

                cfg.CreateMap<string, DateTime>()
                    .ConvertUsing(new DateTimeTypeConverter());
                    //.ConvertUsing(x => Convert.ToDateTime(x));

                //cfg.CreateMap<string, Type>()
                //    .ConvertUsing<TypeTypeConverter>();

                cfg.CreateMap<Source, Destination>();
            });

            Destination result = Mapper.Map<Source, Destination>(source);
            //result.Value3.ShouldEqual(typeof(Destination));

            Console.WriteLine(result.Value1);
            Console.WriteLine(result.Value2);
        }

    }


    public class DateTimeTypeConverter : ITypeConverter<string, DateTime>
    {
        public DateTime Convert(
                string source,
                DateTime destination,
                ResolutionContext context)
        {
            return System.Convert.ToDateTime(source);
        }
    }

    //public class TypeTypeConverter : ITypeConverter<string, Type>
    //{
    //    public Type Convert(
    //            string source,
    //            Type destination,
    //            ResolutionContext context)
    //    {
    //        return context.SourceType;
    //    }
    //}

    public class Source
    {
        public string Value1 { get; set; }
        public string Value2 { get; set; }
        //public string Value3 { get; set; }
    }

    public class Destination
    {
        public int Value1 { get; set; }
        public DateTime Value2 { get; set; }
        //public Type Value3 { get; set; }
    }
}
