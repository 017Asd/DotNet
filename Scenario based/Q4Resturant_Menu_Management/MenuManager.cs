using System;
namespace ResturantMenuManagement
{
    public class MenuManager
    {
        private List<MenuItem> menuItems = new();
        public void AddMenuItem(string name, string category, double price, bool isVeg)
        {
            if (price <= 0)
                throw new ArgumentException("Price must be greater than zero");

            menuItems.Add(new MenuItem(name, category, price, isVeg));
        }
        public Dictionary<string, List<MenuItem>> GroupItemsByCategory()
        {
            Dictionary<string, List<MenuItem>> result = new();

            foreach (var item in menuItems)
            {
                if (!result.ContainsKey(item.Category))
                    result[item.Category] = new List<MenuItem>();

                result[item.Category].Add(item);
            }

            return result;
        }

        public List<MenuItem> GetVegetarianItems()
        {
            List<MenuItem> vegItems = new();

            foreach (var item in menuItems)
            {
                if (item.IsVegetarian)
                    vegItems.Add(item);
            }

            return vegItems;
        }

        public double CalculateAveragePriceByCategory(string category)
        {
            double total = 0;
            int count = 0;

            foreach (var item in menuItems)
            {
                if (item.Category == category)
                {
                    total += item.Price;
                    count++;
                }
            }

            return count == 0 ? 0 : total / count;
        }
    }


}