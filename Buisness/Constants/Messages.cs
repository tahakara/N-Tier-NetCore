using Core.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Urun Eklendi";
        public static string ProductNameInvalid = "Urun ismi en az 2 karakter olmalidir";
        public static string MaintenanceTime = "Sistem bakimda";
        public static string ProductsListed = "Urunler listelendi";
        public static string ProductCountOfCategoryError = "Bir kategoride en fazla 10 urun olabilir";
        public static string ProductNameAlreadyExists = "Bu isimde bir ürün zaten var";
        public static string CategoryLimitExceeded = "Kategori limiti asildigi icin yeni ürün eklenemiyor";
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserAlreadyExists = "Kullanici mevcut";
        public static string SuccessfulLogin = "Basarili giris";
        public static string PasswordError = "Hatali sifre";
        public static string UserNotFound = "Kullanici bulunamadi";
        public static string AccessTokenCreated = "Token olusturuldu";
        public static string UserRegistered = "Kullanici kayit oldu";
        public static string ProductTransactionCoplete = "Urun Transaction tamamlandi";
    }
}
