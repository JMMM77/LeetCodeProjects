namespace LeetCodeSolutions._2000._300._50;

/***
URL: https://leetcode.com/problems/design-a-food-rating-system
Number: 2353
Difficulty: Medium
 */
public class DesignaFoodRatingSystem
{
    public class FoodRatings
    {
        private readonly Dictionary<string, SortedSet<Food>> cuisineFoods = [];
        private readonly Dictionary<string, Food> foodMap = [];

        public FoodRatings(string[] foods, string[] cuisines, int[] ratings)
        {
            for (var i = 0; i < foods.Length; i++)
            {
                var f = new Food(foods[i], cuisines[i], ratings[i]);

                if (!cuisineFoods.ContainsKey(cuisines[i]))
                    cuisineFoods[cuisines[i]] = new SortedSet<Food>(new FoodComparer());

                cuisineFoods[cuisines[i]].Add(f);
                foodMap[foods[i]] = f;
            }
        }

        public void ChangeRating(string food, int newRating)
        {
            var f = foodMap[food];

            cuisineFoods[f.Cuisine].Remove(f);
            f.Rating = newRating;
            cuisineFoods[f.Cuisine].Add(f);
        }

        public string HighestRated(string cuisine)
        {
            // SortedSet is ordered, so first element = highest rated
            return cuisineFoods[cuisine].Min!.Name;
        }

        private class Food(string food, string cuisine, int rating)
        {
            public string Name { get; } = food;
            public string Cuisine { get; } = cuisine;
            public int Rating { get; set; } = rating;
        }

        private class FoodComparer : IComparer<Food>
        {
            public int Compare(Food? a, Food? b)
            {
                if (a == null || b == null)
                {
                    return 0;
                }

                var ratingCompare = b.Rating.CompareTo(a.Rating);

                if (ratingCompare != 0)
                {
                    return ratingCompare;
                }

                // tie-break by name ASC
                var nameCompare = string.Compare(a.Name, b.Name, StringComparison.Ordinal);

                return nameCompare;
            }
        }
    }
}
