namespace RocketLanding.Data.Model
{
    public class Platform
    {
        public int XLength { get; set; }
        public int YLength { get; set; }
        public Position Position { get; set; }

        public int X0 { get; set; }
        public int X1 { get; set; }
        public int Y0 { get; set; }
        public int Y1 { get; set; }

        public Platform(int xlenght, int ylenght, Position position)
        {
            XLength = xlenght;
            YLength = ylenght;
            Position = position;

            X0 = Position.X;
            X1 = Position.X + XLength;
            Y0 = Position.Y;
            Y1 = Position.Y + YLength;
        }
    }
}