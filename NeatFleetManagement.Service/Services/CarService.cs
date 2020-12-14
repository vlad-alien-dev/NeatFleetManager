using AutoMapper;
using NeatFleetManagement.Utils;
using NeatFleetManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeatFleetManagement.Service
{
    public class CarService : ICarService
    {
        private readonly IRepository<Car> carRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private IEnumerable<CarServiceModel> cars;

        public CarService(IRepository<Car> carRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.carRepository = carRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.cars = new List<CarServiceModel>();
        }
        public void CreateCar(CarServiceModel carModel)
        {
            Car car = this.mapper.Map<Car>(carModel);
            this.carRepository.Add(car);
        }

        public CarServiceModel GetCar(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CarServiceModel> GetAllCars()
        {
            IEnumerable<Car> cars = this.carRepository.GetAll();
            this.cars = this.mapper.Map<List<CarServiceModel>>(cars);

            return this.cars;
        }
        public IEnumerable<CarServiceModel> GetCarsByUserId(string userId)
        {
            IEnumerable<Car> cars = this.carRepository.GetMany(c => c.OwnerId == userId);
            this.cars = this.mapper.Map<List<CarServiceModel>>(cars);

            return this.cars;
        }

        public decimal AveragePrice()
        {
            if (this.cars.Count() <= 0)
            {
                return 0;
            }
            var ave = this.cars.Average(x => x.Price);

            return ave;

        }
        public Dictionary<string, double> ColorsProportion()
        {
            var defaultColors = new List<string>(){"Red", "Yellow", "Green"};
            var colorPercentage = this.cars.GroupBy(c => c.Color)
                        .Select(group => new
                        {
                            ColorName = group.Key.ToString(),
                            Percentage = Convert.ToDouble(group.Count()) / Convert.ToDouble(this.cars.Count()) * 100
                        }).
                        ToDictionary(item => item.ColorName, item => item.Percentage);
            foreach (var color in defaultColors)
            {
                if (!colorPercentage.ContainsKey(color))
                {
                    colorPercentage.Add(color, 0);
                }
            }
            return colorPercentage;
        }

        public double NewCarsProportion()
        {
            if (this.cars.Count() <= 0)
            {
                return 0;
            }
            var newCarsProportion = Convert.ToDouble(this.cars.Count(c => c.Condition == CarCondition.New))
                                   / Convert.ToDouble(this.cars.Count())
                                   * 100;
            return newCarsProportion;
        }
        public void Save()
        {
            this.unitOfWork.Commit();
        }
    }
}
