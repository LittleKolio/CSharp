
namespace BashSoft_OOP.Interface
{
    using System.Collections.Generic;

    public interface ISorter
    {
        IList<IStudent> SortInterpreter(ICourse course, string order, int take);
    }
}