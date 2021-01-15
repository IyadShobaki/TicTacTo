using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToBlazor.Models
{
    public class GameManager
    {

        public char Player { get; private set; } = 'X';
        public char[] Board { get; private set; }
        public GameManager()
        {
            Board = new char[9];
        }
        public void NextTurn()
        {
            Player = Player == 'X' ? 'O' : 'X';
        }
        public void MakeMove(int index)
        {
            if (Board[index] != '\0' || !IsRunning())
            {
                return;
            }
            Board[index] = Player; // Check if there is a winner or not after this move

            if (FindWinner() == null)
            {
                NextTurn();

            }
        }
        public int[] FindWinner()
        {
            int[,] winningCombinations = {  {0,1,2},
                                            {3,4,5},
                                            {6,7,8},
                                            {0,3,6},
                                            {1,4,7},
                                            {2,5,8},
                                            {0,4,8},
                                            {2,4,6} };

            for (int i = 0; i < winningCombinations.GetLength(0); i++)
            {
                int[] internalArray = new int[3];

                for (int j = 0; j < winningCombinations.GetLength(1); j++)
                {
                    internalArray[j] = winningCombinations[i, j];
                }
                int a = internalArray[0];
                int b = internalArray[1];
                int c = internalArray[2];
                if (Board[a] != '\0'
                    && Board[a] == Board[b]
                    && Board[a] == Board[c])
                {
                    return internalArray;
                }

            }
            return null;
        }

        public bool IsRunning()
        {
            return FindWinner() == null && Board.Contains('\0');
        }

        //public void RestartGame()
        //{
        //    Player = 'X';
        //    Board = new char[9];
        //}
    }
}
