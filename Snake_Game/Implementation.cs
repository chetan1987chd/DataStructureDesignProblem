public class SnakeGame {

    int CurrentHeight = 0;
    int CurrentWidth = 0;
    int FoodIndex = 0;

    int Height = 0;
    int Width = 0;

    int Score = 0;
    int[][] Food;  
    
    Queue<string> SnakeBody = new Queue<string>();


    public SnakeGame(int width, int height, int[][] food) {
        Height = height;
        Width = width;
        Food = food;
    }
    
     /// <summary>
    /// Moves the snake in the specified direction.
    /// </summary>
    /// <param name="direction">The direction to move the snake.</param>
    /// <returns>The current score after the move. Returns -1 if the move is invalid.</returns>
    public int Move(string direction)
    {
        
        (int newHeight, int newWidth) = FindNextPosition(direction);
        var newPosition = GetPositionString(newHeight, newWidth);

        if (!isInRange(newHeight, newWidth))
        {
            return -1;
        }

        if (isFoundFood(newHeight, newWidth))
        {
            Score++;
            FoodIndex++;
            SnakeBody.Enqueue(GetPositionString(CurrentHeight, CurrentWidth));
            CurrentHeight = newHeight;
            CurrentWidth = newWidth;
            return Score;
        }

        if (SnakeBody.Count > 0)
        {
            SnakeBody.Dequeue();
            SnakeBody.Enqueue(GetPositionString(CurrentHeight, CurrentWidth));
        }

        if (SnakeBody.Contains(newPosition))
        {
            return -1;
        }

        CurrentHeight = newHeight;
        CurrentWidth = newWidth;

        return Score;
    }

    /// <summary>
    /// Finds the next position of the snake based on the specified move.
    /// </summary>
    /// <param name="move">The move direction.</param>
    /// <returns>The new height and width of the snake's position.</returns>
    (int newHeight, int newWidth) FindNextPosition(string move)
    {
        switch (move)
        {
            case "U": return (CurrentHeight - 1, CurrentWidth);
            case "D": return (CurrentHeight + 1, CurrentWidth);
            case "R": return (CurrentHeight, CurrentWidth + 1);
            case "L": return (CurrentHeight, CurrentWidth - 1);
            default: throw new Exception("Invalid move");
        }
    }

    /// <summary>
    /// Checks if the new position is within the game board.
    /// </summary>
    /// <param name="newHeight">The new height of the snake's position.</param>
    /// <param name="newWidth">The new width of the snake's position.</param>
    /// <returns>True if the new position is within the game board, otherwise false.</returns>
    bool isInRange(int newHeight, int newWidth)
    {
        if (newHeight < 0 || newHeight >= Height) return false;
        if (newWidth < 0 || newWidth >= Width) return false;
        return true;
    }

    /// <summary>
    /// Checks if the new position contains food.
    /// </summary>
    /// <param name="newHeight">The new height of the snake's position.</param>
    /// <param name="newWidth">The new width of the snake's position.</param>
    /// <returns>True if the new position contains food, otherwise false.</returns>
    bool isFoundFood(int newHeight, int newWidth)
    {
        if (Food.Length == FoodIndex)
        {
            return false;
        }

        if (Food[FoodIndex][0] == newHeight && Food[FoodIndex][1] == newWidth)
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// Gets the position string based on the height and width.
    /// </summary>
    /// <param name="height">The height of the position.</param>
    /// <param name="width">The width of the position.</param>
    /// <returns>The position string in the format "height,width".</returns>
    string GetPositionString(int height, int width)
    {
        return $"{height},{width}";
    }
}
