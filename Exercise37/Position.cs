namespace Exercise37
{
    public class Position
    {
        public char Column { get; private set; }
        public int Row { get; private set; }

        public Position(char column, int row)
        {
            Column = char.ToUpper(column);
            Row = row;
        }

        public static bool IsValid(string text)
        {
            if (string.IsNullOrWhiteSpace(text) || text.Length < 2 || text.Length > 3)
            {
                return false;
            }

            char column = char.ToUpper(text[0]);

            if (column < 'A' || column > 'H')
            {
                return false;
            }

            string rowText = text.Substring(1);

            if (!int.TryParse(rowText, out int row))
            {
                return false;
            }

            return row >= 1 && row <= 8;
        }

        public static Position FromString(string text)
        {
            char column = char.ToUpper(text[0]);
            int row = int.Parse(text.Substring(1));

            return new Position(column, row);
        }

        public override string ToString()
        {
            return $"{Column}{Row}";
        }
    }
}