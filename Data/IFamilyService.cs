using System.Collections.Generic;
using Assignment.Models;

namespace Assignment.Data
{
    public interface IFamilyService
    {
        void AddAdult(Adult adult);
        void RemoveAdult(int personId);
        IList<Family> GetFamilies();
        Family Family { get; set; }
        void RemoveFamily(int HouseNumber, string StreetName);
        void AddFamily(Family family);
        void RemoveChild(int childId);
        void RemoveChildPet(int petId);
        void RemovePet(int petId);
        void AddChild(Child child);
        void AddPet(Pet pet);
    }
}