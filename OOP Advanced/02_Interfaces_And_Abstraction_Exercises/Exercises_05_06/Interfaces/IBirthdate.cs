using System;

public interface IBirthdate
{
    DateTime Birthdate { get; }
    bool CheckBirthday(int year);
}
