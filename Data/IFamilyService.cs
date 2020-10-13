using System.Collections.Generic;
using Assignment.Models;

namespace Assignment.Data
{
    public interface IFamilyService
    {
        void AddAdult(Adult adult);
        IList<Adult> GetAdults();
        void RemoveAdult(int personId);
        

    }
}