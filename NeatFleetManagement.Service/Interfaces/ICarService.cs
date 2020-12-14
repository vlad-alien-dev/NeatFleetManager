using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeatFleetManagement.Service
{
    public interface ICarService
    {
        IEnumerable<CarServiceModel> GetAllCars();
        IEnumerable<CarServiceModel> GetCarsByUserId(string userId);
        CarServiceModel GetCar(int id);
        void CreateCar(CarServiceModel car);
        decimal AveragePrice();
        double NewCarsProportion();
        Dictionary<string, double> ColorsProportion();

        void Save();
    }
}
