# KayraExport Backend Task1

## Product API

Bu proje, KayraExport'in Backend Task 1 geliştirme görevi için oluşturulmuştur ve temel CRUD (Create, Read, Update, Delete) işlemlerini destekleyen bir Product API'sini içerir. 

## Teknolojiler

* .NET 6+ (ASP.NET Core Web API) 
* C# 
* PostgreSQL 
* Entity Framework Core 
* Swagger 

## Mimari

Proje, Katmanlı Mimari (Controller - Service - Repository) deseni kullanılarak tasarlanmıştır. Bu sayede her bir katmanın sorumluluğu ayrılmış ve yönetilebilir bir yapı oluşturulmuştur.

* **ProductAPI.API:** REST API endpointlerini ve controller'ları içerir.
* **ProductAPI.Application:** İş mantığını ve servisleri içerir.
* **ProductAPI.Infrastructure:** Veri erişim katmanını (Entity Framework Core) ve repository'leri içerir.
* **ProductAPI.Domain:** Temel iş nesnelerini (entity'ler ve DTO'lar) içerir.

## Kurulum ve Çalıştırma

### 1. Gereksinimleri Karşılayın ve Ortamı Hazırlayın

* .NET 6+ SDK'yı indirin ve kurun.
* PostgreSQL 17 veritabanı sunucusunu 

### 2. Projeyi İndirme ve Ortamı Hazırlama

* Projeyi https://github.com/Meroby113/KayraExport.git GitHub linkine giderek ZIP dosyası olarak yerel diskinize indirin
* İndirdiğiniz dosyayı ZIP'den çıkarın.

### 3. PostgreSQL Kurulumu ve Veritabanı Ayarları

1.  **PostgreSQL 17 Kurulumu:**
    * PostgreSQL'in resmi web sitesinden (https://www.postgresql.org/download/) işletim sisteminize uygun kurulum dosyasını indirin.
    * Kurulum sırasında sizden bir yönetici (super-user) şifresi belirlemeniz istenecektir. Bu şifreyi not alın, ileride `appsettings.json` dosyasında kullanacaksınız. Varsayılan kullanıcı adı genellikle `postgres`'tir.

2.  **Veritabanı Oluşturma:**
    * PostgreSQL ile birlikte kurulan **pgAdmin 4** uygulamasını açın.
    * Sol taraftaki panelde **"Servers"** başlığı altındaki PostgreSQL sunucusuna çift tıklayın ve kurulum sırasında belirlediğiniz yönetici şifresini girerek bağlanın.
    * **"Databases"** başlığına sağ tıklayın, **"Create" -> "Database..."** seçeneğini seçin.
    * Açılan pencerede veritabanı adını `ProductDb` olarak belirleyin ve kaydedin.

3.  **Bağlantı Dizisini Yapılandırma:**
    * `ProductAPI/ProductAPI.API/appsettings.json` dosyasını açın.
    * `ConnectionStrings` bölümündeki `DefaultConnection` değerini alttaki örnekteki gibi değiştirin.
    * `[BURAYA ŞİFREYİ GİRİN]` kısmını kendi belirlediğiniz password ile değiştirin.

    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Host=localhost;Database=ProductDb;Username=postgres;Password=[BURAYA ŞİFREYİ GİRİN]"
    }
    ```

### 4. Gerekli Paketleri Yükleme ve Bağımlılıkları Ayarlama

Projenin bağımlılıklarını ve katmanlar arasındaki referansları doğru bir şekilde kurmak için aşağıdaki komutları sırasıyla çalıştırın.

* Terminalde `ProductAPI` ana klasörüne gidin ve Entity Framework Core CLI araçlarını global olarak yükleyin:
    ```bash
    dotnet tool install --global dotnet-ef
    ```
* Terminalde `ProductAPI\ProductAPI.Infrastructure` klasörüne gidin ve EF Core paketlerini yükleyin:
    ```bash
    dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
    dotnet add package Microsoft.EntityFrameworkCore.Design
    ```
* Terminalde `ProductAPI\ProductAPI.API` klasörüne geçin ve Swagger paketini yükleyin:
    ```bash
    dotnet add package Swashbuckle.AspNetCore
    ```

### 5. Veritabanı Migration'larını Uygulama

* Terminalde projenin ana klasörüne (`ProductAPI`) gidin.
* Gerekli NuGet paketlerini ve proje referanslarını yüklemek için `dotnet restore` komutunu çalıştırın.
    ```bash
    dotnet restore
    ```
* Proje kodundaki model yapısını veritabanı tablolarına dönüştürmek için migration'ları uygulayın.
    ```bash
    dotnet ef database update --project ProductAPI.Infrastructure --startup-project ProductAPI.API
    ```

### 6. API'yi Çalıştırma

* Terminalde `ProductAPI.API` klasörüne gidin.
* `dotnet run` komutunu çalıştırın.
    ```bash
    dotnet run
    ```
* API, terminal çıktısında gösterilen bir URL'de (genellikle `http://localhost:5144` gibi bir adreste) çalışmaya başlayacaktır.

## API Dokümantasyonu ve Test

* Çalışan API'yi test etmek için, tarayıcınızda `http://localhost:[PORT_NUMARASI]/swagger` adresine gidin. Örnek: `http://localhost:5144/swagger`.