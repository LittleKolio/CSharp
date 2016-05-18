using System;

namespace Labyrinth
{
	class MainClass
	{
//		static char[,] lab = {
//			{' ', ' ', ' ', '*', ' ', ' ', ' '},
//			{'*', '*', ' ', '*', ' ', '*', ' '},
//			{' ', ' ', ' ', ' ', ' ', ' ', ' '},
//			{' ', '*', '*', '*', '*', '*', ' '},
//			{' ', ' ', ' ', ' ', ' ', ' ', 'е'}
//		};
		static char[,] lab = {
			{' ','*',' ',' ',' ',' ','*',' ',' ',' ',' ','*','*',' ',' '},
			{' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},
			{' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},
			{' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' '},
			{' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' ',' '},
			{' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' ',' '},
			{' ','*','*','*',' ','*',' ',' ',' ',' ',' ','*','*','*','*'},
			{' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' ',' '},
			{' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' ','е'}
		};
		static char[] path = new char [ lab.GetLength(0) * lab.GetLength(1) ];
		static int position = 0;

		static void FindPath (int row, int col, char direction)
		{
			if ((col < 0) || (row < 0) || (col >= lab.GetLength (1)) || (row >= lab.GetLength (0))) {
				return;
			}

			path [position] = direction;
			position++;

			if (lab [row, col] == 'е') {
				PrintPath (path, 1, position - 1);
			}
			if (lab [row, col] == ' ') {
				lab [row, col] = 's';
				FindPath (row, col - 1, 'L'); // left
				FindPath (row - 1, col, 'U'); // up
				FindPath (row, col + 1, 'R'); // right
				FindPath (row + 1, col, 'D'); // down
//				lab [row, col] = ' ';
			}
			position--;
		}
		static void PrintPath(char[] path, int startPos, int endPos)
		{
			Console.Write("Found path to the exit: ");
			for (int pos = startPos; pos <= endPos; pos++) {
				Console.Write(path[pos]);
			}
			Console.WriteLine();
		}
		static void Main()
		{
			FindPath (0, 0, 'S');
		}
	}
}
