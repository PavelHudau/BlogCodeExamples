namespace Builder;

public static class UsingBuilder
{
    public static void UsingBuilderExample()
    {
        // Configuration Phase
        var builder = new CoffeeBuilder(CupSize.Medium, DrinkType.Latte);
        builder.AddMilk(2);
        builder.AddSugar(1);
        builder.AddVanilla(3);
        builder.AddSugar(-1); // ← Customer changed mind, removing sugar
        builder.AddMapleSyrup(2); // ← Adding Maple Syrup instead

        // Build Phase
        var coffee = builder.Build();
        
        // Use Phase
        Console.Write($"Got my {coffee.DrinkType} coffee!");
    }
    
    public static void UsingFluentBuilderExample()
    {
        var coffee = new CoffeeBuilderFluent(CupSize.Medium, DrinkType.Latte)
            .AddMilk(2) // ← Configuration Phase
            .AddSugar(1)
            .AddVanilla(3)
            .AddSugar(-1)
            .AddMapleSyrup(2)
            .Build(); // ← Build Phase

        // Use Phase
        Console.Write($"Got my {coffee.DrinkType} coffee!");
    }
}