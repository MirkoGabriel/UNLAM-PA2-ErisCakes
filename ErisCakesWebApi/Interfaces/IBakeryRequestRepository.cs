using ErisCakesWebApi.Models;

namespace ErisCakesWebApi.Interfaces
{
    public interface IBakeryRequestRepository
    {
        ICollection<BakeryRequest> GetBakeryRequests();
        BakeryRequest GetBakeryRequest(int id);
        ICollection<BakeryRequest> GetBakeryRequestByStatus(String status);
        BakeryRequest CreateBakeryRequest(BakeryRequest bakeryRequest);
        BakeryRequest EditBakeryRequest(BakeryRequest bakeryRequest);
        void DeleteBakeryRequest(int id);
    }
}
