namespace Encapsulation_Exercises.Classes
{
    using System;

    class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        private double Length
        {
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "Length cannot be zero or negative.");
                }
                this.length = value;
            }
        }

        private double Width
        {
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "Width cannot be zero or negative.");
                }
                this.width = value;
            }
        }

        private double Height
        {
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "Height cannot be zero or negative.");
                }
                this.height = value;
            }
        }

        public double SurfaceArea()
        {
            return 2 * this.length * this.width +
                2 * this.width * this.height +
                2 * this.height * this.length;
        }

        public double LateralSurfaceArea()
        {
            return 2 * this.width * this.height +
                2 * this.height * this.length;
        }

        public double Volume()
        {
            return this.length * this.width * this.height;
        }
    }
}
