namespace BashSoft_OOP.Repository.Interfaces
{
    using Models.Interfaces;
    using System.Collections.Generic;

    public interface IFilter
    {
        IList<IStudent> FilterInterpreter(ICourse course, string filter, int take);
    }
}