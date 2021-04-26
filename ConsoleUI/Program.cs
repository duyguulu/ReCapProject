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
			GetAllCarTest();

			//CarManager carManager = GetCarsByBrandTest();
			//BrandTest();


			//CarManager carManager = GetCarByColorIdTest();

			//InMemoryTest();

		}

		private static void BrandTest()
		{
			BrandManager brandManager = new BrandManager(new EfBrandDal());
			
			var result = brandManager.GetAll();
			if (result.Success == true)
			{
				foreach (var brand in result.Data)
				{
					Console.WriteLine(brand.BrandId + "-" + brand.BrandName);
				}
			}
			else
			{
				Console.WriteLine("bug");
				Console.WriteLine(result.Message);
			}
		}

		private static void InMemoryTest()
		{
			CarManager carManager = new CarManager(new InMemoryCarDal());
			Console.WriteLine("\n \n Yeni araç ekleme ve tüm listenin tekrardan getirilmesi:");
			//carManager.Add(new Car { BrandId = 1, ColorId = 1, DailyPrice=5, Descriptions="4. Araba"});
			var result = carManager.GetAll();
			if (result.Success == true)
			{
				foreach (var car in result.Data)
				{
					Console.WriteLine(car.Id + "-" + car.ModelYear + "-" + car.DailyPrice + "-" + car.Descriptions);
				}
			}
			else
			{
				Console.WriteLine(result.Message);
			}
		}

		private static void GetCarByColorIdTest()
		{
			CarManager carManager = new CarManager(new EfCarDal());
			Console.WriteLine("\n \n Color=2 ' ye göre getirme:");
			var result = carManager.GetCarsByColorId(2);
			if (result.Success == true)
			{
				foreach (var car in result.Data)
				{
					Console.WriteLine(car.ColorId + "-" + car.ModelYear + "-" + car.DailyPrice + "-" + car.Descriptions);
				}
			}
			else
			{
				Console.WriteLine(result.Message);
			}
		}

		private static void GetCarsByBrandTest()
		{
			CarManager carManager = new CarManager(new EfCarDal());
			Console.WriteLine("\n \n BrandId=1 ' e göre getirme:");

			var result = carManager.GetCarsByBrandId(1);
			if (result.Success == true)
			{
				foreach (var car in result.Data)
				{
					Console.WriteLine(car.ColorId + "-" + car.ModelYear + "-" + car.DailyPrice + "-" + car.Descriptions);
				}
			}
			else
			{
				Console.WriteLine(result.Message);
			}

		}

		private static void GetAllCarTest()
		{
			CarManager carManager = new CarManager(new EfCarDal());

			Console.WriteLine("Araba ismi - Marka Adı - Renk - Günlük Ücreti");

			var result = carManager.GetCarDetails();
			if (result.Success == true)
			{
				foreach (var car in result.Data)
				{
					Console.WriteLine(car.CarName + "-" + car.BrandName + "-" + car.ColorName + "-" + car.DailyPrice);
				}
			}
			else
			{
				Console.WriteLine(result.Message);
			}
		}
	}
}
