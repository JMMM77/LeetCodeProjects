namespace LeetCodeSolutions._3000._500._10;

/***
URL: https://leetcode.com/problems/find-closest-person
Number: 3516
Difficulty: Easy
 */
public class FindClosestPerson
{
    public int FindClosest(int x, int y, int z)
    {
        var xDif = Math.Abs(x - z);
        var yDif = Math.Abs(y - z);

        if (xDif < yDif)
        {
            return 1;
        }
        else if (xDif > yDif)
        {
            return 2;
        }

        return 0;
    }
}
