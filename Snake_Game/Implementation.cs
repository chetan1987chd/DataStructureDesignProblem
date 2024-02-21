public class SnakeGame
{
    // Dimensions of the game board
    private readonly int Width;
    private readonly int Height;

    // 2D array to store the coordinates of food items
    private readonly int[][] Food;
    private int FoodIndex = 0; // Index to keep track of the current food item being consumed

    private int Score = 0; // Player's score

    // Current coordinates of the snake's head
    private int HeadW = 0;
    private int HeadH = 0;
    private Queue<string> Body = new(); // Queue to store coordinates of the snake's body

    // Constructor initializes the game with width, height, and food locations
    public SnakeGame(int width, int height, int[][] food)
    {
        Width = width;
        Height = height;
        Food = food;
    }

    // Method to move the snake based on the provided direction
    public int Move(string direction)
    {
        // Calculate the next position based on the direction
        var (newH, newW) = CalculateNextPosition(direction);
        var newHeadString = newH + "," + newW; // String representation of the new head position

        // Check if the new position is out of range
        if (IsOutOfRange(newH, newW))
        {
            return -1; // Game over
        }

        // Check if the new position contains food
        if (IsOnFood(newH, newW))
        {
            Score++; // Increment the score
            FoodIndex++; // Move to the next food item
            Body.Enqueue(HeadH + "," + HeadW); // Enqueue the current head position
            HeadH = newH;
            HeadW = newW;
            return Score; // Return the updated score
        }

        // If the snake's body has segments, update the body queue
        if (Body.Count > 0)
        {
            Body.Dequeue(); // Remove the tail segment
            Body.Enqueue(HeadH + "," + HeadW); // Enqueue the new head position
        }

        // Check if the new head position is already in the snake's body
        if (Body.Contains(newHeadString))
        {
            return -1; // Game over (snake collided with itself)
        }

        // Update the snake's head position
        HeadH = newH;
        HeadW = newW;

        return Score; // Return the current score
    }

    // Helper method to check if the provided coordinates are on a food item
    private bool IsOnFood(int newH, int newW)
    {
        // Check if there are more food items and if the current position matches a food item
        if (FoodIndex == Food.Length)
            return false;

        if (Food[FoodIndex][0] == newH && Food[FoodIndex][1] == newW)
            return true;

        return false;
    }

    // Helper method to check if the provided coordinates are out of the game board boundaries
    private bool IsOutOfRange(int newH, int newW)
    {
        // Check if the coordinates are beyond the game board boundaries
        if (newH < 0 || newH >= Height)
            return true;

        if (newW < 0 || newW >= Width)
            return true;

        return false;
    }

    // Helper method to calculate the next position based on the provided direction
    private (int newH, int newW) CalculateNextPosition(string direction)
    {
        // Calculate the new coordinates based on the direction
        return direction switch
        {
            "U" => (HeadH - 1, HeadW),
            "D" => (HeadH + 1, HeadW),
            "L" => (HeadH, HeadW - 1),
            "R" => (HeadH, HeadW + 1),
            _ => throw new Exception("Bad move" + direction), // Throw an exception for an invalid direction
        };
    }
}
