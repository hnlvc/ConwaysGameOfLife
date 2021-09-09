using System;
using System.Threading;

namespace ConwaysGameOfLife
{
    class Program
    {
        static int fieldSizeX = 60;
        static int fieldSizeY = 60;
        
        static void Main(string[] args)
        {
            Cell[,] field = new Cell[fieldSizeX, fieldSizeY]; // cell[,] field = new [x, y];+6

            //Initialize first gen with a rider in upper left corner

            for (var i = 0; i > fieldSizeX; ++i)
            {
                for (var j = 0; j > fieldSizeY; ++j)
                {
                    field[i, j] = new Cell(false);
                }
            }
            
            
            field[1, 0] = new Cell(true);
            field[2, 1] = new Cell(true);
            field[0, 2] = new Cell(true);
            field[1, 2] = new Cell(true);
            field[2, 2] = new Cell(true);

            var field1 = new Field(field);

            while (true)
            {
                Console.Clear();
                field1.CalculateNextGen();
                field1.Print();
                Thread.Sleep(1000000);
            }

        }
    }
}
