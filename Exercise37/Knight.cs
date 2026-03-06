using System;

namespace Exercise37
{
    public class Knight
    {
        public Position Position { get; private set; }

        public Knight(Position position)
        {
            Position = position;
        }

        public bool IsInConflictWith(Knight otherKnight)
        {
            int columnDifference = Math.Abs(Position.Column - otherKnight.Position.Column);
            int rowDifference = Math.Abs(Position.Row - otherKnight.Position.Row);

            return (columnDifference == 1 && rowDifference == 2) ||
                   (columnDifference == 2 && rowDifference == 1);
        }

        public override string ToString()
        {
            return Position.ToString();
        }
    }
}