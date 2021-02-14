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

			//CarManager carManager2 = new CarManager(new InMemoryCarDal());
			CarManager carManager = new CarManager(new EfCarDal());

			Console.WriteLine("Id - Model Yılı - Günlük Ücret - Açıklama");
			foreach (var car in carManager.GetAll())
			{
				Console.WriteLine(car.Id+ "-" +car.ModelYear + "-" +car.DailyPrice + "-" + car.Descriptions);
			}


			Console.WriteLine("---------------------------------");
			Console.WriteLine("\n \n BrandId=1 ' e göre getirme:");
			foreach (var car in carManager.GetCarsByBrandId(1))
			{
				Console.WriteLine(car.Id + "-" + car.ModelYear + "-" + car.DailyPrice + "-" + car.Descriptions);
			}

			Console.WriteLine("---------------------------------");
			Console.WriteLine("\n \n Color=2 ' ye göre getirme:");
			foreach (var car in carManager.GetCarsByColorId(2))
			{
				Console.WriteLine(car.Id + "-" + car.ModelYear + "-" + car.DailyPrice + "-" + car.Descriptions);
			}

			Console.WriteLine("---------------------------------");
			Console.WriteLine("\n \n Yeni araç ekleme ve tüm listenin tekrardan getirilmesi:");
			//carManager.Add(new Car { BrandId = 1, ColorId = 1, DailyPrice=5, Descriptions="4. Araba"});
			foreach (var car in carManager.GetAll())
			{
				Console.WriteLine(car.Id + "-" + car.ModelYear + "-" + car.DailyPrice + "-" + car.Descriptions);
			}

		}
	}
}
