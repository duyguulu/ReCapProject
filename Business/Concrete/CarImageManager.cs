using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
	public class CarImageManager : ICarImageService
	{
		ICarImageDal _carImageDal;

		public CarImageManager(ICarImageDal carImageDal)
		{
			_carImageDal = carImageDal;
		}

		//[ValidationAspect(typeof(CarImageValidator))]
		public IResult Add(IFormFile file, CarImage carImage)
		{
			IResult result = BusinessRules.Run(CheckImageLimitExceeded(carImage.CarId));
			if (result != null)
			{
				return result;
			}
			
			carImage.ImagePath = FileHelper.Add(file);
			carImage.ImageName = Path.GetFileName(carImage.ImagePath);
			carImage.DateT = DateTime.Now;
			_carImageDal.Add(carImage);
			return new SuccessResult();
		}

		[ValidationAspect(typeof(CarImageValidator))]
		public IResult Delete(CarImage carImage)
		{
			FileHelper.Delete(carImage.ImagePath);
			_carImageDal.Delete(carImage);
			return new SuccessResult();
		}

		[ValidationAspect(typeof(CarImageValidator))]
		public IDataResult<CarImage> Get(int id)
		{
			//bu metot GetbyId ile aynı!
			return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.CarImageId == id));
		}

		public IDataResult<List<CarImage>> GetAll()
		{
			if (DateTime.Now.Hour == 22)
			{
				return new ErrorDataResult<List<CarImage>>(Messages.MaintenanceTime);
			}
			return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.Listed);
		}

		[ValidationAspect(typeof(CarImageValidator))]
		public IDataResult<CarImage> GetById(int carImageId)
		{
			return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.CarImageId == carImageId));
		}

		[ValidationAspect(typeof(CarImageValidator))]
		public IDataResult<List<CarImage>> GetImagesByCarId(int id)
		{
			//return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(id));

			return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(p => p.CarId == id));
		}

		[ValidationAspect(typeof(CarImageValidator))]
		public IResult Update(IFormFile file, CarImage carImage)
		{
			IResult result = BusinessRules.Run(CheckImageLimitExceeded(carImage.CarId));
			if (result != null)
			{
				return result;
			}
			carImage.ImagePath = FileHelper.Update(_carImageDal.Get(p => p.CarImageId == carImage.CarImageId).ImagePath, file);
			carImage.DateT = DateTime.Now;
			_carImageDal.Update(carImage);
			return new SuccessResult();
		}

		//business rules
		private IResult CheckImageLimitExceeded(int carid)
		{
			var carImagecount = _carImageDal.GetAll(p => p.CarId == carid).Count;
			if (carImagecount >= 5)
			{
				return new ErrorResult(Messages.CarImageLimitExceeded);
			}

			return new SuccessResult();
		}

		//private List<CarImage> CheckIfCarImageNull(int id)
		//{
		//	string path = @"\Images\logo.png";
		//	var result = _carImageDal.GetAll(c => c.CarId == id).Any();
		//	if (!result)
		//	{
		//		return new List<CarImage> { new CarImage { CarId = id, ImagePath = path, DateT = DateTime.Now } };
		//		//return new List<CarImage> { new CarImage { CarId = id, ImagePath = path, DateT = "0303" } };
		//	}
		//	return _carImageDal.GetAll(p => p.CarId == id);
		//}

		private IDataResult<List<CarImage>> CheckIfCarImageNull(int id)
		{
			try
			{
				string path = @"\wwwroot\uploads\logo.jpg";
				var result = _carImageDal.GetAll(c => c.CarId == id).Any();
				if (!result)
				{
					List<CarImage> carimage = new List<CarImage>();
					carimage.Add(new CarImage { CarId = id, ImagePath = path, DateT = DateTime.Now });
					return new SuccessDataResult<List<CarImage>>(carimage);
				}
			}
			catch (Exception exception)
			{

				return new ErrorDataResult<List<CarImage>>(exception.Message);
			}

			return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(p => p.CarId == id).ToList());
		}


	}
}
