namespace ErisCakesWebApi.Dto
{
    public class BakeryRecipeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Kind { get; set; }
        public string Ingredients { get; set; }
        public string Procedure { get; set; }
        public double Price { get; set; }
    }
}
