//Complexity Analysis

//Time Complexity: O(n)O(n)O(n), as for every move we are iterating over n cells 4 times to check for each of the column, row, diagonal row, and anti-diagonal. 
//This gives us time complexity of O(4⋅*n) which is equivalent to O(n)

//Space Complexity: O(n^2), as we are using 2-dimensional array board of size n * n.

public class TicTacToe
{
    int[,] Board; // 2D array to represent the TicTacToe board
    int Length; // Length of the board

    public TicTacToe(int n)
    {
        Board = new int[n,n]; // Initialize the board with size n x n
        Length = n; // Set the length of the board
    }

    // Method to make a move on the board
    // Returns the player number if the move results in a win, otherwise returns 0
    public int Move(int row, int col, int player)
    {
        Board[row,col] = player; // Set the player number on the specified row and column

        // Check if the move results in a win by checking rows, columns, and diagonals
        if(checkRow(row,player) || checkCol(col,player) || checkDiagonalBack(player) || checkDiagonalBackForward(player))
        {
            return player; // Return the player number if there is a win
        }

        return 0; // Return 0 if there is no win
    } 

    // Method to check if a row contains the same player number
    bool checkRow(int row, int player)
    {
        for(int col=0;col<Length;col++)
        {
            if(Board[row,col]!=player) // If any element in the row is not equal to the player number, return false
            {
                return false;
            }
        }

        return true; // If all elements in the row are equal to the player number, return true
    }

    // Method to check if a column contains the same player number
    bool checkCol(int col,int player)
    {
        for(int row=0;row<Length;row++)
        {
            if(Board[row,col]!=player) // If any element in the column is not equal to the player number, return false
            {
                return false;
            }
        }
        return true; // If all elements in the column are equal to the player number, return true
    }

    // Method to check if the diagonal from top-left to bottom-right contains the same player number
    bool checkDiagonalBack(int player)
    {
        for(int row=0;row<Length;row++)
        {
            if(Board[row,row]!=player) // If any element in the diagonal is not equal to the player number, return false
            {
                return false;
            }
        }
        return true; // If all elements in the diagonal are equal to the player number, return true
    }

    // Method to check if the diagonal from top-right to bottom-left contains the same player number
    bool checkDiagonalBackForward(int player)
    {
        for(int row=0;row<Length;row++)
        {
            if(Board[row,(Length-1-row)]!=player) // If any element in the diagonal is not equal to the player number, return false
            {
                return false;
            }
        }

        return true; // If all elements in the diagonal are equal to the player number, return true
    }
}
