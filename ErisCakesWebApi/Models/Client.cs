using Azure.Core;

namespace ErisCakesWebApi.Models
{
    public class Client
    {
        public Client()
        {
            BakeryRequests = new HashSet<BakeryRequest>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; } 
        public string Adress { get; set; }
        public ICollection<BakeryRequest> BakeryRequests { get; set; }

    }
}
