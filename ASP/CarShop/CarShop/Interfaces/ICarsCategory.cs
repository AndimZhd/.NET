using CarShop.Models;

namespace CarShop.Interfaces
{ 
    public interface ICarsCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
