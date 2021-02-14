using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
	public interface ICarDal:IEntityRepository<Car>
	{
		//List<Car> GetAll();
		//void Add(Car car);
		//void Update(Car car);
		//void Delete(Car car);

		////ben bunu id olarak düşündüm istersen kontrol et
		//List<Car> GetById(int Id);
	}
}
