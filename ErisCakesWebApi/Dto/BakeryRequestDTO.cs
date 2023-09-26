using ErisCakesWebApi.Models;

namespace ErisCakesWebApi.Dto
{
    public class BakeryRequestDTO
    {
        public int Id { get; set; }
        public string RecipeStatus { get; set; }
        public string BillingStatus { get; set; }
        public DateTime AdmissionDate { get; set; }
        public DateTime EstimateDeliveryDate { get; set; }
        public double EstimatedPrice { get; set; }
        public string AdditionalComments { get; set; }
        public int JobScore { get; set; }
        public ClientDTO Client { get; set; }
        public ICollection<BakeryRequestRecipeDTO> BakeryRequestRecipes { get; set; }
    }
}
