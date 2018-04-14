using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

public class MissionFactory : IMissionFactory
{
    public IMission CreateMission(string difficultyLevel, double neededPoints)
    {
        Type missionType = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name == difficultyLevel);

        if (missionType == null)
        {
            throw new ArgumentException(
                "Invalid MissionType!");
        }

        if (!typeof(IMission).IsAssignableFrom(missionType))
        {
            throw new InvalidOperationException(
                "MissionType don't inherit IMission!");
        }

        object[] parameters = new object[] { neededPoints };

        IMission mission = (IMission)Activator.CreateInstance(
            missionType, parameters);

        return mission;
    }
}
