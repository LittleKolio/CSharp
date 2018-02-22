﻿namespace Encapsulation_Exercises.Classes
{
    using System;

    public class Box
    {
        private double length;
        private double width;
        private double height;

        public double Length
        {
            get { return this.length; }
            private set
            {
                if (value <= 0)
                {
                    throw new Exception(
                        "Length cannot be zero or negative.");
                }
                this.length = value;
            }
        }
        public double Width
        {
            get { return this.width; }
            private set
            {
                if (value <= 0)
                {
                    throw new Exception(
                        "Width cannot be zero or negative.");
                }
                this.width = value;
            }
        }
        public double Height
        {
            get { return this.height; }
            private set
            {
                if (value <= 0)
                {
                    throw new Exception(
                        "Height cannot be zero or negative.");
                }
                this.height = value;
            }
        }

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double SurfaceArea()
        {
            return 2 * this.Length * this.Width +
                2 * this.Length * this.Height +
                2 * this.Width * this.Height;
        }

        public double LateralSurfaceArea()
        {
            return 2 * this.Width * this.Height +
               2 * this.Length * this.Height;
        }

        public double Volume()
        {
            return this.Length * this.Width * this.Height;
        }
    }
}
