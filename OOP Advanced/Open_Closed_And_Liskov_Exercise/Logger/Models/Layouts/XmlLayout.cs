namespace Logger
{
    using System.Xml.Linq;

    public class XmlLayout : ILayout
    {
        public string CreateLogMessage(IError args)
        {
            XElement xml = new XElement("log",
                new XElement("date", args.DateTime),
                new XElement("level", args.Level),
                new XElement("message", args.Message)
                );

            return xml.ToString();
        }
    }
}
