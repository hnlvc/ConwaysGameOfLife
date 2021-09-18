using System;

namespace ConwaysGameOfLife
{
    internal record Field
    {
        public Cell[,] CurrentGenField { get; private set; }
        private int fieldLength;
        private int fieldHeight;

        public Field(Cell[,] currentGenField)
        {
            fieldLength = currentGenField.GetLength(0);
            fieldHeight = currentGenField.GetLength(1);

            CurrentGenField = currentGenField;
        }

        public void CalculateNextGen()
        {
            var nextGenField = GetInitializedField(fieldLength, fieldHeight);
            for (var positionLength = 0; positionLength < fieldLength; ++positionLength)
            {
                for (var positionHeight = 0; positionHeight < fieldHeight; ++positionHeight)
                {
                    var alive = CountLivingNeighbors(positionLength, positionHeight);
                    
                    if (CurrentGenField[positionLength, positionHeight].IsAlive)
                    {
                        if (alive == 2 || alive == 3)
                        {
                            nextGenField[positionLength, positionHeight].IsAlive = true;
                        }
                    }

                    if (CurrentGenField[positionLength, positionHeight].IsAlive == false)
                    {
                        if (alive == 3)
                        {
                            nextGenField[positionLength, positionHeight].IsAlive = true;
                        }
                    }
                }
            }
            this.CurrentGenField = nextGenField;
        }

        public int CountLivingNeighbors(int positionLength, int positionHeight)
        {
            var counter = 0;
            var neighbors = new (int positionLength, int positionHeight)[8] {
                (positionLength - 1, positionHeight - 1), (positionLength, positionHeight - 1), (positionLength + 1, positionHeight -1),
                (positionLength - 1, positionHeight), /*                     me             */ (positionLength + 1, positionHeight),
                (positionLength - 1, positionHeight + 1), (positionLength, positionHeight + 1), (positionLength + 1, positionHeight + 1)
            };

            foreach (var element in neighbors)
            {
                if(IsInField(element.positionLength, element.positionHeight))
                {
                    if (CurrentGenField[element.positionLength, element.positionHeight].IsAlive) counter++;
                }
            }

            return counter;
        }

        public bool IsInField(int length, int height)
        {
            if (!(length >= 0 && length < fieldLength)) return false;
            if (!(height >= 0 && height < fieldHeight)) return false;

            return true;
        }

        public void Print()
        {
            string line;

            for (var height = 0; height < fieldHeight; ++height)
            {
                line = "";
                for (var length = 0; length < fieldLength; ++length)
                {
                    line = string.Concat(line, CurrentGenField[length, height].IsAlive ? '#' : '-');
                }
                Console.WriteLine(line);
            }
        }

        public static Cell[,] GetInitializedField(int length, int height)
        {
            var field = new Cell[length, height];

            for (var i = 0; i < length; ++i)
            {
                for (var j = 0; j < height; ++j)
                {
                    field[i, j] = new Cell(false);
                }
            }

            return field;
        }
    }
}
