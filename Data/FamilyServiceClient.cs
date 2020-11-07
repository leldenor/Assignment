using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Assignment.Models;

namespace Assignment.Data
{
    public class FamilyServiceClient : IFamilyService
    {
        private readonly HttpClient client;

        public FamilyServiceClient()
        {
            client = new HttpClient();
        }

        public async Task AddAdultAsync(Adult adult)
        {
            throw new System.NotImplementedException();
        }

        public async Task RemoveAdultAsync(int personId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IList<Family>> GetFamiliesAsync()
        {
            string message = await client.GetStringAsync("http://dnp.metamate.me/Families");
            IList<Family> result = JsonSerializer.Deserialize<List<Family>>(message);
           
            return result;
        }

        public Family Family { get; set; }
        public async Task RemoveFamilyAsync(int HouseNumber, string StreetName)
        {
            await client.DeleteAsync($"http://dnp.metamate.me/Families/{HouseNumber}&{StreetName}");
        }

        public async Task AddFamilyAsync(Family family)
        {
            string familySerialized = JsonSerializer.Serialize(family);
            HttpContent content=new StringContent(
                familySerialized,
                Encoding.UTF8,
                "application/json"
                );
        }

        public async Task RemoveChildAsync(int childId)
        {
            throw new System.NotImplementedException();
        }

        public async Task RemoveChildPetAsync(int petId)
        {
            throw new System.NotImplementedException();
        }

        public async Task RemovePetAsync(int petId)
        {
            throw new System.NotImplementedException();
        }

        public async Task AddChildAsync(Child child)
        {
            throw new System.NotImplementedException();
        }

        public async Task AddPetAsync(Pet pet)
        {
            throw new System.NotImplementedException();
        }
    }
}