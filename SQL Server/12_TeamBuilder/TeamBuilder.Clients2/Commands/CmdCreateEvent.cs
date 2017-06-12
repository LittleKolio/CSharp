namespace TeamBuilder.Clients2.Commands
{
    using Models;
    using System;
    using System.Globalization;
    using TeamBuilder.Clients2.Utilities;

    public class CmdCreateEvent
    {
        public string Execute(string[] cmdParam)
        {
            //0. <name>
            //1. <description>
            //2. <startDate>
            //3. <startTime>
            //4. <endDate>
            //5. <endTime>

            Check.CheckLength(6, cmdParam);
            Authentication.Authorize();

            var name = cmdParam[0];
            var description = cmdParam[1];

            DateTime startDateTime;
            var tryParse_startDateTime = DateTime.TryParseExact(
                cmdParam[2] + " " + cmdParam[3],
                Constants.DateTimeFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out startDateTime
                );

            DateTime endDateTime;
            var tryParse_endDateTime = DateTime.TryParseExact(
                cmdParam[4] + " " + cmdParam[5],
                Constants.DateTimeFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out endDateTime
                );

            if (!tryParse_startDateTime || !tryParse_endDateTime)
            {
                throw new ArgumentException(
                    Constants.ErrorMessages.InvalidDateFormat);
            }

            if (startDateTime > endDateTime)
            {
                throw new ArgumentException(
                    "Start date should be before end date.");
            }

            var newEvent = new Event
            {
                Name = name,
                Description = description,
                StartDate = startDateTime,
                EndDate = endDateTime
            };
            var user = Authentication.GetCurrentUser();

            DBServices.CreateEvent(newEvent, user);

            return $"Event {name} was created successfully!";
        }
    }
}
