using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public class Messages
    {
        public static string CarAdded = "Araç eklendi";
        public static string CarDeleted = "Araç silindi";
        public static string CarUpdated = "Araç güncellendi";
        public static string CarsListed = "Araçlar listelendi";
        public static string CarListed = "Araç listelendi";
        public static string ColorAdded = "Renk eklendi";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorUpdated = "Renk güncellendi";
        public static string ColorsListed = "Renkler listelendi";
        public static string ColorListed = "Renk listelendi";
        public static string BrandAdded = "Marka eklendi";
        public static string BrandDeleted = "Marka silindi";
        public static string BrandUpdated = "Marka güncellendi";
        public static string BrandsListed = "Markalar listelendi";
        public static string BrandListed = "Marka listelendi";
        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string UsersListed = "Kullanıcılar listelendi";
        public static string UserListed = "Kullanıcı listelendi";
        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomerDeleted = "Müşteri silindi";
        public static string CustomerUpdated = "Müşteri güncellendi";
        public static string CustomersListed = "Müşteriler listelendi";
        public static string CustomerListed = "Müşteri listelendi";
        public static string RentalAdded = "Kiralama yapıldı";
        public static string RentalDeleted = "Kiralama silindi";
        public static string RentalUpdated = "Kiralama güncellendi";
        public static string RentalsListed = "Kiralamalar listelendi";
        public static string RentalListed = "Kiralama listelendi";
        public static string RentalFailed = "Araç teslim edilmemiş, kiralanamaz";
        public static string DateTimeNowError = "Kiralama tarihleri mevcut gün ve saatten büyük olmalı.";
        public static string RentDateError = "Kiralama tarihi rezerve edilmiş.";
        public static string ReturnDateError = "Teslim tarihi rezerve edilmiş.";
        public static string RentalValid = "Kiralama geçerli.";

        public static string OperationFailed = "İşlem başarısız, sistem bakımda";

        public static string CarImageAdded = "Araç resmi eklendi.";
        public static string CarImageDeleted = "Araç resmi silindi";
        public static string CarImageUpdate = "Araç resmi güncellendi.";
        public static string CarsImagesListed = "Araç resimleri listelendi.";
        public static string CarImagesListed = "Aracın resimleri listelendi.";
        public static string CarImageListed = "Resim listelendi.";
        public static string CarImageLimitExceeded = "Araç resim limiti aşılmıştır.";

        public static string AuthorizationDenied = "Yetkiniz yok.";
        public static string UserRegistered = "Kayıt oldu.";
        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string PasswordError = "Parola hatası.";
        public static string SuccessfulLogin = "Başarılı giriş.";
        public static string UserAlreadyExists = "Kullanıcı Mevcut";
        public static string AccessTokenCreated = "Token oluşturuldu.";
        public static string ClaimsListed = "Roller Listelendi.";
        public static string MailListed = "Mail listelendi.";

        public static string PaymentSuccess = "Ödeme başarılı.";
        public static string PaymentUnsuccessful = "Ödeme başarısız.";

        public static string FindeksPointPositive = "Olumlu Findeks sonucu";
        public static string FindeksPointNegative = "Olumsuz Findeks sonucu";

        public static string CardAdded = "Kart eklendi.";
        public static string CardDeleted = "Kart silindi.";
        public static string CardsListed = "Kartlar listelendi.";
        public static string CardListed = "Kart listelendi.";
    }
}
