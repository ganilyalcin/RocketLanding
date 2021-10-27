namespace RocketLanding.Data.Model
{
    public class Target
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Target(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}