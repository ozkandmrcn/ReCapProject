using Business.Concrete;
using Entities.Concrete;
using DataAccess.Concrete.InMemory;

using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            CarManager carManager = new CarManager(new InMemoryCarDal());

            Car car = new Car() { Id = 8, BrandId = 2, ColorId = 3, DailyPrice = 10000, Description = "Aile Arabası", ModelYear = "2018" };
            Car car1 = new Car() { Id = 1, BrandId = 2, ColorId = 3, DailyPrice = 111000, Description = "Temiz", ModelYear = "2020" };

            carManager.Add(car);
            carManager.Delete(car);
            carManager.GetAll();
            carManager.GetById(1);
            carManager.Update(car1);

            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine("Id : "+item.Id);
                Console.WriteLine("MarkaId :"+item.BrandId);
                Console.WriteLine("RenkId :"+item.ColorId);

                Console.WriteLine("Fiyat :"+item.DailyPrice);
                Console.WriteLine("Acıklama :"+item.Description);
                Console.WriteLine("Model:"+item.ModelYear);

                Console.WriteLine("--------------------");


            }
           
           
            

            Console.ReadLine();

        }
    }
}

