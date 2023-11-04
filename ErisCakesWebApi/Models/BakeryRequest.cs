using System.ComponentModel.DataAnnotations;

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
        public string BillingStatus { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "El precio del presupuesto tiene que se mayor a 0")]
        public double BudgetPice { get; set; }
        public DateTime AdmissionDate { get; set; }
        public DateTime EstimateDeliveryDate { get; set; }
        public Boolean HomeDelivery { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "El precio del viaje tiene que se mayor a 0")]
        public double ShippingPrice { get; set; }
        public string AdditionalComments { get; set; }
        [Range(0, 1000, ErrorMessage = "La satisfaccion del cliente tiene que estar entre 0 y 1000")]
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
