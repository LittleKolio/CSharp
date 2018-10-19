namespace Products.Data
{
    using Newtonsoft.Json;
    using Products.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ProductsInitializer : DropCreateDatabaseAlways<ProductsContext>
    {
        protected override void Seed(ProductsContext context)
        {
            string clientsJSON = File.ReadAllText(@"..\..\Import\Clients.json");
            List<Client> clients = JsonConvert.DeserializeObject<List<Client>>(clientsJSON);

            context.Clients.AddRange(clients);

            base.Seed(context);
        }
    }
}
