using System;
using System.Collections.Generic;
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
        static List<bool[,]> TetrisFigures = new List<bool[,]>()
        {
            new bool[,]   // I (----)
            {
               {true,true,true,true }
            },
            new bool[,]   // O
            {
                {true,true },
                {true,true }
            },
            new bool[,]   // T
            {
                {false,true,false },
                {true,true,true }
            },
            new bool[,]    // S
            {
                {false,true,true},
                {true,true,false }
            },
            new bool[,]   // Z
            {
                {true,true,false },
                {false,true,true }
            },
            new bool[,]   // J
            {
                {true,false,false },
                {true,true,true }
                },
            new bool[,]   // L
            {
                {false,false,true },
                {true,true,true }
            }
        };

        //State
        static int Score = 0;
        static int Frame = 0;
        static int FramesToMoveFigure = 15;
        static int CurrentFigureIndex = 2;
        static int CurrentFigureRow = 0;
        static int CurrentFigureCol = 0;
        static bool[,] TetrisField = new bool[TetrisRows, TetrisCols];

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
                Frame++;
                //Read user input
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();

                    if (key.Key == ConsoleKey.Escape)
                    {
                        //Environment.Exit(0);
                        return; // Becase of Main()
                    }
                    if (key.Key == ConsoleKey.Spacebar || key.Key == ConsoleKey.UpArrow || key.Key == ConsoleKey.W)
                    {
                        //TODO Implement 90 degree rotation
                    }
                    if (key.Key == ConsoleKey.DownArrow || key.Key == ConsoleKey.S)
                    {
                        Frame = 1;
                        Score++;
                        //TODO: Move current figure down
                        CurrentFigureRow++;
                    }
                    if (key.Key == ConsoleKey.LeftArrow || key.Key == ConsoleKey.A)
                    {
                        //TODO: Move current figure left
                        CurrentFigureCol--; //TODO: Out of range
                    }
                    if (key.Key == ConsoleKey.RightArrow || key.Key == ConsoleKey.D)
                    {
                        //TODO: Move current figure right
                        CurrentFigureCol++; //TODO: Out of range
                    }
                }

                // Update game state
                if (Frame % FramesToMoveFigure == 0)
                {
                    //TODO: Move current figure
                    CurrentFigureRow++;
                    Frame = 0;
                    Score++;
                }

                // if (Collision())
                // {
                //AddCurrentFigureToTetrisField();
                //CheckForFullLines();
                // if(lines remove) Score++;
                // }

                // Redraw UI
                DrawBorder();
                DrawInfo();
                //TODO: DrawTetrisField()
                DrawCurrentFigure();


                Thread.Sleep(40);  // - milisecundi
            }

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

        static void DrawInfo()
        {
            Write("Score:", 4 + TetrisCols, 1);
            Write(Score.ToString(), 4 + TetrisCols, 2);
            Write("Frame:", 4 + TetrisCols, 4);
            Write(Frame.ToString(), 4 + TetrisCols, 5);
        }

        static void DrawCurrentFigure()
        {
            var currentFigure = TetrisFigures[CurrentFigureIndex];
            for (int row = 0; row < currentFigure.GetLength(0); row++)
            {
                for (int col = 0; col < currentFigure.GetLength(1); col++)
                {
                    if (currentFigure[row, col])
                    {
                        Write("*", row + 1 + CurrentFigureCol, col + 1 + CurrentFigureRow);
                    }
                }
            }
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
