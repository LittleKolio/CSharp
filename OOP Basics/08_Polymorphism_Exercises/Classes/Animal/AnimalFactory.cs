namespace Polymorphism_Exercises.Classes
{
    public abstract class AnimalFactory
    {
        public static Animal GetAnimal(string[] animalInput)
        {
            switch (animalInput[0])
            {
                case "Mouse":
                    return new Mouse(
                        animalInput[1], double.Parse(animalInput[2]), animalInput[3]);
                case "Cat":
                    return new Cat(
                        animalInput[1], double.Parse(animalInput[2]), animalInput[3], animalInput[4]);
                case "Tiger":
                    return new Tiger(
                        animalInput[1], double.Parse(animalInput[2]), animalInput[3]);
                case "Zebra":
                    return new Zebra(
                        animalInput[1], double.Parse(animalInput[2]), animalInput[3]);
                default: return null;
            }
        }
    }
}
