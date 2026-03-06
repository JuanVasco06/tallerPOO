namespace Exercise28
{
    public class BeamBase
    {
        public char Symbol { get; private set; }
        public int Resistance { get; private set; }

        public BeamBase(char symbol)
        {
            Symbol = symbol;
            Resistance = GetResistance(symbol);
        }

        public static bool IsValidBase(char symbol)
        {
            return symbol == '%' || symbol == '&' || symbol == '#';
        }

        public static int GetResistance(char symbol)
        {
            switch (symbol)
            {
                case '%':
                    return 10;
                case '&':
                    return 30;
                case '#':
                    return 90;
                default:
                    return 0;
            }
        }
    }
}
