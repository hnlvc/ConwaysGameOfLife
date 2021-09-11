using System;

namespace ConwaysGameOfLife
{
    class Field
    {
        public Cell[,] CurrentGenField { get => currentGenField; }
        private Cell[,] currentGenField;
        private Cell[,] nextGenField;
        private int length;
        private int height;

        public Field(Cell[,] currentGenField)
        {
            this.length = currentGenField.GetLength(0);
            this.height = currentGenField.GetLength(1);
           
            this.currentGenField = currentGenField;
            nextGenField = new Cell[length, height];
        }

        public void CalculateNextGen()
        {
            nextGenField = GetInitializedField(length, height);
            for (var length = 0; length < this.length; ++length)
            {
                for (var height = 0; height < this.height; ++height)
                {
                    var alive = CountLivingNeighbors(length, height);
                    if (CurrentGenField[length, height].IsAlive)
                    {
                        if ((alive == 2 || alive == 3))
                        {
                            nextGenField[length, height].IsAlive = true;
                        }
                    }

                    if (CurrentGenField[length, height].IsAlive == false)
                    {
                        if (alive == 3)
                        {
                            nextGenField[length, height].IsAlive = true;
                        }
                    }
                }
            }
            this.currentGenField = nextGenField;
        }

        public int CountLivingNeighbors(int posLength, int posHeight)
        {
            var counter = 0;

            if (IsInField(posLength - 1, posHeight - 1))
            {
                if (currentGenField[posLength - 1, posHeight - 1].IsAlive) counter++;
            }
            if (IsInField(posLength, posHeight - 1))
            {
                if (currentGenField[posLength, posHeight - 1].IsAlive) counter++;
            }
            if (IsInField(posLength + 1, posHeight - 1))
            {
                if (currentGenField[posLength + 1, posHeight - 1].IsAlive) counter++;
            }
            if (IsInField(posLength + 1, posHeight))
            {
                if (currentGenField[posLength + 1, posHeight].IsAlive) counter++;
            }
            if (IsInField(posLength + 1, posHeight + 1))
            {
                if (currentGenField[posLength + 1, posHeight + 1].IsAlive) counter++;
            }
            if (IsInField(posLength, posHeight + 1))
            {
                if (currentGenField[posLength, posHeight + 1].IsAlive) counter++;
            }
            if (IsInField(posLength - 1, posHeight + 1))
            {
                if (currentGenField[posLength - 1, posHeight + 1].IsAlive) counter++;
            }
            if (IsInField(posLength - 1, posHeight))
            {
                if (currentGenField[posLength - 1, posHeight].IsAlive) counter++;
            }

            return counter;
        }

        public bool IsInField(int length, int height)
        {
            if (!(length >= 0 && length < this.length)) return false;
            if (!(height >= 0 && height < this.height)) return false;

            return true;
        }

        public void Print()
        {
            string line;

            for (var height = 0; height < this.height; ++height)
            {
                line = "";
                for (var length = 0; length < this.length; ++length)
                {
                    line = string.Concat(line, currentGenField[length, height].IsAlive ? '#' : '-');
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
