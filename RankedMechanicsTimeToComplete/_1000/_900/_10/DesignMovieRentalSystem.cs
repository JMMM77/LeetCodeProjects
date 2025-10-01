namespace LeetCodeSolutions._1000._900._10;

/***
URL: https://leetcode.com/problems/design-movie-rental-system
Number: 1912
Difficulty: Hard
 */
public class DesignMovieRentalSystem
{
    public class MovieRentingSystem
    {
        private readonly Dictionary<(int, int), int> Price = [];
        private readonly Dictionary<int, SortedSet<(int price, int shop)>> Available = [];
        private readonly SortedSet<(int price, int shop, int movie)> Rented;

        public MovieRentingSystem(int n, int[][] entries)
        {
            // custom comparer for Rented movies (Price, shop, movie)
            Rented = new SortedSet<(int price, int shop, int movie)>(
                Comparer<(int price, int shop, int movie)>.Create((a, b) =>
                {
                    return a.price != b.price
                        ? a.price.CompareTo(b.price)
                        : a.shop != b.shop
                            ? a.shop.CompareTo(b.shop)
                            : a.movie.CompareTo(b.movie);
                })
            );

            foreach (var e in entries)
            {
                int shop = e[0], movie = e[1], p = e[2];

                Price[(shop, movie)] = p;

                if (!Available.TryGetValue(movie, out var value))
                {
                    value = new SortedSet<(int, int)>(
                        Comparer<(int, int)>.Create((a, b) =>
                        {
                            if (a.Item1 != b.Item1) return a.Item1.CompareTo(b.Item1);
                            return a.Item2.CompareTo(b.Item2);
                        })
                    );
                    Available[movie] = value;
                }

                value.Add((p, shop));
            }
        }

        public IList<int> Search(int movie)
        {
            var result = new List<int>();

            if (!Available.TryGetValue(movie, out var value))
            {
                return result;
            }

            var count = 0;

            foreach (var (price, shop) in value)
            {
                result.Add(shop);
                count++;

                if (count == 5)
                {
                    break;
                }
            }

            return result;
        }

        public void Rent(int shop, int movie)
        {
            var p = Price[(shop, movie)];

            Available[movie].Remove((p, shop));

            Rented.Add((p, shop, movie));
        }

        public void Drop(int shop, int movie)
        {
            var p = Price[(shop, movie)];

            Rented.Remove((p, shop, movie));

            Available[movie].Add((p, shop));
        }

        public IList<IList<int>> Report()
        {
            var result = new List<IList<int>>();
            var count = 0;

            foreach (var (p, shop, movie) in Rented)
            {
                result.Add([shop, movie]);
                count++;

                if (count == 5)
                {
                    break;
                }
            }

            return result;
        }
    }
}
