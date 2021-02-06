using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal ıcarDal)
        {
            _carDal = ıcarDal;
        }

        public void Add(Car car)
        {
            if (car.DailyPrice > 0)
            {
                _carDal.Add(car);
                Console.WriteLine("Arac Sisteme basariyla eklendi.");
            }
            else
            {
                Console.WriteLine("Lutfen aracin gunluk kirasini sifirdan buyuk bir deger giriniz.");
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
            Console.WriteLine("Araba sistemden basariyla silindi.");
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public Car GetById(int id)
        {
            return _carDal.Get(c => c.Id == id);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
            Console.WriteLine("Araba sistemde basariyla guncellendi.");
        }

        List<Car> ICarService.GetById(int CarId)
        {
            throw new NotImplementedException();
        }
    }
}
