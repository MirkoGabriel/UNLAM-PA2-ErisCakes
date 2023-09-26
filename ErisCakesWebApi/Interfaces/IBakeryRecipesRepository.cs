using ErisCakesWebApi.Models;

namespace ErisCakesWebApi.Interfaces
{
    public interface IBakeryRecipesRepository
    {
        ICollection<BakeryRecipe> GetBakeryRecipes();
        BakeryRecipe GetBakeryRecipe(int id);
        BakeryRecipe CreateBakeryRecipe(BakeryRecipe bakeryRecipe);
    }
}
