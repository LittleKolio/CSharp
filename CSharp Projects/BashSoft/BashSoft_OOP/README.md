# BashSoft_OOP

It is console application. A student data repository for their courses and results.
The first row is the current directory we work with. This is the location of the executable file.

## Steps

Fill in the database. We will do this by reading a text file.

1. Set the directory where the file is with command:  
	**changedirectory {0_(string)relativeDirectoryPath}**

2. Read file.
- If the file is in JSON format use command:  
	**readjson {0_(string)courses/students} {1_(string)fileName}**
	
- If the file is in custom format use command:  
	**readtxt {0_(string)fileName}**

## Commands

**changedirectory {0_(string)relativeDirectoryPath}**  
Enter relative path.

**comparetwofiles {0_(string)file1Name} {1_(string)file2Name}**  
Compares two files line by line. Result is new file Mismatches.txt in the current directory.

**createdirectory {0_(string)directoryName}**  
Create directory in the current.

**filter {0_(string)courseName} {1_(string)poor/average/excellent} {2_(int)number/(string)all}**  
Returns list of students who average score is:
- poor when score is below 3.5.
- average when score is between 3.5 and 5.
- excellent  when score is above 5.

**openfile {0_(string)fileName}**  
Opens a file from current directory with default program for windows.

**order {0_(string)courseName} {1_(string)ascending/descending} {2_(int)number/(string)all}**  
Returns list of students from given course sorted in ascending or descending order.

**print**  
Prints all courses who are in database.

**readjson {0_(string)courses/students} {1_(string)fileName}**  
Initialize (fill) of the database through JSON file in current directory.

**readtxt {0_(string)fileName}**  
Initialize (fill) of the database through text file in current directory.

**removecourse {0_(string)courseName}**  
Remove course from database.

**removestudent {0_(string)courseName} {1_(string)studentName}**  
Remove student from a given course.

**traversedirectory {0_(int)depth}**  
Traversing current directory with breadth-first search by given depth.
