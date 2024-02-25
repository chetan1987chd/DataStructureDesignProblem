
//Leet code : 359 // https://leetcode.com/problems/logger-rate-limiter/description/

public class Logger
{
    // Dictionary to store the last timestamp for each message
    Dictionary<string,int> timeStampDict = new Dictionary<string, int>();

    // Method to check if a message should be printed based on the timestamp
    public bool ShouldPrintMessage(int timestamp, string message) {
        // If the message is not present in the dictionary, add it with the current timestamp and return true
        if(!timeStampDict.ContainsKey(message))
        {
            timeStampDict.Add(message,timestamp);
            return true;
        }

        // If the difference between the current timestamp and the last timestamp for the message is greater than or equal to 10,
        // update the last timestamp for the message and return true
        if(timestamp-timeStampDict[message]>=10)
        {
            timeStampDict[message] = timestamp;
            return true;
        }
        else
        {
            // If the difference is less than 10, return false indicating that the message should not be printed
            return false;
        }
    }
}
