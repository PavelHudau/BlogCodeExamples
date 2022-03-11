namespace Builder;

public class Coffee
{
    public DrinkType DrinkType { get; set; }
    
    public CupSize CupSize { get; set; }
    
    public bool IsDairyFree { get; set; }
    
    public bool HasSugar { get; set; }

    public ICollection<Flavor> Flavors { get; } = new List<Flavor>();

    public double TotalCalories { get; set; }
}