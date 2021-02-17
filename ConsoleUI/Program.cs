using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
	class Program
	{
		static void Main(string[] args)
		{
			CarManager carManager = GetAllCarTest();

			//CarManager carManager = GetCarsByBrandTest();
			//BrandTest();


			//CarManager carManager = GetCarByColorIdTest();

			//InMemoryTest();

		}

		private static void BrandTest()
		{
			BrandManager brandManager = new BrandManager(new EfBrandDal());
			foreach (var brand in brandManager.GetAll())
			{
				Console.WriteLine(brand.BrandId + "-" + brand.BrandName);
			}
		}

		private static void InMemoryTest()
		{
			CarManager carManager = new CarManager(new InMemoryCarDal());
			Console.WriteLine("\n \n Yeni araç ekleme ve tüm listenin tekrardan getirilmesi:");
			//carManager.Add(new Car { BrandId = 1, ColorId = 1, DailyPrice=5, Descriptions="4. Araba"});
			foreach (var car in carManager.GetAll())
			{
				Console.WriteLine(car.Id + "-" + car.ModelYear + "-" + car.DailyPrice + "-" + car.Descriptions);
			}
		}

		private static CarManager GetCarByColorIdTest()
		{
			CarManager carManager = new CarManager(new EfCarDal());
			Console.WriteLine("\n \n Color=2 ' ye göre getirme:");
			foreach (var car in carManager.GetCarsByColorId(2))
			{
				Console.WriteLine(car.Id + "-" + car.ModelYear + "-" + car.DailyPrice + "-" + car.Descriptions);
			}

			return carManager;
		}

		private static CarManager GetCarsByBrandTest()
		{
			CarManager carManager = new CarManager(new EfCarDal());
			Console.WriteLine("\n \n BrandId=1 ' e göre getirme:");
			foreach (var car in carManager.GetCarsByBrandId(1))
			{
				Console.WriteLine(car.Id + "-" + car.ModelYear + "-" + car.DailyPrice + "-" + car.Descriptions);
			}

			return carManager;
		}

		private static CarManager GetAllCarTest()
		{
			CarManager carManager = new CarManager(new EfCarDal());

			Console.WriteLine("Araba ismi - Marka Adı - Renk - Günlük Ücreti");
			foreach (var car in carManager.GetCarDetails())
			{
				Console.WriteLine(car.CarName + "-" + car.BrandName + "-" + car.ColorName + "-" + car.DailyPrice);
			}

			return carManager;
		}
	}
}
