using ErisCakesWebApi.Models;

namespace ErisCakesWebApi.Interfaces
{
    public interface IBakeryRequestRepository
    {
        ICollection<BakeryRequest> GetBakeryRequests();
        BakeryRequest GetBakeryRequest(int id);
        BakeryRequest CreateBakeryRequest(BakeryRequest bakeryRequest);
    }
}
