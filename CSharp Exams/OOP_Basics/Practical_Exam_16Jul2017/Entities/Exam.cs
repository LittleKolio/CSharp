using System.Collections.Generic;

public class Exam
{
    private List<int> list;

    public int MyProperty { get; private set; }

    public IList<int> List
    {
        get { return this.list.AsReadOnly(); }
    }
}
