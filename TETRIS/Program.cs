using System;
using System.Threading;

namespace TETRIS
{
    class Program
    {
        //Settings
        static int TetrisRows = 20;
        static int TetrisCols = 10;
        static int InfoCols = 10;
        static int ConsoleRows = 1 + TetrisRows + 1;
        static int ConsoleCols = 1 + TetrisCols + 1 + InfoCols + 1;
        //State
        static int Score = 0;

        static void Main(string[] args)
        {

            Console.Title = "Tetris v1.0";

            Console.WindowHeight = ConsoleRows + 1;
            Console.WindowWidth = ConsoleCols;
            Console.BufferHeight = ConsoleRows + 1;
            Console.BufferWidth = ConsoleCols;
            Console.CursorVisible = false;


            while (true)
            {
                while (true)
                {
                    Score++;

                    // User input
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo key = Console.ReadKey();
                        if (key.Key == ConsoleKey.Escape)
                        {
                            //Environment.Exit(0);
                            return;
                        }
                    }



                    // change state (by user , other user or the game engine itself)

                    // Redraw UI
                    DrawBorder();
                    DrawInfo();

                    Thread.Sleep(40);  // - milisecundi
                }
            }
        }

        static void DrawInfo()
        {
            Write("Score:", 4 + TetrisCols, 1);
            Write(Score.ToString(), 4 + TetrisCols, 2);
        }

        static void DrawBorder()
        {
            Console.SetCursorPosition(0, 0);

            string line = "╔";
            line += new string('═', TetrisCols);
            line += "╦";
            line += new string('═', InfoCols);
            line += "╗";
            //for (int i = 0; i < TetrisCols; i++)
            //{
            //    line += "═";
            //}
            //line += "╦";
            //for (int i = 0; i < InfoCols; i++)
            //{
            //    line += "═";
            //}
            //line += "╗";
            Console.WriteLine(line);

            for (int i = 0; i < TetrisRows; i++)
            {
                string midLine = "║";
                midLine += new string(' ', TetrisCols);
                midLine += "║";
                midLine += new string(' ', TetrisCols);
                midLine += "║";
                Console.Write(midLine);
            }

            string endLine = "╚";
            endLine += new string('═', TetrisCols);
            endLine += "╩";
            endLine += new string('═', InfoCols);
            endLine += "╝";
            Console.WriteLine(endLine);
        }

        static void Write(string text, int row, int col, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(row, col);
            Console.Write(text);
            Console.ResetColor();
        }

    }
}
