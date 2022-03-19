namespace Builder;

public class CoffeeBuilderFluent
{
    private readonly CupSize _cupSize;
    private readonly DrinkType _drinkType;
    private double _spoonsOfSugar ;
    private double _milkOz;
    private double _mapleSyrupOz;
    private double _vanillaOz;

    public CoffeeBuilderFluent(CupSize cupSize, DrinkType drinkType)
    {
        _cupSize = cupSize;
        _drinkType = drinkType;
    }

    public CoffeeBuilderFluent AddSugar(double spoons)
    {
        _spoonsOfSugar += spoons;
        return this;
    }

    public CoffeeBuilderFluent AddMilk(double oz)
    {
        _milkOz += oz;
        return this;
    }
    
    public CoffeeBuilderFluent AddMapleSyrup(double oz)
    {
        _mapleSyrupOz += oz;
        return this;
    }
    
    public CoffeeBuilderFluent AddVanilla(double oz)
    {
        _vanillaOz += oz;
        return this;
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