namespace LeetCodeSolutions._3000._0._20;

/***
URL: https://leetcode.com/problems/alice-and-bob-playing-flower-game
Number: 3021
Difficulty: Medium
 */
public class AliceAndBobPlayingFlowerGame
{
    public long FlowerGame(int n, int m)
    {
        // Count odd and even Values for x and y
        long oddX = (n + 1) / 2;
        long evenX = n / 2;
        long oddY = (m + 1) / 2;
        long evenY = m / 2;

        // Valid pairs = (oddX * evenY) + (evenX * oddY)
        return oddX * evenY + evenX * oddY;
    }
}
