using ErisCakesWebApi.Data;
using ErisCakesWebApi.Interfaces;
using ErisCakesWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ErisCakesWebApi.Repository
{
    public class BakeryRequestRepository : IBakeryRequestRepository
    {
        private readonly DataContext _context;
        public BakeryRequestRepository(DataContext context)
        {
            _context = context;
        }

        public BakeryRequest CreateBakeryRequest(BakeryRequest bakeryRequest)
        {
            _context.Add(bakeryRequest);
            _context.SaveChanges();

            return bakeryRequest;
        }

        public void DeleteBakeryRequest(int id)
        {
            var bakeryRequest = _context.BakeryRequests.Find(id);
            _context.Remove(bakeryRequest);
            _context.SaveChanges();
        }

        public BakeryRequest EditBakeryRequest(BakeryRequest bakeryRequest)
        {
            _context.Entry(bakeryRequest).State = EntityState.Modified;
            _context.SaveChanges();
            return bakeryRequest;

        }

        public BakeryRequest GetBakeryRequest(int id)
        {
            return _context.BakeryRequests
                .AsNoTracking()
                .Include(br => br.Client)
                .Include(br => br.BakeryRequestRecipes).ThenInclude(brr => brr.BakeryRecipe)
                .SingleOrDefault(br => br.Id == id);

        }

        public ICollection<BakeryRequest> GetBakeryRequestByStatus(string status)
        {
            return _context.BakeryRequests.AsNoTracking()
                .Include(br => br.Client)
                .Include(br => br.BakeryRequestRecipes).ThenInclude(brr => brr.BakeryRecipe)
                .Where(br => br.RecipeStatus == status)
                .ToList();
 
        }

        public ICollection<BakeryRequest> GetBakeryRequests()
        {
            //return _context.BakeryRequests.OrderBy(x => x.Id).ToList();
            return _context.BakeryRequests.AsNoTracking()
                .Include(br => br.Client)
                .Include(br => br.BakeryRequestRecipes).ThenInclude(brr => brr.BakeryRecipe)
                .ToList();
        }
    }
}
