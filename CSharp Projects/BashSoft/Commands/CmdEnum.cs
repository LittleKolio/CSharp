using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft.Commands
{
    public enum CmdEnum
    {
        /// <summary>
        /// Just for testing.
        /// </summary>
        test,

        /// <summary>
        /// Create directory in the current directory by given name.
        /// </summary>
        mkdir,

        /// <summary>
        /// display the files and subfolders in 
        /// the current directory by given depth.
        /// </summary>
        ls,

        /// <summary>
        /// Comparing two files by given two absolute paths.
        /// </summary>
        cmp,

        /// <summary>
        /// Change the current directory by given relative path.
        /// </summary>
        chdirrel,

        /// <summary>
        /// Change the current directory by given absolute path.
        /// </summary>
        chdirabs,

        /// <summary>
        /// Read students database by given name of 
        /// file witch in the current directory.
        /// </summary>
        rdb,

        /// <summary>
        /// Filter students from given cours by a given option and 
        /// then take quantity of filtered students.
        /// </summary>
        fr,

        /// <summary>
        /// Order students from given course by ascending or 
        /// descending order and 
        /// then take quantity of filtered students.
        /// </summary>
        or,

        /// <summary>
        /// Download file
        /// </summary>
        dd,

        /// <summary>
        /// Downloads file asynchronous
        /// </summary>
        dda,

        /// <summary>
        /// Get help
        /// </summary>
        h,

        /// <summary>
        /// Open file
        /// </summary>
        op
    }
}
