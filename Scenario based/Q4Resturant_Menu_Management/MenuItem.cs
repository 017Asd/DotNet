using System;
namespace ResturantMenuManagement
{
    public class MenuItem
{
    public string ItemName { get; }
    public string Category { get; }
    public double Price { get; }
    public bool IsVegetarian { get; }

    public MenuItem(string itemName, string category, double price, bool isVegetarian)
    {
        ItemName = itemName;
        Category = category;
        Price = price;
        IsVegetarian = isVegetarian;
    }
}

}