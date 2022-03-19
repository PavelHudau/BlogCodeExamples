namespace Builder;

public class CoffeeBuilder
{
    private readonly CupSize _cupSize;
    private readonly DrinkType _drinkType;
    private double _spoonsOfSugar ;
    private double _milkOz;
    private double _mapleSyrupOz;
    private double _vanillaOz;

    public CoffeeBuilder(CupSize cupSize, DrinkType drinkType)
    {
        _cupSize = cupSize;
        _drinkType = drinkType;
    }

    public void AddSugar(double spoons)
    {
        _spoonsOfSugar += spoons;
    }

    public void AddMilk(double oz)
    {
        _milkOz += oz;
    }
    
    public void AddMapleSyrup(double oz)
    {
        _mapleSyrupOz += oz;
    }
    
    public void AddVanilla(double oz)
    {
        _vanillaOz += oz;
    }

    public Coffee Build()
    {
        Coffee coffee = new()
        {
            CupSize = _cupSize,
            DrinkType = _drinkType,
            HasSugar = _spoonsOfSugar > 0 || _mapleSyrupOz > 0,
            IsDairyFree = _milkOz == 0 && _drinkType != DrinkType.Latte,
            TotalCalories = CalculateTotalCalories(),
        };
        
        if (_vanillaOz > 0)
        {
            coffee.Flavors.Add(Flavor.Vanilla);
        }

        return coffee;
    }

    private double CalculateTotalCalories()
    {
        // Calories calculation formula.
        return 0;
    }
}