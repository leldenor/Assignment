using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Assignment.Data;
using Assignment.Models;

namespace Assignment.Persistence {
public class FileContext : IFamilyService {
    public IList<Family> Families { get; private set; }
    public IList<Adult> Adults { get; private set; }

    private readonly string familiesFile = "families.json";
    private readonly string adultsFile = "adults.json";

    public FileContext() {
        Families = File.Exists(familiesFile) ? ReadData<Family>(familiesFile) : new List<Family>();
        Adults = File.Exists(adultsFile) ? ReadData<Adult>(adultsFile) : new List<Adult>();
    }

    private IList<T> ReadData<T>(string s) {
        using (var jsonReader = File.OpenText(s)) {
            return JsonSerializer.Deserialize<List<T>>(jsonReader.ReadToEnd());
        }
    }

    public void SaveChanges() {
        // storing families
        string jsonFamilies = JsonSerializer.Serialize(Families, new JsonSerializerOptions {
            WriteIndented = true
        });

        using (StreamWriter outputFile = new StreamWriter(familiesFile, false)) {
            outputFile.Write(jsonFamilies);
        }

        // storing persons
        string jsonAdults = JsonSerializer.Serialize(Adults, new JsonSerializerOptions {
            WriteIndented = true
        });

        using (StreamWriter outputFile = new StreamWriter(adultsFile, false)) {
            outputFile.Write(jsonAdults);
        }
    }

    public void AddAdult(Adult adult)
    {
        int max = Adults.Max(adult => adult.Id);
        adult.Id = (++max);
        Adults.Add(adult);
        SaveChanges();
    }

    public IList<Adult> GetAdults()
    {
        return Adults;
    }

    public void RemoveAdult(int personId)
    {
        Adult toRemove = Adults.First(a => a.Id == personId);
        Adults.Remove(toRemove);
        SaveChanges();
    }
}
}