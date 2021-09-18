using System;
using System.Threading;

namespace ConwaysGameOfLife
{
    internal class Program
    {
        
        static int fieldSizeX = 60;
        static int fieldSizeY = 60;
        
        static void Main(string[] args)
        {
            Cell[,] initialGameField = Field.GetInitializedField(fieldSizeX, fieldSizeY);

            //Initialize first gen with a rider in upper left corner

            initialGameField[1, 0] = new Cell(true);
            initialGameField[2, 1] = new Cell(true);
            initialGameField[0, 2] = new Cell(true);
            initialGameField[1, 2] = new Cell(true);
            initialGameField[2, 2] = new Cell(true);

            var field = new Field(initialGameField);

            while (true)
            {
                Console.Clear();
                field.CalculateNextGen();
                field.Print();
                Thread.Sleep(100);
            }

        }
    }
}
