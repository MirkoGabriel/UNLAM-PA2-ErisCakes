namespace ErisCakesWebApi.Models
{
    public class BakeryRequestRecipe
    {
        public int BakeryRequestId { get; set; }
        public int BakeryRecipeId { get; set; }
        public BakeryRequest? BakeryRequest { get; set; }
        public BakeryRecipe? BakeryRecipe { get; set; }
    }
}
