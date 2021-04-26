using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
	public interface ICarService
	{
		IResult Add(Car car);
		IResult Update(Car car);
		IResult Delete(Car car);
		IDataResult<List<Car>> GetAll();
		IDataResult<Car> GetById(int carId);
		//IDataResult<List<Car>> GetCarsByBrandId(int brandId);
		//IDataResult<List<Car>> GetCarsByColorId(int id);
		IDataResult<List<CarDetailDto>> GetCarDetails();
		IDataResult<List<CarDetailDto>> GetCarDetailsByCarId(int carId);
		IDataResult<List<CarDetailDto>> GetCarsByBrandId(int brandId);
		IDataResult<List<CarDetailDto>> GetCarsByColorId(int colorId);

	}
}
