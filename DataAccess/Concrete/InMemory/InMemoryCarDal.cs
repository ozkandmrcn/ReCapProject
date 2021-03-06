﻿using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
   public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {

            _cars = new List<Car> {
                new Car{Id=1,BrandId=1,ColorId=1,DailyPrice=45000,ModelYear=1970,Description="Temiz kullanılmış"},
                new Car{Id=2,BrandId=1,ColorId=4,DailyPrice=65000,ModelYear=2013,Description="15.000 km de"},
                new Car{Id=3,BrandId=3,ColorId=2,DailyPrice=67890,ModelYear=2018,Description="Öğretmenden satılık"},
                new Car{Id=4,BrandId=2,ColorId=3,DailyPrice=54678,ModelYear=2006,Description="Aile arabası"},
                new Car{Id=5,BrandId=4,ColorId=1,DailyPrice=234000,ModelYear=2017,Description="Temiz kullanılmış"},
                new Car{Id=6,BrandId=4,ColorId=3,DailyPrice=123890,ModelYear=2009,Description="Temiz kullanılmış"},
                new Car{Id=7,BrandId=2,ColorId=2,DailyPrice=345750,ModelYear=2020,Description="Temiz kullanılmış"}
            };
        }
            

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car cartodelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(cartodelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int CarId)
        {
            var ListedId = _cars.Where(c => c.Id == CarId).ToList();
            return ListedId;
        }

        public List<CarDetailDto> GetCarDetailDtos()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
        }
    }
}
