namespace SOLID_Lab.Lab_02
{
    public class Program
    {
        public static void Main()
        {
            IShape shape = new Circle();
            GraphicEditor editor = new GraphicEditor();
            editor.DrawShape(shape);
        }
    }
}
