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

        public BakeryRequest GetBakeryRequest(int id)
        {
            return _context.BakeryRequests.Where(br => br.Id == id).Include(c => c.Client).FirstOrDefault();
        }

        public ICollection<BakeryRequest> GetBakeryRequests()
        {
            return _context.BakeryRequests.OrderBy(x => x.Id).ToList();
        }
    }
}
