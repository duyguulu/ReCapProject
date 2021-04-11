using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
	public interface IRentalService
	{
		IResult Add(Rental rental);
		IResult Update(Rental rental);
		IResult Delete(Rental rental);
		IDataResult<List<Rental>> GetAll();
		IDataResult<Rental> GetById(int rentalId);
		IDataResult<List<Rental>> GetByCarId(int carId);
		IDataResult<List<Rental>> GetByCustomerId(int customerId);
		IResult DeliverCar(int carId);
		IDataResult<List<RentalDetailDto>> GetRentalDetails();

	}
}
