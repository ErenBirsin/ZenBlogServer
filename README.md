# 🔧 Zen Blog Server

Zen Blog, modern ve güvenli bir blog platformu için geliştirilmiş .NET tabanlı RESTful API projesidir. Clean Architecture prensiplerine uygun olarak tasarlanmış, CQRS pattern ve Minimal API kullanılarak geliştirilmiştir.

## 🎯 Proje Özellikleri

### API Endpoints
- **Blog Yönetimi**: Blog yazılarının CRUD işlemleri, kategoriye göre filtreleme, son 5 blog listesi
- **Kategori Yönetimi**: Kategorilerin CRUD işlemleri ve listeleme
- **Yorum Yönetimi**: Blog yorumlarının CRUD işlemleri
- **Alt Yorum Yönetimi**: Yorumlara yapılan yanıtların yönetimi
- **Kullanıcı Yönetimi**: JWT token tabanlı kimlik doğrulama ve kullanıcı işlemleri
- **İletişim Bilgileri**: İletişim bilgilerinin yönetimi
- **Mesaj Yönetimi**: İletişim formundan gelen mesajların yönetimi
- **Sosyal Medya**: Sosyal medya linklerinin yönetimi
- **Hakkımızda**: Hakkımızda sayfası içeriğinin yönetimi

### Mimari Özellikler
- **Clean Architecture**: Domain, Application, Infrastructure ve Presentation katmanları
- **CQRS Pattern**: MediatR kullanılarak komut ve sorgu ayrımı
- **Repository Pattern**: Generic repository ve Unit of Work pattern'leri
- **Dependency Injection**: Servislerin merkezi yönetimi
- **Minimal API**: Modern endpoint tanımlamaları

## 🛠️ Teknolojiler

- **.NET**
- **ASP.NET Core** Web API
- **Entity Framework Core** (SQL Server)
- **ASP.NET Core Identity** (JWT Authentication)
- **MediatR** (CQRS Pattern)
- **AutoMapper** (Object Mapping)
- **FluentValidation** (Request Validation)
- **Scalar** (API Documentation)

## 📁 Proje Yapısı

```
ZenBlogServer/
├── Core/
│   ├── ZenBlog.Domain/              # Domain katmanı (Entities, Value Objects)
│   │   └── Entities/
│   │       ├── About.cs
│   │       ├── AppRole.cs
│   │       ├── AppUser.cs
│   │       ├── Blog.cs
│   │       ├── Category.cs
│   │       ├── Comment.cs
│   │       ├── ContactInfo.cs
│   │       ├── Message.cs
│   │       ├── Social.cs
│   │       └── SubComment.cs
│   └── ZenBlog.Application/         # Application katmanı (Use Cases, DTOs)
│       ├── Features/                # Feature-based klasör yapısı
│       │   ├── Blogs/
│       │   │   ├── Commands/       # Create, Update, Delete
│       │   │   ├── Queries/        # Get, GetAll, GetByCategory
│       │   │   ├── Handlers/       # Command/Query Handlers
│       │   │   ├── Endpoints/      # Minimal API Endpoints
│       │   │   ├── Mappings/       # AutoMapper Profiles
│       │   │   ├── Validators/     # FluentValidation
│       │   │   └── Result/         # Response DTOs
│       │   ├── Categories/
│       │   ├── Comments/
│       │   ├── Users/
│       │   ├── Messages/
│       │   ├── ContactInfos/
│       │   ├── Socials/
│       │   └── Abouts/
│       ├── Contracts/               # Interfaces
│       ├── Behaviors/               # Pipeline Behaviors
│       └── Options/                 # Configuration Options
├── Infrastructure/
│   ├── ZenBlog.Persistence/         # Data Access katmanı
│   │   ├── Context/
│   │   │   └── AppDbContext.cs
│   │   ├── Concrete/
│   │   │   ├── GenericRepository.cs
│   │   │   ├── UnitOfWork.cs
│   │   │   └── JwtService.cs
│   │   ├── Migrations/              # EF Core Migrations
│   │   └── Interceptors/            # EF Core Interceptors
│   └── ZenBlog.Infrastructure/      # External Services
└── Presentation/
    └── ZenBlog.API/                 # API Layer
        ├── Controllers/             # (Minimal API kullanıldığı için boş)
        ├── CustomMiddlewares/       # Exception Handling Middleware
        ├── EndpointRegistration/    # Endpoint kayıtları
        └── Program.cs               # Startup configuration
```

## 🔐 Güvenlik

- **JWT Token Authentication**: Kullanıcı kimlik doğrulama
- **ASP.NET Core Identity**: Kullanıcı ve rol yönetimi
- **Authorization**: Endpoint bazlı yetkilendirme
- **CORS**: Cross-Origin Resource Sharing yapılandırması
- **Custom Exception Handling**: Merkezi hata yönetimi middleware'i

## 🌐 Veritabanı

- **SQL Server**: Veritabanı olarak SQL Server kullanılmaktadır
- **Entity Framework Core**: ORM olarak EF Core kullanılmaktadır
- **Code First**: Migration tabanlı veritabanı yönetimi
- **Audit Trail**: Entity değişikliklerinin otomatik takibi (Interceptor)

## 📊 API Endpoint'leri

API endpoint'leri Minimal API kullanılarak feature-based yaklaşımla organize edilmiştir. Her feature kendi endpoints klasöründe tanımlanmıştır:

- `/api/categories` - Kategori işlemleri
- `/api/blogs` - Blog işlemleri
- `/api/users` - Kullanıcı işlemleri ve login
- `/api/comments` - Yorum işlemleri
- `/api/subcomments` - Alt yorum işlemleri
- `/api/contactinfos` - İletişim bilgisi işlemleri
- `/api/messages` - Mesaj işlemleri
- `/api/socials` - Sosyal medya işlemleri
- `/api/abouts` - Hakkımızda işlemleri

## 📝 Validation ve Mapping

- **FluentValidation**: Her command için request validation
- **AutoMapper**: Entity ve DTO arasında otomatik mapping
- **Request/Response DTOs**: Tip güvenli veri transferi

## 📸 API Dokümantasyonu

Scalar API dokümantasyonu geliştirme ortamında (`/scalar/v1`) kullanılabilir. Swagger/OpenAPI standardına uygun API dokümantasyonu sağlar.

## 🔄 CQRS Pattern

Proje CQRS (Command Query Responsibility Segregation) pattern'ini kullanır:

- **Commands**: Veri değiştiren işlemler (Create, Update, Delete)
- **Queries**: Sadece veri okuyan işlemler (Get, GetAll)
- **Handlers**: Her command/query için ayrı handler sınıfları
- **MediatR**: Komut ve sorgu mesajlaşması için mediator pattern

## 📦 Dependency Injection

Servis kayıtları extension method'lar üzerinden yapılmaktadır:

- `AddApplication()`: Application layer servisleri
- `AddPersistence()`: Data access layer servisleri

## 🌍 Frontend Entegrasyonu

API, Angular tabanlı frontend uygulaması (`http://localhost:4200`) ile entegre çalışmak üzere yapılandırılmıştır. CORS ayarları bu adrese izin verecek şekilde yapılandırılmıştır.

