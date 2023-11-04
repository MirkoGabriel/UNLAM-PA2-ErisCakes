using System.ComponentModel.DataAnnotations;

namespace ErisCakesWebApi.Models
{
    public class BakeryRecipe
    {
        public BakeryRecipe()
        {
            BakeryRequestRecipes = new HashSet<BakeryRequestRecipe>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Kind { get; set; }
        public string Ingredients { get; set; }
        public string Procedure { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Recipe price must be gratter than 0")]
        public double Price { get; set; }
        public ICollection<BakeryRequestRecipe> BakeryRequestRecipes { get; set; }
    }
}
