namespace Exercise28
{
    public class Beam
    {
        private string representation;
        private BeamBase beamBase;

        public Beam(string representation)
        {
            this.representation = representation;

            if (!string.IsNullOrEmpty(representation))
            {
                beamBase = new BeamBase(representation[0]);
            }
        }

        public bool HasValidBase()
        {
            return !string.IsNullOrEmpty(representation) &&
                   BeamBase.IsValidBase(representation[0]);
        }

        public bool HasValidCharacters()
        {
            if (string.IsNullOrEmpty(representation))
            {
                return false;
            }

            for (int i = 1; i < representation.Length; i++)
            {
                if (representation[i] != '=' && representation[i] != '*')
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsWellBuilt()
        {
            if (!HasValidBase())
            {
                return false;
            }

            if (!HasValidCharacters())
            {
                return false;
            }

            if (representation.Length == 1)
            {
                return true;
            }

            if (representation[1] == '*')
            {
                return false;
            }

            for (int i = 1; i < representation.Length; i++)
            {
                char currentCharacter = representation[i];

                if (currentCharacter == '*')
                {
                    if (i == 1)
                    {
                        return false;
                    }

                    if (representation[i - 1] != '=')
                    {
                        return false;
                    }

                    if (i + 1 < representation.Length && representation[i + 1] == '*')
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public int CalculateWeight()
        {
            int totalWeight = 0;
            int currentBeamSectionLength = 0;

            for (int i = 1; i < representation.Length; i++)
            {
                char currentCharacter = representation[i];

                if (currentCharacter == '=')
                {
                    currentBeamSectionLength++;
                }
                else if (currentCharacter == '*')
                {
                    totalWeight += currentBeamSectionLength;
                    totalWeight += currentBeamSectionLength * 2;
                    currentBeamSectionLength = 0;
                }
            }

            totalWeight += currentBeamSectionLength;

            return totalWeight;
        }

        public BeamStatus Evaluate()
        {
            if (!IsWellBuilt())
            {
                return BeamStatus.Malformed;
            }

            int totalWeight = CalculateWeight();
            int resistance = beamBase.Resistance;

            if (totalWeight <= resistance)
            {
                return BeamStatus.SupportsWeight;
            }

            return BeamStatus.DoesNotSupportWeight;
        }
    }
}