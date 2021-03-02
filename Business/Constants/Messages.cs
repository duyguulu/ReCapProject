using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
	public static class Messages
	{
		public static string BrandAdded = "Marka eklendi";
		public static string BrandDeleted = "Marka silindi";
		public static string BrandUpdated = "Marka güncellendi";

		public static string CarAdded = "Araba eklendi";
		public static string CarDeleted = "Araba silindi";
		public static string CarUpdated = "Araba güncellendi";
		public static string CarAddInvalid = "Araba ismi veya günlük ücreti geçersiz";

		public static string ColorAdded = "Renk eklendi";
		public static string ColorDeleted = "Renk silindi";
		public static string ColorUpdated = "Renk güncellendi";

		public static string MaintenanceTime = "Sistem bakımda";
		public static string Listed = "Listelendi";

		public static string UserAdded = "Kullanıcı eklendi";
		public static string UserDeleted = "Kullanıcı silindi";
		public static string UserUpdated = "Kullanıcı güncellendi";

		public static string CustomerAdded = "Müşteri eklendi";
		public static string CustomerDeleted = "Müşteri silindi";
		public static string CustomerUpdated = "Müşteri güncellendi";

		public static string RentalAdded = "Kirama işlemi eklendi";
		public static string RentalDeleted = "Kirama işlemi silindi";
		public static string RentalUpdated = "Kirama işlemi güncellendi";
		public static string RentalAddInvalid = "Kirama işlemi gerçekleştirelemedi, bu araba daha teslim edilmemiş";
		public static string RentalDelivered = "Araba teslim edildi";

		public static string CarImageLimitExceeded = "Araba resim limiti aşıldı";
	}
}
