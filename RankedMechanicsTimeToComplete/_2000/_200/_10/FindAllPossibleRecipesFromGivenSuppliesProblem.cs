namespace LeetCodeSolutions._2000._200._10;
/***
URL: https://leetcode.com/problems/find-all-possible-recipes-from-given-supplies
Number: 2115
Difficulty: Medium
 */
public class FindAllPossibleRecipesFromGivenSuppliesProblem
{
    private readonly List<string> _AvailableRecipes = [];
    private string[] _Recipes = [];
    private IList<IList<string>> _Ingredients = [[]];
    private string[] _Supplies = [];

    public IList<string> FindAllRecipes(string[] recipes, IList<IList<string>> ingredients, string[] supplies)
    {
        _Recipes = recipes;
        _Ingredients = ingredients;
        _Supplies = supplies;

        for (var i = 0; i < recipes.Length; i++)
        {
            IsRecipeValidRecursive(i, []);
        }

        return _AvailableRecipes;
    }
    private bool IsRecipeValidRecursive(int recipeIndex, List<string> listOfRecipeCurrentlyChecking)
    {
        var recipeToVerify = _Recipes[recipeIndex];

        if (_AvailableRecipes.Contains(recipeToVerify))
        {
            return true;
        }

        var ingredientsForRecipe = _Ingredients[recipeIndex];

        for (var i = 0; i < ingredientsForRecipe.Count; i++)
        {
            var ingredient = ingredientsForRecipe[i];

            if (_Supplies.Contains(ingredient))
            {
                continue;
            }

            // Checks whether the ingredient is a recipe
            var ingredientAsRecipeIndex = Array.IndexOf(_Recipes, ingredient);

            if (ingredientAsRecipeIndex == -1)
            {
                return false;
            }

            // Prevents infinite loop if a recipe relies on itself e.g. "h" => "zmpx", "zmpx" => "h"
            if (listOfRecipeCurrentlyChecking.Contains(ingredient))
            {
                // I used to say continue but the below note basically says if it does then it cant be made
                // "Note that two recipes may contain each other in their ingredients." 
                return false;
            }

            listOfRecipeCurrentlyChecking.Add(ingredient);

            var recipeIsValid = IsRecipeValidRecursive(ingredientAsRecipeIndex, listOfRecipeCurrentlyChecking);

            listOfRecipeCurrentlyChecking.Remove(ingredient);

            if (!recipeIsValid)
            {
                return false;
            }
        }

        if (!_AvailableRecipes.Contains(recipeToVerify))
        {
            _AvailableRecipes.Add(recipeToVerify);
        }

        return true;
    }
}
