using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Assignment.Models {
public class Family {
    
    //public int Id { get; set; }
    [Required]
    [JsonPropertyName("streetName")]
    public string StreetName { get; set; }
    [Required]
    [JsonPropertyName("houseNumber")]
    public int HouseNumber{ get; set; }
    public List<Adult> Adults { get; set; }
    public List<Child> Children{ get; set; }
    public List<Pet> Pets{ get; set; }

    public Family() {
        Adults = new List<Adult>();
        Children=new List<Child>();
        Pets=new List<Pet>();
    }

}


}