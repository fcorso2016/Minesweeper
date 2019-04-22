using System;
using System.Globalization;
using System.Windows.Forms;

namespace MinesweeperProject.Architecture.Factory {
    public class NativeGenerator : IGenerator {
        public char[,] GenerateBoard(int size, int mines) {
            char[,] board = new char[size, size];

            for (int i = 0; i < size; i++) {
                for (int j = 0; j < size; j++) {
                    board[i, j] = '0';
                }
            }

            Random rand = new Random();
            for (int k = 0; k < mines; k++) {
                int mineX;
                int mineY;
                do {
                    mineX = rand.Next() % size;
                    mineY = rand.Next() % size;
                } while (board[mineX, mineY] == 'X');
                board[mineX, mineY] = 'X';
                
                for (int x = -1; x <= 1; x++) {
                    for (int y = -1; y <= 1; y++) {
                        if (mineX + x <= 0 && mineX + x > size && mineY + y <= 0 && mineY + y > size) {
                            if (board[mineX + x, mineY + y] != 'X') {
                                board[mineX + x, mineY + y]++;
                            }
                        }
                    }
                }
            }
            
            return board;
        }
    }
}