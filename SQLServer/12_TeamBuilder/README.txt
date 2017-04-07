
╟─┬─────────────────────────────────────────────────────────────────────┐
	│TeamBuilder.Clients
	├─┬───────────────────────────────────────────────────────────────────┘
		├─ Command Pattern
		
╟─┬─────────────────────────────────────────────────────────────────────┐
	│TeamBuilder.Clients2
	├─┬───────────────────────────────────────────────────────────────────┘
		├─ Switch Case - call command
		├─ Utilities
		├─┬─────────────────────────────────────────────────────────────────┤
			├─ Constants - contants and error message string
			├─ Check - input parameter length
			├─ Authentication - save current user
			
╟─┬─────────────────────────────────────────────────────────────────────┐
	│TeamBuilder.Data
	├─┬───────────────────────────────────────────────────────────────────┘
		├─ Config - Fluent API
		
╟─┬─────────────────────────────────────────────────────────────────────┐
	│TeamBuilder.Models
	├─┬───────────────────────────────────────────────────────────────────┘
		├─ Attributes - PasswordAttribute
		

╟─┬─────────────────────────────────────────────────────────────────────┐
	│DateTime.TryParseExact
	├─┬───────────────────────────────────────────────────────────────────┘	
		DateTime startDateTime;
		var tryParse_startDateTime = DateTime.TryParseExact(
			cmdParam[2] + " " + cmdParam[3],
			Constants.DateTimeFormat,
			CultureInfo.InvariantCulture,
			DateTimeStyles.None,
			out startDateTime
		);
		
╟─┬─────────────────────────────────────────────────────────────────────┐
	│Enum.TryParse
	├─┬───────────────────────────────────────────────────────────────────┘
		Gender gender;
		
		var isGender = Enum.TryParse(cmdParam[6], out gender);
		if (!isGender)
		{
			throw new ArgumentException(
				Constants.ErrorMessages.GenderNotValid);
		}