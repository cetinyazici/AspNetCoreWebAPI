# Otel Bulucu API - Oteller Kontrolcüsü

Bu belge, bir otel rezervasyon sistemi için oluşturulmuş bir ASP.NET Core Web API olan **Otel Bulucu API**'sinin **Oteller Kontrolcüsü**'nün kaynak kodunu incelemektedir.

## İçindekiler

- [Genel Bakış](#genel-bakış)
- [Amaç ve İşlevsellik](#amaç-ve-işlevsellik)
- [Yapı ve Mimari](#yapı-ve-mimari)
- [Ana Bileşenler](#ana-bileşenler)
  - [HotelsController Sınıfı](#hotelscontroller-sınıfı)
  - [API Metodları](#api-metodları)
- [Hata Yönetimi](#hata-yönetimi)

## Genel Bakış

Bu kod, `HotelsController` adında bir ASP.NET Core kontrolcüsünü tanımlar. Bu kontrolcü, otellerle ilgili işlemleri yönetmek için API uç noktaları sağlar.

## Amaç ve İşlevsellik

`HotelsController`, kullanıcıların otelleri listelemesini, otel ayrıntılarını görüntülemesini, yeni oteller oluşturmasını, mevcut otelleri güncellemesini ve otelleri silmesini sağlayan bir API'dir.

## Yapı ve Mimari

Kontrolcü, bağımlılık enjeksiyonu (DI) kullanarak `IHotelService` arayüzü aracılığıyla `HotelService` sınıfına erişir. Bu, gevşek bağlı ve test edilebilir bir tasarım modeli sağlar.

## Ana Bileşenler

### HotelsController Sınıfı

`HotelsController`, tüm HTTP isteklerini ele alan ana sınıftır. `ApiController` özniteliği, bunun bir API kontrolcüsü olduğunu belirtir.

### API Metodları

Kontrolcü, aşağıdaki API uç noktalarını sunar:

| HTTP Metodu | Rota                              | Açıklama                                   |
| ----------- | --------------------------------- | ------------------------------------------ |
| GET         | /api/hotels                       | Tüm otellerin listesini getirir.           |
| GET         | /api/hotels/GetHotelById/{id}     | Belirli bir ID'ye sahip bir oteli getirir. |
| GET         | /api/hotels/GetHotelByName/{name} | Belirli bir ada sahip bir oteli getirir.   |
| GET         | /api/hotels/GetHotelByNameOrId    | Ada veya ID'ye göre bir oteli getirir.     |
| POST        | /api/hotels                       | Yeni bir otel oluşturur.                   |
| PUT         | /api/hotels                       | Mevcut bir oteli günceller.                |
| DELETE      | /api/hotels/{id}                  | Belirli bir ID'ye sahip bir oteli siler.   |

## Hata Yönetimi

Kontrolcü, geçersiz istekler veya bulunmayan veriler için uygun HTTP durum kodlarını döndürerek temel hata yönetimini ele alır. Örneğin, bir otel bulunmazsa `NotFound` (404) döner.

## Örnek Kullanım

Aşağıda, Postman kullanarak otelleri almak için API'nin nasıl kullanılacağına dair bir örnek verilmiştir:

**İstek:**

```
GET /api/hotels
```

**Yanıt:**

```json
[
  {
    "id": 1,
    "name": "Otel A",
    "city": "İstanbul"
  },
  {
    "id": 2,
    "name": "Otel B",
    "city": "Ankara"
  }
]
```
