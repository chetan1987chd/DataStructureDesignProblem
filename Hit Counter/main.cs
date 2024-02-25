

/// <summary>
/// Represents a hit counter that keeps track of the number of hits at different timestamps.
/// </summary>
// Leetcode : 362 // https://leetcode.com/problems/design-hit-counter/description/
public class HitCounter {

    // Dictionary to store the number of hits at each timestamp
    Dictionary<int,int> hitDict = new Dictionary<int, int>();

    /// <summary>
    /// Initializes a new instance of the HitCounter class.
    /// </summary>
    public HitCounter() {
        
    }
    
    /// <summary>
    /// Records a hit at the specified timestamp.
    /// </summary>
    /// <param name="timestamp">The timestamp of the hit.</param>
    public void Hit(int timestamp) {
        if(!hitDict.ContainsKey(timestamp))
        {
            hitDict.Add(timestamp,0);
        }

        hitDict[timestamp]++;
    }
    
    /// <summary>
    /// Gets the total number of hits in the last 300 seconds (5 minutes) up to the specified timestamp.
    /// </summary>
    /// <param name="timestamp">The timestamp up to which to calculate the total number of hits.</param>
    /// <returns>The total number of hits in the last 300 seconds.</returns>
    public int GetHits(int timestamp) {

        int result = hitDict.Where(x=>x.Key<=timestamp && x.Key>timestamp-300).Sum(x=>x.Value);

        return result;
    }
}
