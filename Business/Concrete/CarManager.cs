using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
	public class CarManager : ICarService
	{
		ICarDal _carDal;
		public CarManager(ICarDal carDal)
		{
			_carDal = carDal;
		}

		public IResult Add(Car car)
		{
			if (car.DailyPrice < 0 && (car.CarName).Length<2 )
			{
				return new ErrorResult(Messages.CarAddInvalid);
			}
			else
			{
				_carDal.Add(car);
				return new SuccessResult(Messages.CarAdded);
			}
		}

		public IDataResult<List<Car>> GetAll()
		{
			//iş kodları:
			if (DateTime.Now.Hour == 2)
			{
				return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
			}
			return new SuccessDataResult<List<Car>>(_carDal.GetAll());
		}

		public IDataResult<List<CarDetailDto>> GetCarDetails()
		{
			return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
		}

		public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
		{
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == brandId));
		}

		public IDataResult<List<Car>> GetCarsByColorId(int colorId)
		{
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == colorId));
		}
	}
}
