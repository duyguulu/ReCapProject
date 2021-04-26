
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
	public class InMemoryCarDal:ICarDal
	{
		List<Car> _cars;

		public InMemoryCarDal()
		{
			_cars = new List<Car>
			{
				new Car{ Id=1, BrandId=1, ColorId=1, DailyPrice=100, Descriptions="1. Araba", ModelYear="1963"},
				new Car{ Id=2, BrandId=2, ColorId=2, DailyPrice=200, Descriptions="2. Araba", ModelYear="1973"},
				new Car{ Id=3, BrandId=2, ColorId=1, DailyPrice=350, Descriptions="3. Araba", ModelYear="1968"},
				new Car{ Id=4, BrandId=1, ColorId=2, DailyPrice=500, Descriptions="4. Araba", ModelYear="1985"},
				new Car{ Id=5, BrandId=2, ColorId=1, DailyPrice=120, Descriptions="5. Araba", ModelYear="1990"},
			};
		}

		public void Add(Car car)
		{
			_cars.Add(car);
		}

		public void Delete(Car car)
		{
			Car carToDelete = _cars.SingleOrDefault(p => p.Id == car.Id);
			_cars.Remove(carToDelete);
		}

		public List<Car> GetAll()
		{
			return _cars;
		}
		public void Update(Car car)
		{
			Car carToUpdate = _cars.SingleOrDefault(predicate => predicate.Id == car.Id);
			carToUpdate.ModelYear = car.ModelYear;
			carToUpdate.Descriptions = car.Descriptions;
			carToUpdate.DailyPrice = car.DailyPrice;
			carToUpdate.ColorId = car.ColorId;
			carToUpdate.BrandId = car.BrandId;
		}

		public List<Car> GetById(int Id)
		{
			//id yerine brand vs de olabilir.
			return _cars.Where(p => p.Id == Id).ToList();
		}

		public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
		{
			throw new NotImplementedException();
		}

		public Car Get(Expression<Func<Car, bool>> filter = null)
		{
			throw new NotImplementedException();
		}

		public List<CarDetailDto> GetProductDetails()
		{
			throw new NotImplementedException();
		}

		public List<CarDetailDto> GetCarDetails()
		{
			throw new NotImplementedException();
		}

		public List<CarDetailDto> GetCarsByColorId(int colorId)
		{
			throw new NotImplementedException();
		}

		public List<CarDetailDto> GetCarsByBrandId(int brandId)
		{
			throw new NotImplementedException();
		}

		public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
		{
			throw new NotImplementedException();
		}
	}
}
