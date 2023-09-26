namespace ErisCakesWebApi.Models
{
    public class BakeryRequest
    {
        public BakeryRequest() 
        {
            BakeryRequestRecipes = new HashSet<BakeryRequestRecipe>();
        }
        public int Id { get; set; }
        public string RecipeStatus { get; set; }
        public string BillingStatus { get; set;}
        public DateTime AdmissionDate { get; set; }
        public DateTime EstimateDeliveryDate { get; set; }
        public double EstimatedPrice { get; set; }
        public string AdditionalComments { get; set; }
        public int JobScore { get; set; }
        public int? ClientId { get; set; }
        public Client? Client { get; set; }
        public ICollection<BakeryRequestRecipe> BakeryRequestRecipes { get; set; }

        public static implicit operator BakeryRequest(HashSet<BakeryRequest> v)
        {
            throw new NotImplementedException();
        }
    }
}
