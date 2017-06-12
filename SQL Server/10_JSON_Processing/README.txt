╟─┬─────────────────────────────────────────────────────────────────────┐
	│ CarDealer
	├─┬───────────────────────────────────────────────────────────────────┘
		├─ Clients
		├─┬─────────────────────────────────────────────────────────────────┤
			├─ Query
			├─██ Query_04_Cars_List_Parts - Mapper
			├─ Startup - JsonConvert.DeserializeObject

╟─┬─────────────────────────────────────────────────────────────────────┐
	│ ProductsShop
	├─┬───────────────────────────────────────────────────────────────────┘
		├─ Clients
		├─┬─────────────────────────────────────────────────────────────────┤
			├─ Query
			├─██ Mapper
			├─ Startup - JsonConvert.DeserializeObject
			
	├─┬───────────────────────────────────────────────────────────────────┤
		├─ Models
		├─┬─────────────────────────────────────────────────────────────────┤
			├─ Configuration - Fuent API
			

╟─┬─────────────────────────────────────────────────────────────────────┐
	│ JsonSerializerSettings
	├─┬───────────────────────────────────────────────────────────────────┘
		JsonSerializerSettings settings = new JsonSerializerSettings
		{
			//ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
			//PreserveReferencesHandling = PreserveReferencesHandling.Objects,
			//PreserveReferencesHandling = PreserveReferencesHandling.All,
			
			Formatting = Formatting.Indented
		};
		
╟─┬─────────────────────────────────────────────────────────────────────┐
	│ Mapper is valid
	├─┬───────────────────────────────────────────────────────────────────┘
		Mapper.AssertConfigurationIsValid();