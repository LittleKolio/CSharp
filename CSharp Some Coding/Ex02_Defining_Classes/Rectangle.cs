using System;

public class Rectangle
{
    public string Id { get; set; }
    public long Width { get; set; }
    public long Height { get; set; }
    public long TopLeftX { get; set; }
    public long TopLeftY { get; set; }

    public Rectangle(string id, long width, long height, long topLeftX, long topLeftY)
    {
        this.Id = id;
        this.Width = width;
        this.Height = height;
        this.TopLeftX = topLeftX;
        this.TopLeftY = topLeftY;
    }

    public bool Intersect(Rectangle other)
    {
        bool xIn = true;
        if (this.TopLeftX != other.TopLeftX)
        {
            xIn = this.TopLeftX > other.TopLeftX
            ? other.TopLeftX + other.Width >= this.TopLeftX
            : this.TopLeftX + this.Width >= other.TopLeftX;
        }

        bool yIn = true;
        if (this.TopLeftY != other.TopLeftY)
        {
            yIn = this.TopLeftY >= other.TopLeftY
            ? this.TopLeftY - this.Height <= other.TopLeftY
            : other.TopLeftY - other.Height <= this.TopLeftY;
        }

        return xIn && yIn;
    }
}