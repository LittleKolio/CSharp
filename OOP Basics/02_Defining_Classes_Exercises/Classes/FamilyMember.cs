namespace Defining_Classes_Exercises.Classes
{
    using System;
    using System.Collections.Generic;

    public class FamilyMember
    {
        public string Name { get; set; }
        public string Birthday { get; set; }

        public List<FamilyMember> Parents { get; set; }
        public List<FamilyMember> Children { get; set; }

        public FamilyMember()
        {
            this.Parents = new List<FamilyMember>();
            this.Children = new List<FamilyMember>();
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Birthday}";
        }
    }
}
