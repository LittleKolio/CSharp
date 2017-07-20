using System;

public static class Constants
{
    public const string INPUT_TERMINAOR = "Shutdown";

    public const string EXEPTION_HARVESTER_ORE = "Harvester is not registered, because of it's {0}";
    public const string EXEPTION_HARVESTER_ENERGY = "Harvester is not registered, because of it's {0}";
    public const string EXEPTION_PROVIDER_ENERGY = "Provider is not registered, because of it's {0}";
    public const string EXEPTION_CHECK = "No element found with id - {0}";

    public static string TOSTRING_HARVESTER = 
        "{0} Harvester - {1}" + Environment.NewLine +
        "Ore Output: {2}" + Environment.NewLine +
        "Energy Requirement: {3}";

    public const string TOSTRING_PROVIDER = "{0} Provider - {1}\r\nEnergy Output: {2}";
    public const string TOSTRING_DAY = "A day has passed.\r\nEnergy Provided: {0}\r\nPlumbus Ore Mined: {1}";
    public const string TOSTRING_SHUTHDOWN = "System Shutdown\r\nTotal Energy Stored: {0}\r\nTotal Mined Plumbus Ore: {1}";

    public const string SUCCESS_CHANGE_MODE = "Successfully changed working mode to {0} Mode";
    public const string SUCCESS_REGISTER_HARVESTER = "Successfully registered {0} Harvester - {1}";
    public const string SUCCESS_REGISTER_PROVIDER = "Successfully registered {0} Provider - {1}";

    public const int MAXIMUM_PERCENTAGE = 100;

    public const int MODIFIER_HAMMERHARVESTER_ORE = 200;
    public const int MODIFIER_HAMMERHARVESTER_ENERGY = 100;
    public const int MODIFIER_PRESSUREPROVIDER_ENERGY = 50;

    public const int MODIFIER_HALFMODE_ENERGY = 60;
    public const int MODIFIER_HALFMODE_ORE = 50;

    public const int MODIFIER_ENERGYMODE_ENERGY = 0;
    public const int MODIFIER_ENERGYMODE_ORE = 0;

    public const int MIN_HARVESTER_ENERGY = 0;
    public const int MAX_HARVESTER_ENERGY = 20000;

    public const int MIN_PROVIDER_ENERGY = 0;
    public const int MAX_PROVIDER_ENERGY = 10000;
}
