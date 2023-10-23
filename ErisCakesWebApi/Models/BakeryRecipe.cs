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
        public double Price { get; set; }
        public ICollection<BakeryRequestRecipe> BakeryRequestRecipes { get; set; }
    }
}
