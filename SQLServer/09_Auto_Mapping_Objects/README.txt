╟─┬─────────────────────────────────────────────────────────────────────┐
	│ Employees
	├─┬───────────────────────────────────────────────────────────────────┘
		├─ Exercises
		├─ Migrations
		├─┬─────────────────────────────────────────────────────────────────┤
			├─ override void Seed()
			

╟─┬─────────────────────────────────────────────────────────────────────┐
	│ class Name override ToString()
	├─┬───────────────────────────────────────────────────────────────────┘
		├─██ override ToString()
		├─██ StringBuilder()
		
		public override string ToString()
		{
			var result = new StringBuilder();
			
			result.AppendLine(
				$"{this.Firstname} {this.Lastname} | Employees: {this.SubCount}");
				
			foreach (var sub in this.Subordinates)
			{
				result.AppendLine(sub.ToToString());
			}
			return result.ToString().Trim();
		}