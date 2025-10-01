namespace LeetCodeSolutions._2000._300._20;

/***
URL: https://leetcode.com/problems/number-of-people-aware-of-a-secret
Number: 2327
Difficulty: Medium
 */
public class NumberofPeopleAwareofaSecret
{
    private const long MOD = 1_000_000_007L;

    public int PeopleAwareOfSecret(int n, int delay, int forget)
    {
        var know = new LinkedList<long[]>();   // nodes: [dayLearned, count]
        var share = new LinkedList<long[]>();  // nodes: [dayLearned, count]

        know.AddLast([1L, 1L]);
        var knowCnt = 1L;   // people who know but are not yet sharing
        var shareCnt = 0L;  // people who are currently sharing

        for (var day = 2; day <= n; day++)
        {
            // people who learned at (day - delay) now start sharing
            if (know.First != null && know.First.Value[0] == (day - delay))
            {
                var first = know.First.Value;
                know.RemoveFirst();
                knowCnt = (knowCnt - first[1] + MOD) % MOD;
                shareCnt = (shareCnt + first[1]) % MOD;
                share.AddLast(first);
            }

            // people who learned at (day - forget) now forget
            if (share.First != null && share.First.Value[0] == (day - forget))
            {
                var first = share.First.Value;
                share.RemoveFirst();
                shareCnt = (shareCnt - first[1] + MOD) % MOD;
            }

            // current sharers each tell one new person today
            if (shareCnt > 0)
            {
                knowCnt = (knowCnt + shareCnt) % MOD;
                know.AddLast([day, shareCnt]);
            }
        }

        return (int)((knowCnt + shareCnt) % MOD);
    }
}
