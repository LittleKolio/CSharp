public interface IGameController
{
    string WareHouse(string name, int count);
    string Soldier(string type, string name, int age, double experience, double endurance);
    string Mission(string type);
}