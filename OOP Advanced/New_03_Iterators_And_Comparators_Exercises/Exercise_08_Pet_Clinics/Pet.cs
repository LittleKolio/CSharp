namespace Exercise_08_Pet_Clinics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Pet : IComparable<Pet>
    {
        public Pet(string name, int age, string kind)
        {
            this.Name = name;
            this.Age = age;
            this.Kind = kind;
        }

        public string Name { get; }
        public int Age { get; }
        public string Kind { get; }

        public int CompareTo(Pet other)
        {
            int result = this.Name.CompareTo(other.Name);
            if (result == 0)
            {
                result = this.Age.CompareTo(other.Age);
            }

            return result;
        }

        //public override bool Equals(object obj)
        //{
        //    if (obj is Person other)
        //    {
        //        return this.Name == other.Name &&
        //            this.Age == other.Age;
        //    }
        //    else
        //    {
        //        throw new ArgumentException(
        //            "Object is not person!");
        //    }
        //}

        //public override int GetHashCode()
        //{
        //    return this.Name.GetHashCode() + this.Age.GetHashCode();
        //}

        public override string ToString()
        {
            return $"{this.Name} {this.Age} {this.Kind}";
        }
    }
}
