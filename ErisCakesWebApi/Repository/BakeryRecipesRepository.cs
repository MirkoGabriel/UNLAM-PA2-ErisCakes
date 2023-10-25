using ErisCakesWebApi.Data;
using ErisCakesWebApi.Interfaces;
using ErisCakesWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ErisCakesWebApi.Repository
{
    public class BakeryRecipesRepository : IBakeryRecipesRepository
    {
        private readonly DataContext _context;
        public BakeryRecipesRepository(DataContext context)
        {
            _context = context;
        }

        public BakeryRecipe CreateBakeryRecipe(BakeryRecipe bakeryRecipe)
        {
            _context.Add(bakeryRecipe);
            _context.SaveChanges();

            return bakeryRecipe;
        }

        public void DeleteBakeryRecipe(int id)
        {
            var bakeryRecipe = _context.BakeryRecipes.Find(id);
            _context.Remove(bakeryRecipe);
            _context.SaveChanges();
        }

        public BakeryRecipe EditBakeryRecipe(BakeryRecipe bakeryRecipe)
        {
            _context.Entry(bakeryRecipe).State = EntityState.Modified;
            _context.SaveChanges();
            return bakeryRecipe;
        }



        public BakeryRecipe GetBakeryRecipe(int id)
        {
            return _context.BakeryRecipes.Where(br => br.Id == id).FirstOrDefault();
        }

        public ICollection<BakeryRecipe> GetBakeryRecipes()
        {
            return _context.BakeryRecipes.OrderBy(x => x.Id).ToList();
        }
    }
}
