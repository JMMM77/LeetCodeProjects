namespace LeetCodeSolutions._2000._0._40;

/***
URL: https://leetcode.com/problems/simple-bank-system
Number: 2043
Difficulty: Medium
 */
public class SimpleBankSystem
{
    public class Bank
    {
        private readonly long[] Balance = [];

        public Bank(long[] balance)
        {
            Balance = balance;
        }

        public bool Transfer(int account1, int account2, long money)
        {
            var id1 = account1 - 1;
            var id2 = account2 - 1;

            if (!AccountExists(id1) || !AccountExists(id2))
            {
                return false;
            }

            if (Balance[id1] - money < 0)
            {
                return false;
            }

            Balance[id1] -= money;
            Balance[id2] += money;

            return true;
        }

        public bool Deposit(int account, long money)
        {
            var id = account - 1;

            if (!AccountExists(id))
            {
                return false;
            }

            Balance[id] += money;

            return true;
        }

        public bool Withdraw(int account, long money)
        {
            var id = account - 1;

            if (!AccountExists(id))
            {
                return false;
            }

            if (Balance[id] - money < 0)
            {
                return false;
            }

            Balance[id] -= money;

            return true;
        }

        private bool AccountExists(int accountId)
            => accountId >= 0 && accountId < Balance.Length;
    }
}
