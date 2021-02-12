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
            var cOpe = colorManager.Add(new Color { ColorName = "Black" });
            Console.WriteLine(cOpe.Message);

            Console.WriteLine("--------GelAll After Add-------");
            var cList = colorManager.GetAll();
            if (cList.Success)
            {
                foreach (var color in cList.Data)
                {
                    Console.WriteLine("ID: " + color.ColorId + " // ColorName: " + color.ColorName);
                }
                Console.WriteLine(cList.Message);
            }
            else
            {
                Console.WriteLine(cList.Message);
            }

            //Console.WriteLine("--------Color Delete--------");
            //var cOpe2 = colorManager.Delete(new Color { ColorId = 4, ColorName = "Blue" });
            //Console.WriteLine(cOpe2.Message);

            Console.WriteLine("--------Color Update--------");
            var cOpe3 = colorManager.Update(new Color { ColorId = 3, ColorName = "Blue" });
            Console.WriteLine(cOpe3.Message);

            Console.WriteLine("--------GelAll After Delete and Update-------");
            var cList2 = colorManager.GetAll();
            if (cList2.Success)
            {
                foreach (var color in cList2.Data)
                {
                    Console.WriteLine("ID: " + color.ColorId + " // ColorName: " + color.ColorName);
                }
                Console.WriteLine(cList2.Message);
            }
            else
            {
                Console.WriteLine(cList2.Message);
            }

            Console.WriteLine("--------GelById-------");
            var cList3 = colorManager.GetById(3);
            if (cList3.Success)
            {
                Console.WriteLine(cList3.Data.ColorId + " // " + cList3.Data.ColorName);
                Console.WriteLine(cList3.Message);
            }
            else
            {
                Console.WriteLine(cList3.Message);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            Console.WriteLine("--------Brand Add--------");
            var bOpe = brandManager.Add(new Brand { BrandName = "Nissan" });
            Console.WriteLine(bOpe.Message);

            Console.WriteLine("--------GelAll After Add-------");
            var bList = brandManager.GetAll();
            if (bList.Success)
            {
                foreach (var brand in bList.Data)
                {
                    Console.WriteLine("ID: " + brand.BrandId + " // BrandName: " + brand.BrandName);
                }
                Console.WriteLine(bList.Message);
            }
            else
            {
                Console.WriteLine(bList.Message);
            }
            
            //Console.WriteLine("--------Brand Delete--------");
            //var bOpe2 = brandManager.Delete(new Brand { BrandId = 15, BrandName = "Mercedes" });
            //Console.WriteLine(bOpe2.Message);

            Console.WriteLine("--------Brand Update--------");
            var bOpe3 = brandManager.Update(new Brand { BrandId = 14, BrandName = "Mercedes" });
            Console.WriteLine(bOpe3.Message);

            Console.WriteLine("--------GelAll After Update and Delete--------");
            var bList2 = brandManager.GetAll();
            if (bList2.Success)
            {
                foreach (var brand in bList2.Data)
                {
                    Console.WriteLine("ID: " + brand.BrandId + " // BrandName: " + brand.BrandName);
                }
                Console.WriteLine(bList2.Message);
            }
            else
            {
                Console.WriteLine(bList2.Message);
            }

            Console.WriteLine("--------GelById-------");
            var bList3 = brandManager.GetById(13);
            if (bList3.Success)
            {
                Console.WriteLine(bList3.Data.BrandId + " // " + bList3.Data.BrandName);
                Console.WriteLine(bList3.Message);
            }
            else
            {
                Console.WriteLine(bList3.Message);
            }

        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Console.WriteLine("--------Car Add--------");
            var caOpe = carManager.Add(new Car { BrandId = 13, ColorId = 3, DailyPrice = 22000, Description = "FUU", ModelYear = 2005 });
            Console.WriteLine(caOpe.Message);

            Console.WriteLine("--------GelAll After Add-------");
            var caList = carManager.GetAll();
            if (caList.Success)
            {
                foreach (var car in caList.Data)
                {
                    Console.WriteLine("ID: " + car.Id + " // MarkaId: " + car.BrandId + " // RenkId: " + car.ColorId + " // Fiyat: " + car.DailyPrice + " // Model: " + car.ModelYear + " // Açıklama: " + car.Description);
                }
                Console.WriteLine(caList.Message);
            }
            else
            {
                Console.WriteLine(caList.Message);
            }

            //Console.WriteLine("--------Car Delete--------");
            //var caOpe2 = carManager.Delete(new Car { Id = 1008, BrandId = 14, ColorId = 2, DailyPrice = 350000, Description = "FFF3", ModelYear = 2021 });
            //Console.WriteLine(caOpe2.Message);

            Console.WriteLine("--------Car Update--------");
            var cOpe3 = carManager.Update(new Car { Id = 1007, BrandId = 14, ColorId = 2, DailyPrice = 32000, Description = "FFF2", ModelYear = 2021 });
            Console.WriteLine(cOpe3.Message); 

            Console.WriteLine("--------GelAll After Update--------");
            var caList2 = carManager.GetAll();
            if (caList2.Success)
            {
                foreach (var car in caList2.Data)
                {
                    Console.WriteLine("ID: " + car.Id + " // MarkaId: " + car.BrandId + " // RenkId: " + car.ColorId + " // Fiyat: " + car.DailyPrice + " // Model: " + car.ModelYear + " // Açıklama: " + car.Description);
                }
                Console.WriteLine(caList2.Message);
            }
            else
            {
                Console.WriteLine(caList2.Message);
            }

            Console.WriteLine("--------GetAllByBrand--------");
            var caList3 = carManager.GetCarsByBrandId(13);
            if (caList3.Success)
            {
                foreach (var car in caList3.Data)
                {
                    Console.WriteLine("ID: " + car.Id + " // MarkaId: " + car.BrandId + " // RenkId: " + car.ColorId + " // Fiyat: " + car.DailyPrice + " // Model: " + car.ModelYear + " // Açıklama: " + car.Description);
                }
                Console.WriteLine(caList3.Message);
            }
            else
            {
                Console.WriteLine(caList3.Message);
            }

            Console.WriteLine("--------GetAllByColor--------");
            var caList4 = carManager.GetCarsByColorId(2);
            if (caList4.Success)
            {
                foreach (var car in caList4.Data)
                {
                    Console.WriteLine("ID: " + car.Id + " // MarkaId: " + car.BrandId + " // RenkId: " + car.ColorId + " // Fiyat: " + car.DailyPrice + " // Model: " + car.ModelYear + " // Açıklama: " + car.Description);
                }
                Console.WriteLine(caList4.Message);
            }
            else
            {
                Console.WriteLine(caList4.Message);
            }

            Console.WriteLine("--------GetAllByCarDTO--------");
            var caList5 = carManager.GetCars();
            if (caList5.Success)
            {
                foreach (var car in caList5.Data)
                {
                    Console.WriteLine("ID: " + car.Id + " // MarkaId: " + car.BrandName + " // RenkId: " + car.ColorName + " // Fiyat: " + car.DailyPrice);
                }
                Console.WriteLine(caList5.Message);
            }
            else
            {
                Console.WriteLine(caList5.Message);
            }

            Console.WriteLine("--------GetById--------");
            var caList6 = carManager.GetById(1007);
            if (caList6.Success)
            {
                Console.WriteLine("ID: " + caList6.Data.Id + " // MarkaId: " + caList6.Data.BrandId + " // RenkId: " + caList6.Data.ColorId + " // Fiyat: " + caList6.Data.DailyPrice + " // Model: " + caList6.Data.ModelYear + " // Açıklama: " + caList6.Data.Description);
                Console.WriteLine(caList6.Message);
            }
            else
            {
                Console.WriteLine(caList6.Message);
            }
        }
    }
}
