namespace PizzaComponents.Models;

public class PizzaAssets
{
    // TODO 3: asset path in class libraries
    public const string LibPath = "/_content/pizzacomponents/";

    // TODO 2: C# 10 const in const
    public const string Placeholder = $"{LibPath}images/placeholder.png";
    public const string ProfitCatcher = $"{LibPath}images/profitcatcher.png";

    public const string Caprese = $"{LibPath}images/caprese.png";
    public const string Funghi = $"{LibPath}images/funghi.png";
    public const string Margherita = $"{LibPath}images/margherita.png";
    public const string Mozzarella = $"{LibPath}images/mozzarella.png";
    public const string Salame = $"{LibPath}images/salame.png";

    public static string GetImage(string? name)
    {
        if (name == null) return Placeholder;
        // TODO: discuss where to define image
        switch (name)
        {
            case nameof(Margherita):
                return Margherita;
            case nameof(Caprese):
                return Caprese;
            case nameof(Funghi):
                return Funghi;
            case nameof(Mozzarella):
                return Mozzarella;
            case nameof(Salame):
                return Salame;
            default:
                return Placeholder;
        }
    }

    // Pictures: https://www.slicepizzeria.com/american-pizza/
}