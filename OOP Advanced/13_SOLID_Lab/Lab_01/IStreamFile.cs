using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Lab.Lab_01
{
    public interface IStreamFile
    {
        int Length { get; }
        int BytesSent { get; }
    }
}
