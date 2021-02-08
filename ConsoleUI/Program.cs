using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            BrandTest();
            ColorTest();
            CarTest();
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            Console.WriteLine("--------Color Add--------");
            colorManager.Add(new Color { ColorName = "Red" });
            colorManager.Add(new Color { ColorName = "Grenn" });
            colorManager.Add(new Color { ColorName = "Blue" });
            Console.WriteLine("--------GelAll After Add-------");
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("ID: " + color.ColorId + " // ColorName: " + color.ColorName);
            }
            Console.WriteLine("--------Color Delete--------");
            colorManager.Delete(new Color { ColorId = 4, ColorName = "Blue" });
            Console.WriteLine("--------GelAll After Delete--------");
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("ID: " + color.ColorId + " // ColorName: " + color.ColorName);
            }
            Console.WriteLine("--------Color Update--------");
            colorManager.Update(new Color { ColorId = 3, ColorName = "Blue" });
            Console.WriteLine("--------GelAll After Update--------");
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("ID: " + color.ColorId + " // ColorName: " + color.ColorName);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            Console.WriteLine("--------Brand Add--------");
            brandManager.Add(new Brand { BrandName = "BMW" });
            brandManager.Add(new Brand { BrandName = "Opel" });
            brandManager.Add(new Brand { BrandName = "Mercedes" });
            Console.WriteLine("--------GelAll After Add-------");
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine("ID: " + brand.BrandId + " // BrandName: " + brand.BrandName);
            }
            Console.WriteLine("--------Brand Delete--------");
            brandManager.Delete(new Brand { BrandId = 15, BrandName = "Mercedes" });
            Console.WriteLine("--------GelAll After Delete--------");
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine("ID: " + brand.BrandId + " // BrandName: " + brand.BrandName);
            }
            Console.WriteLine("--------Brand Update--------");
            brandManager.Update(new Brand { BrandId = 14, BrandName = "Mercedes" });
            Console.WriteLine("--------GelAll After Update--------");
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine("ID: " + brand.BrandId + " // BrandName: " + brand.BrandName);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Console.WriteLine("--------Car Add--------");
            carManager.Add(new Car { BrandId = 13, ColorId = 3, DailyPrice = 320000, Description = "FFF", ModelYear = 2019 });
            carManager.Add(new Car { BrandId = 14, ColorId = 2, DailyPrice = 32000, Description = "FFF2", ModelYear = 2020 });
            carManager.Add(new Car { BrandId = 14, ColorId = 2, DailyPrice = 350000, Description = "FFF3", ModelYear = 2021 });
            Console.WriteLine("--------GelAll After Add-------");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("ID: " + car.Id + " // MarkaId: " + car.BrandId + " // RenkId: " + car.ColorId + " // Fiyat: " + car.DailyPrice + " // Model: " + car.ModelYear + " // Açıklama: " + car.Description);
            }
            Console.WriteLine("--------Car Delete--------");
            carManager.Delete(new Car { Id = 1008, BrandId = 14, ColorId = 2, DailyPrice = 350000, Description = "FFF3", ModelYear = 2021 });
            Console.WriteLine("--------GelAll After Delete--------");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("ID: " + car.Id + " // MarkaId: " + car.BrandId + " // RenkId: " + car.ColorId + " // Fiyat: " + car.DailyPrice + " // Model: " + car.ModelYear + " // Açıklama: " + car.Description);
            }
            Console.WriteLine("--------Car Update--------");
            carManager.Update(new Car { Id = 1007, BrandId = 14, ColorId = 2, DailyPrice = 32000, Description = "FFF2", ModelYear = 2021 });
            Console.WriteLine("--------GelAll After Update--------");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("ID: " + car.Id + " // MarkaId: " + car.BrandId + " // RenkId: " + car.ColorId + " // Fiyat: " + car.DailyPrice + " // Model: " + car.ModelYear + " // Açıklama: " + car.Description);
            }
            Console.WriteLine("--------GetAllByBrand--------");
            foreach (var car in carManager.GetCarsByBrandId(13))
            {
                Console.WriteLine("ID: " + car.Id + " // MarkaId: " + car.BrandId + " // RenkId: " + car.ColorId + " // Fiyat: " + car.DailyPrice + " // Model: " + car.ModelYear + " // Açıklama: " + car.Description);
            }
            Console.WriteLine("--------GetAllByColor--------");
            foreach (var car in carManager.GetCarsByColorId(2))
            {
                Console.WriteLine("ID: " + car.Id + " // MarkaId: " + car.BrandId + " // RenkId: " + car.ColorId + " // Fiyat: " + car.DailyPrice + " // Model: " + car.ModelYear + " // Açıklama: " + car.Description);
            }
            Console.WriteLine("--------GetAllByCarDTO--------");
            foreach (var car in carManager.GetCars())
            {
                Console.WriteLine("ID: " + car.Id + " // MarkaId: " + car.BrandName + " // RenkId: " + car.ColorName + " // Fiyat: " + car.DailyPrice);
            }
        }
    }
}
