public class SnakeGame
{
    private readonly int Width;
    private readonly int Height;

    private readonly int[][] Food;
    private int FoodIndex = 0;

    private int Score = 0;

    private int HeadW = 0;
    private int HeadH = 0;
    private Queue<string> Body = new();


    public SnakeGame(
               int width,
               int height,
               int[][] food)
    {
        Width = width;
        Height = height;
        Food = food;
    }

    public int Move(string direction)
    {
        var (newH, newW) = CalculateNextPosition(direction);
        var newHeadString = newH + "," + newW;

        if (IsOutOfRange(newH, newW))
        {
            return -1;
        }

        if (IsOnFood(newH, newW))
        {
            Score++;
            FoodIndex++;
            Body.Enqueue(HeadH + "," + HeadW);
            HeadH = newH;
            HeadW = newW;
            return Score;
        }

        if (Body.Count > 0)
        {
            Body.Dequeue();
            Body.Enqueue(HeadH + "," + HeadW);
        }

        if (Body.Contains(newHeadString))
        {
            return -1;
        }

        HeadH = newH;
        HeadW = newW;

        return Score;
    }

    private bool IsOnFood(int newH, int newW)
    {
        if (FoodIndex == Food.Length)
            return false;

        if (Food[FoodIndex][0] == newH && Food[FoodIndex][1] == newW)
            return true;

        return false;
    }

    private bool IsOutOfRange(int newH, int newW)
    {
        if (newH < 0 || newH >= Height)
            return true;

        if (newW < 0 || newW >= Width)
            return true;

        return false;
    }

    private (int newH, int newW) CalculateNextPosition(string direction)
    {
        return direction switch
        {
            "U" => (HeadH - 1, HeadW),
            "D" => (HeadH + 1, HeadW),
            "L" => (HeadH, HeadW - 1),
            "R" => (HeadH, HeadW + 1),
            _ => throw new Exception("Bad move" + direction),
        };
    }
}
