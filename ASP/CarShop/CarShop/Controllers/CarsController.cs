using CarShop.Interfaces;
using CarShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CarShop.Controllers
{
    public class CarsController : Controller
    {
        public readonly IAllCars _AllCars;
        public readonly ICarsCategory _CarsCategory;

        public CarsController(IAllCars allCars, ICarsCategory carsCategory)
        {
            _AllCars = allCars;
            _CarsCategory = carsCategory;
        }
        public ViewResult List()
        {
            CarsListViewModel model = new CarsListViewModel();
            model.allCars = _AllCars.Cars;
            model.currCategory = "Bebra";
            return View(model);
        }
    }
}
