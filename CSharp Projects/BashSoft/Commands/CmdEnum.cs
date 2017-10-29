using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft.Commands
{
    public enum CmdEnum
    {
        //Just for testing.
        test,

        //Create directory in the current directory by given name.
        mkdir,

        //Traverse current directory to the given depth
        ls,

        //Comparing two files by given two absolute paths
        cmp,

        //Change the current directory by given relative path
        chdirrel,

        //Change the current directory by given absolute path
        chdirabs,

        //Read students database by given name of file witch in the current directory.
        rdb,

        //Filter students from given cours by a given option and then take quantity of filtered students.
        fr,

        //Order students from given course by ascending or descending order and then ake quantity of filtered students.
        or,

        //Download file
        dd,

        //Downloads file asynchronous
        dda,

        //Get help
        h,

        //Open file
        op
    }
}
