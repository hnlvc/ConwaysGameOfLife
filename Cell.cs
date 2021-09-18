namespace ConwaysGameOfLife
{
    public sealed class Cell
    {
        public bool IsAlive { get; set; }

        public Cell(bool isAlive)
        {
            IsAlive = isAlive;
        }
    }
}
