╟─┬─────────────────────────────────────────────────────────────────────┐
	│ StudentSystem
	├─┬───────────────────────────────────────────────────────────────────┘
		├─ Data
		├─┬─────────────────────────────────────────────────────────────────┤
			├─ StudentSystemInitializer - custom Initializer and override Seed()
			
╟─├─┬───────────────────────────────────────────────────────────────────┘
		├─ Migrations
		├─┬─────────────────────────────────────────────────────────────────┤
			├─ Configuration - override Seed() -██ AddOrUpdate()
			
╟─├─┬───────────────────────────────────────────────────────────────────┘
		├─ Util
		├─┬─────────────────────────────────────────────────────────────────┤
			├─██ Util - insert/read binary file using FileStream(), BinaryReader(), BinaryWriter()
			
╟─┬─────────────────────────────────────────────────────────────────────┐
	│ Photographers
	├─┬───────────────────────────────────────────────────────────────────┘
		├─ Util - Attribute Validation 
		├─┬─────────────────────────────────────────────────────────────────┤
			├─██ TagTransofrmer
			
╟─├─┬───────────────────────────────────────────────────────────────────┤
		├─ Clients
		├─┬─────────────────────────────────────────────────────────────────┤
			├─██ CatchValidationExeption();
			
╟─┬─────────────────────────────────────────────────────────────────────┐
	├─██ DbEntityValidationException
	├─┬───────────────────────────────────────────────────────────────────┘
		var t = new Tag
		{ Label = "D d__DFDd      fSDFDdfSDFw333333" };

		context.Tags.Add(t);

		try
		{
			context.SaveChanges();
		}
		catch (DbEntityValidationException ex)
		{
			if (eve.Entry.Entity.GetType().Name == "Tag")
			{ t.Label = TagTransofrmer.Transofrmer(t.Label); }
			
			context.SaveChanges();
		}