using ErisCakesWebApi.Models;

namespace ErisCakesWebApi.Interfaces
{
    public interface IClientsRepository
    {
        ICollection<Client> GetClients();
        Client GetClient(int id);
        Client CreateClient(Client client);
    }
}
