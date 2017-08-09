namespace SOLID_Lab.Lab_01
{
    public class StreamProgressInfo
    {
        private IStreamFile file;

        public StreamProgressInfo(IStreamFile file)
        {
            this.file = file;
        }

        public int CalculateCurrentPercent()
        {
            return (this.file.BytesSent * 100) / this.file.Length;
        }
    }
}