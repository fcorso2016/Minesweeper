#include <iostream>
#include <random>

using namespace std;

int main() {

    // Initialize the dimensions and mine count of the board
    unsigned rows;
    unsigned cols;
    unsigned mines;
    cin >> rows >> cols >> mines;

    // Allocate the memory for the board
    char** board = new char*[rows];
    for (int i = 0; i < rows; i++) {
        board[i] = new char[cols];
    }

    // Fill the board with empty squares
    for (int i = 0; i < rows; i++) {
        for (int j = 0; j < cols; j++) {
            board[i][j] = '0';
        }
    }

    // Generate the board
    for (int k = 0; k < mines; k++) {
        // Get a random position that isn't a mine and make it a mine
        unsigned mine_x;
        unsigned mine_y;
        do {
            mine_x = rand() % rows;
            mine_y = rand() % cols;
        } while (board[mine_x][mine_y] == 'X');
        board[mine_x][mine_y] = 'X';

        // Increment all non-mine adjacent squares
        for (int x = -1; x <= 1; x++) {
            for (int y = -1; y <= 1; y++) {
                if (board[mine_x + x][mine_y + y] != 'X') {
                    board[mine_x + x][mine_y + y]++;
                }
            }
        }

    }

    // Output the board to the console
    for (int i = 0; i < rows; i++) {
        for (int j = 0; j < cols; j++) {
            cout << board[i][j];
        }
        cout << endl;
    }

    // Dispose of memory to avoid leaks
    for (int i = 0; i < rows; i++) {
        delete [] board[i];
    }
    delete [] board;

    return 0;
}