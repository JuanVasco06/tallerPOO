using System.Collections.Generic;

namespace Exercise37
{
    public class Board
    {
        private List<Knight> knights;

        public Board()
        {
            knights = new List<Knight>();
        }

        public void AddKnight(Knight knight)
        {
            knights.Add(knight);
        }

        public List<Knight> GetKnights()
        {
            return knights;
        }

        public List<Knight> GetConflictsFor(Knight knight)
        {
            List<Knight> conflictingKnights = new List<Knight>();

            foreach (Knight currentKnight in knights)
            {
                if (currentKnight != knight && knight.IsInConflictWith(currentKnight))
                {
                    conflictingKnights.Add(currentKnight);
                }
            }

            return conflictingKnights;
        }
    }
}