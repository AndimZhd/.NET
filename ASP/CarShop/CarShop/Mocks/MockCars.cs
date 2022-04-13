using CarShop.Interfaces;
using CarShop.Models;

namespace CarShop.Mocks
{
    public class MockCars : IAllCars
    {
        private readonly MockCategory _categoryCars = new MockCategory();
        public IEnumerable<Car> Cars {
            get
            {
                return new List<Car> { 
                    new Car { 
                        name = "Tesla", 
                        shortDesc = "Expensive shit", 
                        longDesc = "", 
                        img = "", 
                        available = true, 
                        price = 120, 
                        isFavorite = true, 
                        category = _categoryCars.AllCategories.First() 
                    },
                    new Car {
                        name = "Lada",
                        shortDesc = "Gavno",
                        longDesc = "",
                        img = "",
                        available = true,
                        price = 120,
                        isFavorite = true,
                        category = _categoryCars.AllCategories.Last()
                    }
                };
            }
        }
        public IEnumerable<Car> getFavouriteCars { get; set; }

        public Car getObjectCar(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
