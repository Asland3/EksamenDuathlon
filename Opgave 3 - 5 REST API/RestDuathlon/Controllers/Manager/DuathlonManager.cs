using RestDuathlon.Controllers.Models;

namespace RestDuathlon.Controllers.Manager;

public class DuathlonManager
{
    private static int Bib = 100;

    private static List<DuathlonData> data = new List<DuathlonData>()
    {
        new DuathlonData() {Bib = Bib++, Name = "Eddy Quick Feet", AgeGroup = 4, Bike = 7200, Run = 2100, Total = 9300},
        new DuathlonData() {Bib = Bib++, Name = "Heavy Peter", AgeGroup = 3, Bike = 7520, Run = 2100, Total = 9300},
        new DuathlonData() {Bib = Bib++, Name = "Big Mike", AgeGroup = 2, Bike = 7350, Run = 2390, Total = 9740},
        new DuathlonData() {Bib = Bib++, Name = "Fat Joey", AgeGroup = 4, Bike = 8256, Run = 2676, Total = 10932},
        new DuathlonData() {Bib = Bib++, Name = "Magic Thomson", AgeGroup = 1, Bike = 6475, Run = 2025, Total = 8500}
    };

    public List<DuathlonData> GetAll(string? nameFilter, int? ageGroupFilter, int? bikeFilter, int? runFilter)
    {
        List<DuathlonData> result = new List<DuathlonData>(data);
        
        if (!string.IsNullOrWhiteSpace(nameFilter))
        {
            result = result.FindAll(duathlonFilter =>
                duathlonFilter.Name.Contains(nameFilter, StringComparison.OrdinalIgnoreCase));
        }
        
        if (ageGroupFilter != null)
        {
            result = result.FindAll(duathlonFilter => duathlonFilter.AgeGroup == ageGroupFilter);
        }
        
        if (bikeFilter != null)
        {
            result = result.FindAll(duathlonFilter => duathlonFilter.Bike == bikeFilter);
        }
        
        if (runFilter != null)
        {
            result = result.FindAll(duathlonFilter => duathlonFilter.Run == runFilter);
        }

        return result; 
    }
    
    public DuathlonData GetByBib(int bib)
    {
        return data.Find(Duathlon => Duathlon.Bib == bib);
    }
    
    public DuathlonData Add(DuathlonData newDuathlon)
    {
        newDuathlon.Bib = Bib++;
        data.Add(newDuathlon);
        return newDuathlon;
    }
    
    public DuathlonData Delete(int bib)
    {
        DuathlonData duathlon = data.Find(duathlon =>  duathlon.Bib == bib);
        if (duathlon == null) return null;
        data.Remove(duathlon);
        return duathlon;
    }
    
    public DuathlonData Update(int id, DuathlonData updates)
    {
        DuathlonData duathlon = data.Find(duathlon => duathlon.Bib == Bib);
        if (duathlon == null) return null;
        duathlon.Name = updates.Name;
        duathlon.AgeGroup = updates.AgeGroup;
        duathlon.Bike = updates.Bike;
        duathlon.Run = updates.Run;
        return duathlon;
    }
}