namespace LeetCodeSolutions._2000._100._20;

/***
URL: https://leetcode.com/problems/number-of-laser-beams-in-a-bank
Number: 2125
Difficulty: Medium
 */
public class NumberofLaserBeamsinaBank
{
    public int NumberOfBeams(string[] bank)
    {
        var yLength = bank[0].Length;
        var prevNumOfDevices = 0;
        var numOfLasers = 0;

        for (var i = 0; i < bank.Length; i++)
        {
            var thisRow = bank[i];
            var thisNumOfDevices = 0;

            for (var j = 0; j < yLength; j++)
            {
                if (thisRow[j] == '1')
                {
                    thisNumOfDevices++;
                }
            }

            if (thisNumOfDevices == 0)
            {
                continue;
            }

            if (prevNumOfDevices == 0)
            {
                prevNumOfDevices = thisNumOfDevices;
                continue;
            }

            numOfLasers += prevNumOfDevices * thisNumOfDevices;
            prevNumOfDevices = thisNumOfDevices;
        }

        return numOfLasers;
    }
}
