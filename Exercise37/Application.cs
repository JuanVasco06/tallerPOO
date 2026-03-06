using System;
using System.Collections.Generic;

namespace Exercise37
{
    public class Application
    {
        public void Run()
        {
            Console.Write("Ingrese ubicación de los caballos: ");
            string input = Console.ReadLine();

            Board board = BuildBoard(input);
            AnalyzeKnights(board);
        }

        private Board BuildBoard(string input)
        {
            Board board = new Board();

            if (string.IsNullOrWhiteSpace(input))
            {
                return board;
            }

            string[] parts = input.Split(',');

            foreach (string part in parts)
            {
                string cleanedText = part.Trim().ToUpper();

                if (Position.IsValid(cleanedText))
                {
                    Position position = Position.FromString(cleanedText);
                    Knight knight = new Knight(position);
                    board.AddKnight(knight);
                }
            }

            return board;
        }

        private void AnalyzeKnights(Board board)
        {
            List<Knight> knights = board.GetKnights();

            foreach (Knight knight in knights)
            {
                List<Knight> conflicts = board.GetConflictsFor(knight);

                Console.Write($"Analizando Caballo en {knight} => ");

                if (conflicts.Count == 0)
                {
                    Console.WriteLine("Sin conflicto");
                }
                else
                {
                    for (int i = 0; i < conflicts.Count; i++)
                    {
                        Console.Write($"Conflicto con {conflicts[i]}");

                        if (i < conflicts.Count - 1)
                        {
                            Console.Write("    ");
                        }
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}