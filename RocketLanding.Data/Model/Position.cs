namespace RocketLanding.Data.Model
{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position(int x = 5, int y = 5)
        {
            this.X = x;
            this.Y = y;
        }
    }
}