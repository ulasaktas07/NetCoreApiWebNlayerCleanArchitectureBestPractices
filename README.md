# NetCoreApiWebNlayerCleanArchitectureBestPractices

Bu proje, .NET 8 ve Clean Architecture prensiplerine uygun şekilde geliştirilmiş katmanlı bir Web API mimarisi sunar. SOLID prensiplerine uygunluğu ve sürdürülebilir yapısıyla kurumsal düzeyde uygulamalar için iyi bir başlangıç sağlar.

## 📁 Katmanlar

- **Domain**: Temel iş kuralları, entity’ler ve arayüzler.
- **Application**: DTO'lar, servisler ve iş mantığı (UseCase/MediatR).
- **Infrastructure**: Veri erişim (EF Core), dış servis implementasyonları.
- **API**: Web API uç noktaları ve sunum katmanı.

## 🔧 Kurulum

```bash
git clone https://github.com/ulasaktas07/NetCoreApiWebNlayerCleanArchitectureBestPractices.git
cd NetCoreApiWebNlayerCleanArchitectureBestPractices
dotnet restore
dotnet build
dotnet run --project src/WebApi

🚀 Özellikler
Clean Architecture uyumlu yapı

Katmanlı mimari

Dependency Injection

Swagger/OpenAPI desteği

Repository & UnitOfWork pattern

EF Core ile veri erişimi

Orta seviye hata yönetimi altyapısı

