namespace ProductsShop.Clients
{
    using ProductsShop.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using System.IO;
    using Newtonsoft.Json.Linq;
    using Models;

    class Starup
    {
        static void Main(string[] args)
        {
            Init.InitializerDB();
        }
    }
}
