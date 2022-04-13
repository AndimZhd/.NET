using CarShop.Models;

namespace CarShop.Interfaces
{
    public interface IAllCars
    {
        IEnumerable<Car> Cars { get;}
        IEnumerable<Car> getFavouriteCars { get; set; }
        Car getObjectCar(int carId);
    }
}
