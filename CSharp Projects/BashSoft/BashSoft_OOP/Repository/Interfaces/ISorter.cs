namespace BashSoft_OOP.Repository.Interfaces
{
    using Models.Interfaces;
    using System.Collections.Generic;

    public interface ISorter
    {
        IList<IStudent> SortInterpreter(ICourse course, string order, int take);
    }
}