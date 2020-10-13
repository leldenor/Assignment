using System.ComponentModel.DataAnnotations;

namespace Assignment.Models {
public class Pet {
    public int Id { get; set; }
    [Required]
    public string Species { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public int Age { get; set; }
}
}