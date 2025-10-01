namespace LeetCodeSolutions._1000._700._30;

/***
URL: https://leetcode.com/problems/minimum-number-of-people-to-teach
Number: 1733
Difficulty: Medium
 */
public class MinimumNumberofPeopletoTeach
{
    public int MinimumTeachings(int n, int[][] languages, int[][] friendships)
    {
        var peopleNeedingTeaching = new HashSet<int>();

        foreach (var friendship in friendships)
        {
            var personA = friendship[0] - 1;
            var personB = friendship[1] - 1;
            var languagesOfPersonA = new HashSet<int>();

            foreach (var language in languages[personA])
            {
                languagesOfPersonA.Add(language);
            }

            var canCommunicate = false;

            foreach (var language in languages[personB])
            {
                if (languagesOfPersonA.Contains(language))
                {
                    canCommunicate = true;
                    break;
                }
            }

            if (!canCommunicate)
            {
                peopleNeedingTeaching.Add(personA);
                peopleNeedingTeaching.Add(personB);
            }
        }

        var languageCount = new int[n + 1];
        var maxLanguageFrequency = 0;

        foreach (var person in peopleNeedingTeaching)
        {
            foreach (var language in languages[person])
            {
                languageCount[language]++;
                maxLanguageFrequency = Math.Max(maxLanguageFrequency, languageCount[language]);
            }
        }

        return peopleNeedingTeaching.Count - maxLanguageFrequency;
    }
}
