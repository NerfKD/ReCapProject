using Business.Concrete;
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
            //Araba 
            CarManager carManager = new CarManager(new InMemoryCarDal(), new InMemoryBrandDal());
            Console.WriteLine("--------Araba ekleme--------");
            Console.WriteLine("--------Başarılı araba ekleme--------");
            carManager.Add(new Car { Id = 6, BrandId = 1, ColorId = 2, DailyPrice = 320000, Description = "F", ModelYear = 2019 });
            Console.WriteLine("--------Başarısız araba ekleme--------");
            carManager.Add(new Car { Id = 7, BrandId = 1, ColorId = 2, DailyPrice = 320000, Description = null, ModelYear = 2020 });

            Console.WriteLine("--------ID ile çağırma--------");
            Car car = carManager.GetById(6);
            Console.WriteLine("ID: " + car.Id + " // MarkaId: " + car.BrandId + " // RenkId: " + car.ColorId + " // Fiyat: " + car.DailyPrice + " // Model: " + car.ModelYear + " // Açıklama: " + car.Description);

            Console.WriteLine("--------Araba güncelleme--------");
            Console.WriteLine("--------Başarılı araba güncelleme--------");
            carManager.Update(new Car { Id = 6, BrandId = 1, ColorId = 2, DailyPrice = 500000, Description = "F", ModelYear = 2019 });
            Console.WriteLine("--------Başarısız araba güncelleme--------");
            carManager.Update(new Car { Id = 7, BrandId = 1, ColorId = 2, DailyPrice = 320000, Description = "F", ModelYear = 2020 });

            Console.WriteLine("--------Araba silme--------");
            Console.WriteLine("--------Başarılı araba silme--------");
            carManager.Delete(new Car { Id = 3, BrandId = 1, ColorId = 2, DailyPrice = 320000, Description = "F", ModelYear = 2019 });
            Console.WriteLine("--------Başarısız araba silme--------");
            carManager.Delete(new Car { Id = 7, BrandId = 1, ColorId = 2, DailyPrice = 320000, Description = "F", ModelYear = 2020 });
            
            Console.WriteLine("--------Tüm listeyi çağırma--------");
            List<Car> carList = carManager.GetAll();
            foreach (Car item in carList)
            {
                Console.WriteLine("ID: " + item.Id + " // MarkaId: " + item.BrandId + " // RenkId: " + item.ColorId + " // Fiyat: " + item.DailyPrice + " // Model: " + item.ModelYear + " // Açıklama: " + item.Description);
            }

            //Marka 
            BrandManager brandManager = new BrandManager(new InMemoryBrandDal());
            Console.WriteLine("--------Marka ekleme--------");
            Console.WriteLine("--------Başarılı marka ekleme--------");
            brandManager.Add(new Brand { BrandId = 4, BrandName = "Ferrari" });
            Console.WriteLine("--------Başarısız marka ekleme--------");
            brandManager.Add(new Brand { BrandId = 5, BrandName = null });

            Console.WriteLine("--------ID ile çağırma--------");
            Brand brand = brandManager.GetById(4);
            Console.WriteLine("ID: " + brand.BrandId + " // Marka Adı: " + brand.BrandName);

            Console.WriteLine("--------Marka silme--------");
            Console.WriteLine("--------Başarılı marka silme--------");
            brandManager.Delete(new Brand { BrandId = 3, BrandName = "Ferrari" });
            Console.WriteLine("--------Başarısız marka silme--------");
            brandManager.Delete(new Brand { BrandId = 7, BrandName = "Ferrari" });

            Console.WriteLine("--------Marka güncelleme--------");
            Console.WriteLine("--------Başarılı marka güncelleme--------");
            brandManager.Update(new Brand { BrandId = 4, BrandName = "Ferrariiiii" });
            Console.WriteLine("--------Başarısız marka güncelleme--------");
            brandManager.Update(new Brand { BrandId = 7, BrandName = "Ferrari" });

            Console.WriteLine("--------Tüm listeyi çağırma--------");
            List<Brand> brandList = brandManager.GetAll();
            foreach (Brand item in brandList)
            {
                Console.WriteLine("ID: " + item.BrandId + " // Marka Adı: " + item.BrandName);
            }


            //Renk 
            ColorManager colorManager = new ColorManager(new InMemoryColorDal());
            Console.WriteLine("--------Renk ekleme--------");
            Console.WriteLine("--------Başarılı renk ekleme--------");
            colorManager.Add(new Color { ColorId = 6, ColorName = "Sarı" });
            Console.WriteLine("--------Başarısız renk ekleme--------");
            colorManager.Add(new Color { ColorId = 7, ColorName = null });

            Console.WriteLine("--------ID ile çağırma--------");
            Color color = colorManager.GetById(6);
            Console.WriteLine("ID: " + color.ColorId + " // Marka Adı: " + color.ColorName);

            Console.WriteLine("--------Renk silme--------");
            Console.WriteLine("--------Başarılı renk silme--------");
            colorManager.Delete(new Color { ColorId = 2, ColorName = "Sarı" });
            Console.WriteLine("--------Başarısız renk silme--------");
            colorManager.Delete(new Color { ColorId = 7, ColorName = "Sarı" });

            Console.WriteLine("--------Renk güncelleme--------");
            Console.WriteLine("--------Başarılı renk güncelleme--------");
            colorManager.Update(new Color { ColorId = 6, ColorName = "Sarııııııııı" });
            Console.WriteLine("--------Başarısız renk güncelleme--------");
            colorManager.Update(new Color { ColorId = 7, ColorName = "Sarı" });

            Console.WriteLine("--------Tüm listeyi çağırma--------");
            List<Color> colorList = colorManager.GetAll();
            foreach (Color item in colorList)
            {
                Console.WriteLine("ID: " + item.ColorId + " // Marka Adı: " + item.ColorName);
            }

            Console.WriteLine("--------Tüm listeyi çağırma (LINQ - JOIN)--------");
            CarDTOManager carDTOManager = new CarDTOManager(new InMemoryBrandDal(), new InMemoryCarDal(), new InMemoryColorDal());
            List<CarDTO> carDTOs = carDTOManager.GetAll();
            foreach (CarDTO item in carDTOs)
            {
                Console.WriteLine("ID: " + item.Id + " // Marka: " + item.BrandName + " // Renk: " + item.ColorName + " // Fiyat: " + item.DailyPrice + " // Model: " + item.ModelYear + " // Açıklama: " + item.Description);
            }

        }
    }
}
