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
            Cell[,] field = Field.GetInitializedField(fieldSizeX, fieldSizeY);

            //Initialize first gen with a rider in upper left corner

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
                Thread.Sleep(100);
            }

        }
    }
}
