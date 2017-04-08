
╟─┬─────────────────────────────────────────────────────────────────────┐
	│TeamBuilder.Clients
	├─┬───────────────────────────────────────────────────────────────────┘
		├─ Command Pattern
		
╟─┬─────────────────────────────────────────────────────────────────────┐
	│TeamBuilder.Clients2
	├─┬───────────────────────────────────────────────────────────────────┘
		├─ /* Switch Case - call command */
		├─██ Reflection
		├─ Utilities
		├─┬─────────────────────────────────────────────────────────────────┤
			├─ Constants - contants and error message string
			├─ Check - input parameter length
			├─ Authentication - saves current user
			├─ Controller
			├─ DBServices
			├─ Switcher
			
╟─┬─────────────────────────────────────────────────────────────────────┐
	│ TeamBuilder.Data
	├─┬───────────────────────────────────────────────────────────────────┘
		├─ Config - Fluent API
		├─┬─────────────────────────────────────────────────────────────────┤
			├─ Init
			├─ TeamBuilderContext
			
╟─┬─────────────────────────────────────────────────────────────────────┐
	│ TeamBuilder.Models
	├─┬───────────────────────────────────────────────────────────────────┘
		├─ Attributes - not needed
		├─┬─────────────────────────────────────────────────────────────────┤
			├─ PasswordAttribute
			├─ ExactLengthAttribute
		
╟─├─┬───────────────────────────────────────────────────────────────────┤
		├─ Event
		├─ Invitation
		├─ Team
		├─ User
		
╟─┬─────────────────────────────────────────────────────────────────────┐
	│ DateTime.TryParseExact
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
	
╟─┬─────────────────────────────────────────────────────────────────────┐
	│ Reflection
	├─┬───────────────────────────────────────────────────────────────────┘
	
		public string GetCommand(string input)
		{
			var result = string.Empty;

			var inputParam = input.Split(
				new char[] { ' ', '\t' },
				StringSplitOptions.RemoveEmptyEntries);
			var cmdString = inputParam.Length > 0 ? inputParam[0] : string.Empty;
			var cmdParam = inputParam.Skip(1).ToArray();

			Type commandType = Type.GetType(
				$"TeamBuilder.Clients2.Commands.Cmd{cmdString}");

			if (commandType == null)
			{
				throw new NotSupportedException(
					$"Command {cmdString} not supported!");
			}

			object command = Activator.CreateInstance(commandType);

			MethodInfo executeMethod = command.GetType()
				.GetMethod("Execute");

			result = executeMethod.Invoke(
				command, new object[] { cmdParam }
				) as string;
				
			return result;
		}