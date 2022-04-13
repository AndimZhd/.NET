using CarShop.Interfaces;
using CarShop.Models;

namespace CarShop.Mocks
{
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category {categoryName = "Электромобили", desc = "Современный вид транспорта"}, 
                    new Category {categoryName = "Классические автомобили", desc = "Машины с двигателем внутреннего сгорания"}
                };
            }
        }
    }
}
