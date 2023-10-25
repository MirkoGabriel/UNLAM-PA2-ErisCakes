using ErisCakesWebApi.Data;
using ErisCakesWebApi.Interfaces;
using ErisCakesWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ErisCakesWebApi.Repository
{
    public class ClientsRepository : IClientsRepository
    {
        private readonly DataContext _context;
        public ClientsRepository(DataContext context)
        {
            _context = context;
        }

        public Client GetClient(int id)
        {
            return _context.Clients.Where(c => c.Id == id).FirstOrDefault();
        }

        public ICollection<Client> GetClients()
        {
            return _context.Clients.OrderBy(x => x.Id).ToList();
        }

        public Client CreateClient(Client client)
        {
            _context.Add(client);
            _context.SaveChanges();

            return client;
        }

        public Client EditClient(Client client)
        {
            _context.Entry(client).State = EntityState.Modified;
            _context.SaveChanges();
            return client;

        }

        public void DeleteClient(int id)
        {
            var client = _context.Clients.Find(id);
            _context.Remove(client);
            _context.SaveChanges();
        }
    }
}
