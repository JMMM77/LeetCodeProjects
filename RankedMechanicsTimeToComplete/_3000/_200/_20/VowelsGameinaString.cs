namespace LeetCodeSolutions._3000._200._20;

/***
URL: https://leetcode.com/problems/vowels-game-in-a-string
Number: 3227
Difficulty: Medium
 */
public class VowelsGameinaString
{
    public bool DoesAliceWin(string s)
        => s.Any("aeiou".Contains);
}
