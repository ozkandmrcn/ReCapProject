using Business.Concrete;
using Entities.Concrete;
using DataAccess.Concrete.InMemory;

using System;
using DataAccess.Concrete.EntityFrameWork;
using System.Linq;
using System.Collections.Generic;
using DataAccess.Concrete;
using ConsoleTables;

namespace ConsoleUI
{
    class Program
    {

       // static int indexMainMenu = 0;
        static void Main(string[] args)
        {


            CarManager carManager = new CarManager(new EfCarDal());

            //CarTest(carManager);

            Console.WriteLine("***EF Database'de olan arabalar CarDetailsDto'ya göre gösterildi***");
            //CarGetAll(carManager);
            Console.WriteLine(carManager.GetAll().Message);

            Console.WriteLine("\n***BrandId'a göre ve ColorId'ye göre getirme****");
            Console.WriteLine("*color'a göre");
            //CarGetByColorId(carManager);
            Console.WriteLine(carManager.GetCarsByColorId(1).Message);
            Console.WriteLine("*brand'a göre");
            //CarGetByBrandId(carManager);
            Console.WriteLine(carManager.GetCarsByBrandId(1).Message);

            BrandManager brandManager = new BrandManager(new EfBrandDal());

            //BrandAddTest(brandManager);

            Console.WriteLine("\n***Marka Listesi***");
            GetBrands(brandManager);
            Console.WriteLine(brandManager.GetAll().Message);

            ColorManager colorManager = new ColorManager(new EfColorDal());

            //ColorAddTest(colorManager);

            Console.WriteLine("\n***Renk Listesi***");
            GetColors(colorManager);
            Console.WriteLine(colorManager.GetAll().Message);

            Console.WriteLine("\n***Kullanıcılar Oluşturuldu***");

            UserManager userManager = new UserManager(new EfUserDal());
            //UsersTest(userManager);
            Console.WriteLine(userManager.GetAll().Message);

            Console.WriteLine("\n***Müşteriler Oluşturuldu***");

            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            //CustomersTest(customerManager);
            Console.WriteLine(customerManager.GetAll().Message);

            Console.WriteLine("\n***Kiralama Oluşturuldu***");

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            RentalsTest(rentalManager);

            foreach (var rental in rentalManager.GetAllRentalDetail().Data)
            {
                Console.WriteLine("rentalid:" + rental.RentalId + " - car description:" + rental.CarName + " - company name:" + rental.CustomerName + " - rentdate:" + rental.RentDate + " - returndate:" + rental.ReturnDate);
            }


        }

        private static void RentalsTest(RentalManager rentalManager)
        {
            Rental rental1 = new Rental() { Id = 1, CarId = 2, CustomerId = 1, RentDate = DateTime.Now };
            Rental rental2 = new Rental() { Id = 1, CarId = 2, CustomerId = 1, RentDate = DateTime.Now };
            Rental rental3 = new Rental() { Id = 2, CarId = 3, CustomerId = 1, RentDate = DateTime.Now };
            Rental rental4 = new Rental() { Id = 3, CarId = 3, CustomerId = 1, RentDate = DateTime.Now, ReturnDate = DateTime.Today };
            Rental rental5 = new Rental() { Id = 4, CarId = 6, CustomerId = 2, RentDate = DateTime.Now };
            rentalManager.Add(rental5);
        }

        private static void CustomersTest(CustomerManager customerManager)
        {
            Customer customer1 = new Customer() { CustomerId = 1, UserId = 1, CompanyName = "volkan şirketi" };
            Customer customer2 = new Customer() { CustomerId = 2, UserId = 2, CompanyName = "ali şirketi" };
            customerManager.Add(customer2);
        }

        private static void UsersTest(UserManager userManager)
        {
            User user1 = new User() { UserId = 1,FirstName = "volkan", LastName = "karaali", Email = "mail@mail.com", Password = "v123" };
            User user2 = new User() { UserId = 2, FirstName = "ali" ,LastName = "veli", Email = "mail1@mail.com", Password = "1234" };
            userManager.Add(user2);
        }

        private static void GetColors(ColorManager colorManager)
        {
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void GetBrands(BrandManager brandManager)
        {
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void CarGetAll(CarManager carManager)
        {
            foreach (var car in carManager.GetCarDetailDto().Data)
            {

                Console.WriteLine("id={0} - {1} marka, {2} renk, aciklama: {3}", car.CarId, car.BrandName, car.ColorName, car.DailPrice);
            }
        }

        private static void CarGetByBrandId(CarManager carManager)
        {
            foreach (var car in carManager.GetCarsByBrandId(1).Data)
            {
                Console.WriteLine("Brand {0} olan araba verisinin fiyati: {1} ve aciklama: {2}", car.BrandId, car.DailyPrice, car.Description);
            }
        }

        private static void CarGetByColorId(CarManager carManager)
        {
            foreach (var car in carManager.GetCarsByColorId(1).Data)
            {
                Console.WriteLine("Color {0} olan araba verisinin fiyati: {1} ve aciklama: {2}", car.ColorId, car.DailyPrice, car.Description);
            }
        }

    }
}

