using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Performance;
using Core.Aspect.Autofac.Transaction;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
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

		[SecuredOperation("product.add,admin")]
		[ValidationAspect(typeof(CarValidator))]
		[CacheRemoveAspect("IProductService.Get")]
		public IResult Add(Car car)
		{
			IResult result = BusinessRules.Run(CheckIfCarNameExist(car.CarName));
			if (result != null)
			{
				return result;
			}
				_carDal.Add(car);
				return new SuccessResult(Messages.CarAdded);
		}

		public IResult Delete(Car car)
		{
			_carDal.Delete(car);
			return new SuccessResult(Messages.CarDeleted);
		}

		[CacheAspect] //key, value
		public IDataResult<List<Car>> GetAll()
		{
			//iş kodları:
			if (DateTime.Now.Hour == 2)
			{
				return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
			}
			return new SuccessDataResult<List<Car>>(_carDal.GetAll());
		}

		[CacheAspect]
		[PerformanceAspect(5)]
		public IDataResult<Car> GetById(int carId)
		{
			return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == carId));
		}

		public IDataResult<List<CarDetailDto>> GetCarDetails()
		{
			return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
		}

		public IDataResult<List<CarDetailDto>> GetCarDetailsByCarId(int carId)
		{
			return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.CarId == carId));
		}

		public IDataResult<List<CarDetailDto>> GetCarsByBrandId(int brandId)
		{
			return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c=> c.BrandId==brandId));
		}

		public IDataResult<List<CarDetailDto>> GetCarsByColorId(int colorId)
		{
			return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.ColorId == colorId));
		}

		[ValidationAspect(typeof(CarValidator))]
		[CacheRemoveAspect("IProductService.Get")]
		public IResult Update(Car car)
		{
			if (CheckIfCarNameExist(car.CarName).Success)
			{
				_carDal.Update(car);
				return new SuccessResult(Messages.CarUpdated);
			}
			return new ErrorResult();
		}

		private IResult CheckIfCarNameExist(string carName)
		{
			if (_carDal.GetAll(c => c.CarName == carName).Any()) return new ErrorResult(Messages.CarNameAlreadyExist);
			return new SuccessResult();
		}

		//burası duzeltilebilinir.
		[TransactionScopeAspect] //böyle mi yazmalıyız?
		public IResult AddTransactionalTest(Car car)
		{
			Add(car);
			if (car.DailyPrice < 0)
			{
				throw new Exception("");
			}
			Add(car);
			return null;
		}
	}
}
