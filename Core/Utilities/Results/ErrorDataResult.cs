using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
	public class ErrorDataResult<T>:DataResult<T>
	{
		public ErrorDataResult(T data, string message) : base(data, false) //mesaj ve data döndürülen
		{

		}
		public ErrorDataResult(T data) : base(data, false) //sadece data
		{

		}
		public ErrorDataResult(string message) : base(default, false, message) //sadece mesaj ve datayı default haliyle göndermek
		{

		}
		public ErrorDataResult() : base(default, false) //sadece datayı default data olarak gönderme
		{

		}
	}
}
