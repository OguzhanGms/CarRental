using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Business.Constants
{
    public static class Messages
    {
        public static string DataAdded = "Kayıt eklendi";
        public static string DataUpdated = "Kayıt güncellendi";
        public static string DataDeleted = "Kayıt silindi";
        public static string NotFoundResult = "Seçtiğiniz kriterde sonuç bulunamadı";
        public static string DatasListed = "Kayıtlar listelendi";
        public static string NameMin = "İsim en az 2 karakter olmalıdır";
        public static string CarDailyPriceMin = "Arabanın günlük ücreti 50'den büyük olmalıdır";
        public static string InvalidCar = "Geçersiz araç";
        public static string InvalidCustomer = "Geçersiz müşteri";
        public static string RentedCar = "Seçilen araç şuan kirada";
        public static string InvalidEmail = "Geçersiz mail adresi";
        public static string InvalidPassword = "Parola en az 8 karakter olmalıdır";
        public static string InvalidUser = "Geçersiz kullanıcı";
        public static string InvalidCompanyName = "Şirket ismi en az 5 karakter olmalıdır";
    }
}
