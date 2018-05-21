namespace BashSoft_OOP.StaticData
{
    using System.Collections.Generic;

    public static class HelpInfo
    {
        public readonly static List<List<string>> Commands =
        new List<List<string>>{
            new List<string>{
                "changedirectory",
                "{0_(string)relativeDirectoryPath}",
                "Enter relative path."
            },
            new List<string>{
                "comparetwofiles",
                "{0_(string)file1Name} {1_(string)file2Name}",
                "Compares two files line by line. Result is new file Mismatches.txt in the current directory."
            },
            new List<string>{
                "createdirectory",
                "{0_(string)directoryName}",
                "Create directory in the current."
            },
            new List<string>{
                "filter",
                "{0_(string)courseName} {1_(string)poor/average/excellent} {2_(int)number/(string)all}",
                "Returns list of students who average score is:",
                "- poor when score is below 3.5.",
                "- average when score is between 3.5 and 5.",
                "- excellent  when score is above 5."
            },
            new List<string>{
                "openfile",
                "{0_(string)fileName}",
                "Opens a file from current directory with default program for windows."
            },
            new List<string>{
                "order",
                "{0_(string)courseName} {1_(string)ascending/descending} {2_(int)number/(string)all}",
                "Returns list of students from given course sorted in ascending or descending order."
            },
            new List<string>{
                "print",
                "",
                "Prints all courses who are in database."
            },
            new List<string>{
                "readjson",
                "{0_(string)courses/students} {1_(string)fileName}",
                "Initialize (fill) of the database through JSON file in current directory."
            },
            new List<string>{
                "readtxt",
                "{0_(string)fileName}",
                "Initialize (fill) of the database through text file in current directory."
            },
            new List<string>{
                "removecourse",
                "{0_(string)courseName}",
                "Remove course from database."
            },
            new List<string>{
                "removestudent",
                "{0_(string)courseName} {1_(string)studentName}",
                "Remove student from a given course."
            },
            new List<string>{
                "traversedirectory",
                "{0_(int)depth}",
                "Traversing current directory with breadth-first search by given depth."
            }
        };
    }
}
