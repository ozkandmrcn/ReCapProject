using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
   public static class Messages
    {
        public static string CarAdded = "Araba eklendi.";
        public static string BrandAdded = "Marka eklendi.";
        public static string ColorAdded = "Renk eklendi.";
        public static string BrandNameInvalid = "Araba ismi geçersiz.";
        public static string UserAdded = "Kullanıcı eklendi.";
        public static string CarDeleted = "Araba silindi.";
        public static string BrandDeleted = "Marka silindi.";
        public static string ColorDeleted = "Renk silindi.";
        public static string UserDeleted = "Kullanıcı silindi.";
        public static string DailyPriceInvalid = "Günlük fiyat geçersiz.";
        public static string CarUpdated = "Araba güncellendi";
        public static string BrandUpdated = "Marka güncellendi";
        public static string ColorUpdated = "Renk güncellendi";
        public static string MaintenanceTime = "sistem bakımda";
        public static string CarsListed = "Arabalar listelendi.";

        //General
        public static string AddedRental = "Araba Kiralama işlemi baraşıyla gerçekleşti.";
        public static string DeletedRental = "Araba Kiralama işlemi iptal edildi.";
        public static string UpdatedRental = "Araba Kiralama işlemi güncellendi.";
        public static string FailedRentalAddOrUpdate = "Bu araba henüz teslim edilmediği için kiralayamazsınız.";
        public static string ReturnedRental = "Kiraladığınız araç teslim edildi.";
        public static string Undelivered = "Teslim edilmemis arac.";
        public static string CarImageLimitExceeded = "Araba kiralayamaqzsınız";

        public static string CarImagesAdded = "Eklendi";
        public static string CarImageNotAdded = "Hata olustu";
    }
}
