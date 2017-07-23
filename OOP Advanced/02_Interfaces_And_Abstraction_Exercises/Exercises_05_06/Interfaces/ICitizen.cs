public interface ICitizen : ISociety, IBirthdate
{
    string Name { get; }
    int Age { get; }
}
