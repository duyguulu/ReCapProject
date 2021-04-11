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
	public class RentalManager : IRentalService
	{
		IRentalDal _rentalDal;
		public RentalManager(IRentalDal rentalDal)
		{
			_rentalDal = rentalDal;
		}
		public IResult Add(Rental rental)
		{
			var result = _rentalDal.GetAll(r => r.CarId == rental.CarId && r.ReturnDate == null);
			if (result.Count >0)
			{
				return new ErrorResult(Messages.RentalAddInvalid);
			}
			else
			{
				_rentalDal.Add(rental);
				return new SuccessResult(Messages.RentalAdded);
			}
			
		}

		public IResult Delete(Rental rental)
		{
			_rentalDal.Delete(rental);
			return new SuccessResult(Messages.RentalDeleted);
		}

		public IResult DeliverCar(int carId)
		{
			Rental rental = _rentalDal.Get(r => r.CarId == carId && r.ReturnDate == null);
			//error kısmını yapmadım.
			rental.ReturnDate= DateTime.Now;
			_rentalDal.Update(rental);
			return new SuccessResult(Messages.RentalDelivered);
		}

		public IDataResult<List<Rental>> GetAll()
		{
			return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
		}

		public IDataResult<List<Rental>> GetByCarId(int carId)
		{
			return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(c => c.CarId == carId));
		}

		public IDataResult<List<Rental>> GetByCustomerId(int customerId)
		{
			return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(c => c.CustomerId == customerId));
		}

		public IDataResult<Rental> GetById(int rentalId)
		{
			return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == rentalId));
		}

		public IDataResult<List<RentalDetailDto>> GetRentalDetails()
		{
			return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
		}

		public IResult Update(Rental rental)
		{
			_rentalDal.Update(rental);
			return new SuccessResult(Messages.RentalUpdated);
		}
	}
}
