using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class StartUp
{
    static void Main(string[] args)
    {
        Dictionary<int, Soldier> soldiers = new Dictionary<int, Soldier>();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] tokens = InputParser(input);
            string type = tokens[0];

            #region Reflection
            /*
            tokens = tokens.Skip(1).ToArray();

            Type soldierType = Type.GetType(type);

            ParameterInfo[] soldierPars = soldierType
                .GetConstructors()
                .FirstOrDefault()
                .GetParameters();

            object[] currentPars = new object[soldierPars.Length];

            for (int i = 0; i < soldierPars.Length; i++)
            {
                Type parType = soldierPars[i].ParameterType;
                currentPars[i] = Convert.ChangeType(tokens[i], parType);
            }

            Soldier soldier = (Soldier)Activator.CreateInstance(soldierType, currentPars);
            */
            #endregion
            try
            {
                int id = int.Parse(tokens[1]);
                string firstName = tokens[2];
                string lastName = tokens[3];
                double salary = double.Parse(tokens[4]);

                switch (type)
                {
                    case "LeutenantGeneral":
                        {
                            LeutenantGeneral soldier = new LeutenantGeneral(id, firstName, lastName, salary);
                            if (tokens.Length > 5)
                            {
                                for (int i = 5; i < tokens.Length; i++)
                                {
                                    try
                                    {
                                        int idPrivate = int.Parse(tokens[i]);
                                        soldier.Privates.Add(soldiers[idPrivate]);
                                    }
                                    catch
                                    {
                                        continue;
                                    }
                                }
                            }
                            soldiers.Add(id, soldier);
                        }
                        break;
                    case "Engineer":
                        {
                            string corp = tokens[5];
                            Engineer soldier = new Engineer(id, firstName, lastName, salary, corp);

                            if (tokens.Length > 6)
                            {
                                for (int i = 6; i < tokens.Length - 1; i += 2)
                                {
                                    try
                                    {
                                        string part = tokens[i];
                                        int time = int.Parse(tokens[i + 1]);
                                        Repair repair = new Repair(part, time);
                                        soldier.Repairs.Add(repair);
                                    }
                                    catch
                                    {
                                        continue;
                                    }
                                }
                            }
                            soldiers.Add(id, soldier);
                        }
                        break;
                    case "Commando":
                        {
                            string corp = tokens[5];
                            Commando soldier = new Commando(id, firstName, lastName, salary, corp);

                            if (tokens.Length > 6)
                            {
                                for (int i = 6; i < tokens.Length - 1; i += 2)
                                {
                                    try
                                    {
                                        string name = tokens[i];
                                        string state = tokens[i + 1];
                                        Mission mission = new Mission(name, state);
                                        soldier.Missions.Add(mission);
                                    }
                                    catch
                                    {
                                        continue;
                                    }
                                }
                            }
                            soldiers.Add(id, soldier);
                        }
                        break;
                    case "Private":
                        {
                            Private soldier = new Private(id, firstName, lastName, salary);
                            soldiers.Add(id, soldier);
                        }
                        break;
                    case "Spy":
                        {
                            int codeNumber = int.Parse(tokens[5]);
                            Spy soldier = new Spy(id, firstName, lastName, salary, codeNumber);
                            soldiers.Add(id, soldier);
                        }
                        break;

                    default: continue;
                }
            }
            catch
            {
                continue;
            }
        }

        foreach (KeyValuePair<int, Soldier> soldier in soldiers)
        {
            Console.WriteLine(soldier.Value);
        }
    }

    private static string[] InputParser(string input)
    {
        return input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
    }
}