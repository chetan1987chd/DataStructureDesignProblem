using System.Collections;

public class TopVotedCandidate {

    int[] persons; // Array to store the persons who voted
    int[] times; // Array to store the corresponding times of the votes
    List<int> leaderBoard = new(); // List to store the current leader at each vote
    public TopVotedCandidate(int[] persons, int[] times) {
        this.persons = persons;
        this.times = times;
        CalculateVotes(); // Calculate the votes and populate the leaderBoard list
    }
    
    public int Q(int t) {
        int closetIndex = GetClosestIndex(t); // Get the index of the closest time to the given time
        return leaderBoard[closetIndex]; // Return the leader at that time
    }

    void CalculateVotes()
    {
        int currentLeader = -1; // Variable to store the current leader
        Dictionary<int,int> voteTally = new(); // Dictionary to store the vote count for each person

        for(int i =0;i<persons.Length;i++)
        {
            int currentPerson = persons[i]; // Get the current person who voted
            voteTally.TryGetValue(currentPerson,out int voteCount); // Get the vote count for the current person
            voteTally[currentPerson] = voteCount+1; // Increment the vote count for the current person

            if(currentLeader==-1 || voteTally[currentPerson]>=voteTally[currentLeader])
            {
                currentLeader = currentPerson; // Update the current leader if the current person has more votes or if there is no current leader
            }
            leaderBoard.Add(currentLeader); // Add the current leader to the leaderBoard list
        }

    }

    int GetClosestIndex(int time)
    {
        int left = 0; // Left pointer for binary search
        int right = times.Length-1; // Right pointer for binary search

        while(left<=right)
        {
            int mid = left + (right-left)/2; // Calculate the middle index

            if(times[mid]==time)
            {
                return mid; // Return the index if the time at the middle index is equal to the given time
            }
            else if(time> times[mid])
            {
                left = mid +1; // Update the left pointer if the given time is greater than the time at the middle index
            }
            else{
                right = mid-1; // Update the right pointer if the given time is less than the time at the middle index
            }
        }

        return left-1; // Return the index of the closest time to the given time
    }
}
