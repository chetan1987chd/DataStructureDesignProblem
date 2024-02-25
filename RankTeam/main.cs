using System.Text;

/// <summary>
/// Represents a class that ranks teams based on votes.
/// </summary>
//LeetCode : 1366 // https://leetcode.com/problems/rank-teams-by-votes/description/
//Input: votes = ["ABC","ACB","ABC","ACB","ACB"]
//Output: "ACB"

public class RankTeamsByVotes
{
    /// <summary>
    /// Ranks the teams based on the given votes.
    /// </summary>
    /// <param name="votes">An array of strings representing the votes.</param>
    /// <returns>A string representing the sorted teams.</returns>
    public string RankTeam(string[] votes)
    {
        // Get the number of positions in a vote
        int numberOfPosition = votes[0].Length;

        // Calculate the positions of each team based on the votes
        int[][] teamPositions = CalculateTeamPositions(votes, numberOfPosition);

        // Create an array of teams
        int[] teams = CreateTeamsArray();

        // Sort the teams based on their positions
        Array.Sort(teams, (a, b) => CompareTeams(teamPositions, a, b, numberOfPosition));

        // Build the sorted team string
        StringBuilder sortedTeamSB = BuildSortedTeamString(teams, numberOfPosition);

        // Return the sorted team string
        return sortedTeamSB.ToString();
    }

    /// <summary>
    /// Calculates the positions of each team based on the votes.
    /// </summary>
    /// <param name="votes">An array of strings representing the votes.</param>
    /// <param name="numberOfPosition">The number of positions in a vote.</param>
    /// <returns>A 2D array representing the positions of each team.</returns>
    private int[][] CalculateTeamPositions(string[] votes, int numberOfPosition)
    {
        // Initialize the team positions array
        int[][] teamPositions = new int[26][];

        for (int i = 0; i < 26; i++)
        {
            teamPositions[i] = new int[numberOfPosition];
        }

        // Calculate the positions for each team based on the votes
        foreach (string vote in votes)
        {
            for (int i = 0; i < numberOfPosition; i++)
            {
                int teamIndex = vote[i] - 'A';
                teamPositions[teamIndex][i]++;
            }
        }

        // Return the team positions array
        return teamPositions;
    }

    /// <summary>
    /// Creates an array of teams.
    /// </summary>
    /// <returns>An array of teams.</returns>
    private int[] CreateTeamsArray()
    {
        // Initialize the teams array
        int[] teams = new int[26];

        for (int i = 0; i < 26; i++)
        {
            teams[i] = i;
        }

        // Return the teams array
        return teams;
    }

    /// <summary>
    /// Compares two teams based on their positions.
    /// </summary>
    /// <param name="teamPositions">The positions of each team.</param>
    /// <param name="a">The index of the first team.</param>
    /// <param name="b">The index of the second team.</param>
    /// <param name="numberOfPosition">The number of positions in a vote.</param>
    /// <returns>A negative value if team A should be ranked higher, a positive value if team B should be ranked higher, or zero if they have the same rank.</returns>
    private int CompareTeams(int[][] teamPositions, int a, int b, int numberOfPosition)
    {
        for (int i = 0; i < numberOfPosition; i++)
        {
            if (teamPositions[a][i] != teamPositions[b][i])
            {
                return teamPositions[b][i] - teamPositions[a][i];
            }
        }

        return b - a;
    }

    /// <summary>
    /// Builds a string representing the sorted teams.
    /// </summary>
    /// <param name="teams">An array of teams.</param>
    /// <param name="numberOfPosition">The number of positions in a vote.</param>
    /// <returns>A StringBuilder object representing the sorted teams.</returns>
    private StringBuilder BuildSortedTeamString(int[] teams, int numberOfPosition)
    {
        // Initialize the StringBuilder object
        StringBuilder sortedTeamSB = new StringBuilder();

        // Build the sorted team string
        for (int i = 0; i < numberOfPosition; i++)
        {
            sortedTeamSB.Append((char)(teams[i] + 'A'));
        }

        // Return the sorted team StringBuilder object
        return sortedTeamSB;
    }
}
        
        
