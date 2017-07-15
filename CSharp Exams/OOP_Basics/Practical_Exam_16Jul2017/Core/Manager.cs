using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Manager
{
    private Dictionary<int, string> some;

    public Manager()
    {
        this.some = new Dictionary<int, string>();
    }

    public void Something(string type)
    {
        switch (type)
        {
            case "xx":
                break;
            case "xxx":
                break;
        }
    }
    public string WriteSomething()
    {
        return null;
    }
}
