using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
	public class FileHelper
	{
		public static string Add(IFormFile file)
		{
			var result = newPath(file);
			var sourcepath = Path.GetTempFileName();
			if (file.Length > 0)
			{
				using (var stream = new FileStream(sourcepath, FileMode.Create))
				{
					file.CopyTo(stream);
				}
				File.Move(sourcepath, result.newPath);
			}
			
			return result.Path2;
		}
		public static IResult Delete(string path)
		{
			try
			{
				File.Delete(path);
			}
			catch (Exception exception)
			{
				return new ErrorResult(exception.Message);
			}
			return new SuccessResult();
		}
		public static string Update(string sourcePath,IFormFile file)
		{
			var result = newPath(file);
			if (sourcePath.Length > 0)
			{
				using (var stream = new FileStream(result.newPath, FileMode.Create))
				{
					file.CopyTo(stream);
				}
			}
			File.Delete(sourcePath);
			return result.Path2;
		}

		public static (string newPath, string Path2) newPath(IFormFile file)
		{
			FileInfo Info = new FileInfo(file.FileName);
			string fileExtension = Info.Extension;
			string path = Environment.CurrentDirectory + @"\wwwroot\upload";
			//var newPath = Guid.NewGuid().ToString() + "_" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + fileExtension;
			var newPath = Guid.NewGuid().ToString() + fileExtension;
			string result = $@"{path}\{newPath}";
			return (result, $@"\upload\{newPath}"); ;
		}



	}
}
