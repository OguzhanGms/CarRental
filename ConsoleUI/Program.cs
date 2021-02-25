using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;

namespace ConsoleUI
{
    class Program
    {
        static CarManager _carManager = new CarManager(new EFCarDal());
        static ColorManager _colorManager = new ColorManager(new EFCarColorDal());
        static BrandManager _brandManager = new BrandManager(new EFBrandDal());
        static RentalManager _rentalManager = new RentalManager(new EFRentalDal());
        static void Main(string[] args)
        {//
            int secim;
            int carId;
            int brandId, colorId;
            while (true)
            {
                Console.WriteLine("\n\n1.Araba Listesi" +
                                  "\n2. Renk Listesi" +
                                  "\n3. Marka Listesi" +
                                  "\n4. Araba Bul" +
                                  "\n5. Araba Ekle" +
                                  "\n6. Araba Güncelle" +
                                  "\n7. Araba Sil" +
                                  "\n8. Markaya Göre Araba Listele" +
                                  "\n9. Rengine Göre Araba Listele" +
                                  "\n10. Renk Ekle" +
                                  "\n11. Marka Ekle" +
                                  "\n12. Rent Ekle" +
                                  "\n20. Çıkış");

                secim = Convert.ToInt32(Console.ReadLine());
                switch (secim)
                {
                    case 1: carDetailList(); break;
                    case 2: colorList(); break;
                    case 3: brandList(); break;
                    case 4:
                        Console.WriteLine("Araba Id'si: ");
                        carId = Convert.ToInt32(Console.ReadLine());
                        getCarById(carId); break;
                    case 5: addCar(); break;
                    case 6: updateCar(); break;
                    case 7: deleteCar(); break;
                    case 8:
                        brandList();
                        Console.WriteLine("Marka Id: ");
                        brandId = Convert.ToInt32(Console.ReadLine());
                        getCarsByBrandId(brandId); break;
                    case 9:
                        colorList();
                        Console.WriteLine("Renk Yazın: ");
                        colorId = Convert.ToInt32(Console.ReadLine());
                        getCarsByColorId(colorId); break;
                    case 10: addColor(); break;
                    case 11: addBrand(); break;
                    case 12: addRent(); break;
                    case 20: Environment.Exit(0); break;
                    default: Console.WriteLine("Yanlış Seçim Yaptınız..."); break;
                }
            }
        }

        private static void addRent()
        {
            Rental addRent = new Rental();

            Console.Write("Yeni Araba İsmi: "); addRent.CarId = Convert.ToInt32(Console.ReadLine());

            brandList();
            Console.Write("Yeni Arabanın BrandId'si: "); addRent.CustomerId = Convert.ToInt32(Console.ReadLine());

            colorList();
            Console.Write("Yeni Arabanın ColorId'si: "); addRent.RentDate = Convert.ToDateTime(Console.ReadLine());

            var result = _rentalManager.Add(addRent);
            Console.WriteLine(result.Message);
        }

        private static void CarList()
        {
            Console.WriteLine("----- Varsayılan Liste -----");
            writeCarList();
        }

        private static void carDetailList()
        {
            Console.WriteLine("----- Detaylı Liste -----");
            foreach (var car in _carManager.GetCarsDetail().Data)
            {
                Console.WriteLine(
                    "CarId: {0}, CarName: {1}, Brand: {2}, ColorId: {3}, DailyPrice: {4}, ModelYear: {5}, Description: {6}",
                    car.CarId, car.CarName, car.BrandName,
                    car.ColorName, car.DailyPrice,
                    car.ModelYear, car.Description);
            }
        }

        private static void addCar()
        {
            Car addCar = new Car();

            Console.Write("Yeni Araba İsmi: "); addCar.CarName = Console.ReadLine();

            brandList();
            Console.Write("Yeni Arabanın BrandId'si: "); addCar.BrandId = Convert.ToInt32(Console.ReadLine());

            colorList();
            Console.Write("Yeni Arabanın ColorId'si: "); addCar.ColorId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Yeni Arabanın Günlüğü: "); addCar.DailyPrice = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Yeni Arabanın Model Yılı: "); addCar.ModelYear = Convert.ToInt16(Console.ReadLine());

            Console.Write("Yeni Arabanın Açıklaması: "); addCar.Description = Console.ReadLine();

            var result = _carManager.Add(addCar);
            Console.WriteLine(result.Message);
        }

        private static void updateCar()
        {
            carDetailList();

            Console.Write("Güncellenecek Araba Id'si: "); int carId = Convert.ToInt32(Console.ReadLine());
            getCarById(carId);

            Car updateCar = new Car();
            updateCar.CarId = carId;
            Console.Write("Arabanın Yeni İsmi: "); updateCar.CarName = Console.ReadLine();

            brandList();
            Console.Write("Arabanın Yeni BrandId'si: "); updateCar.BrandId = Convert.ToInt32(Console.ReadLine());

            colorList();
            Console.Write("Arabanın Yeni ColorId'si: "); updateCar.ColorId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Arabanın Yeni Günlüğü: "); updateCar.DailyPrice = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Arabanın Yenin Model Yılı: "); updateCar.ModelYear = Convert.ToInt16(Console.ReadLine());

            Console.Write("Arabanın Yeni Açıklaması: "); updateCar.Description = Console.ReadLine();

            var result = _carManager.Update(updateCar);
            Console.WriteLine(result.Message);
        }

        private static void deleteCar()
        {
            writeCarList();
            Console.Write("Silinecek Araba Id'si: "); int carId = Convert.ToInt32(Console.ReadLine());
            Car deleteCar = new Car();
            deleteCar.CarId = carId;
            var result = _carManager.Delete(deleteCar);
            Console.WriteLine(result.Message);
        }

        private static void getCarsByBrandId(int brandId)
        {
            Console.WriteLine("\n----- BrandId(2) -----");
            var result = _carManager.GetCarsByBrandId(brandId);
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    writeCar(car);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void getCarsByColorId(int colorId)
        {
            Console.WriteLine("\n----- ColorName -----");
            var result = _carManager.GetCarsByColorId(colorId);
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    writeCar(car);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void getCarById(int carId)
        {
            Console.WriteLine("\n----- GetById () -----");
            var result = _carManager.GetDetail(carId);
            if (result.Success)
            {
                writeCar(result.Data);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void writeCarList()
        {
            foreach (var car in _carManager.GetCarsDetail().Data)
            {
                writeCar(car);
            }
        }

        private static void writeCar(CarDetailDto car)
        {
            Console.WriteLine(
                "CarId: {0}, CarName: {1}, Brand: {2}, ColorId: {3}, DailyPrice: {4}, ModelYear: {5}, Description: {6}",
                car.CarId, car.CarName, car.BrandName,
                car.ColorName, car.DailyPrice,
                car.ModelYear, car.Description);
        }

        private static void colorList()
        {
            var result = _colorManager.GetAll();
            if (result.Success)
            {
                foreach (var carColor in result.Data)
                {
                    Console.WriteLine("ColorId: {0}, Color Name: {1}", carColor.ColorId, carColor.ColorName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }

        private static void addColor()
        {
            Console.WriteLine("Renk Adı: ");
            CarColor addColor = new CarColor();
            addColor.ColorName = Console.ReadLine();
            _colorManager.Add(addColor);
        }
        private static void brandList()
        {
            var result = _brandManager.GetAll();
            if (result.Success)
            {
                foreach (var brand in result.Data)
                {
                    Console.WriteLine("BrandId: {0}, Brand Name: {1}", brand.BrandId, brand.BrandName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void addBrand()
        {
            Brand addBrand = new Brand();
            Console.WriteLine("Marka Adı: ");
            addBrand.BrandName = Console.ReadLine();
            var result = _brandManager.Add(addBrand);
            Console.WriteLine(result.Message);
        }
    }
}
