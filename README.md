## ASP.NET Core 6 MVC 相依性注入之物件生命週期範例
An example for DI instance lifetime in ASP.NET Core 6 MVC 

## 前言
在 ASP.NET Core 6 的開發框架下, 相依性注入 (Dependency Injection) 是跟以往 ASP.NET MVC 5 有很大不同的其中一項技術.  

本篇文章, 主要是模仿參考文件 [1] 的範例, 進行演練.  

在經由演練之後, 對於 ASP.NET Core 6 MVC 內建的 DI Container 套件, 也多了一份認識.  

## 基本概念

在 ASP.NET MVC 5 時, 需要用到物件時, 除非有安裝 3rd 的 DI 套件, 一般都是自己 new, 但這樣會造成程式之間的相依性太高, 容易發生改 A 壞 B 的狀況, 且不容易進行單元測試.

在 ASP.NET Core 6 MVC 時, 就強烈建議一定要用 DI, 雖然仍然可以自已 new, 但並不建議自己這樣作. 微軟有提供了一個內建的 DI 套件 (Microsoft.Extensions.DependencyInjection), 用以管理物件的 註冊(register), 解析(resolve), 及釋放 (release) 整個過程的生命週期.  

* 註冊: 建立介面與類別的對應, 例如:
```csharp
AddSingleton<ISampleService, SampleService>();
AddScoped<ISampleService, SampleService>();
AddTransient<ISampleService, SampleService>();
```

* 解析: 在物件的建構子有引用介面時, DI Container 套件 會自動建立當初註冊時對應的類別物件實例 (instance), 例如: 
```csharp
ISampleService _service;
public SampleController(ISampeService service)
{
    _service = service
}
```

* 釋放: 依當初註冊設定的生命週期 (Singleton, Scoped, Transient), 進行物件實例的釋放.  

所謂的 Singleton, Scoped, Transicent 是什麼呢? 黑暗執行緒在 參考文件 [3] 有作了以下的說明:  

> 1. Singleton  
> 整個 Process 只建立一個 Instance，任何時候都共用它。  
> 2. Scoped  
> 在網頁 Request 處理過程(指接到瀏覽器請求到回傳結果前的執行期間)共用一個 Instance。  
> 3. Transient  
> 每次要求元件時就建立一個新的，永不共用。  

以下就開始作演練吧 !

## 演練細節

### 步驟_1: 建立 ASP.NET Core 6 MVC 專案
採用 Visual Studio 2022 建立 ASP.NET Core 6 MVC 專案.  

### 步驟_2: 加入 3 個 Interface
(1) 建立 Interfaces 資料夾
(2) 加入 3 個 Interface: ISingletonService, IScopedService, ITransientService

```csharp
namespace ASPNeetCore6LifeTime.Interfaces
{
    public interface ISingletonService
    {
        Guid GetCurrentGUID();
    }
}
```

```csharp
namespace ASPNeetCore6LifeTime.Interfaces
{
    public interface IScopedService
    {
        Guid GetCurrentGUID();
    }
}
```

```csharp
namespace ASPNeetCore6LifeTime.Interfaces
{
    public interface ITransientService
    {
        Guid GetCurrentGUID();
    }
}
```

### 步驟_3: 加入 3 個 Interface







## 參考文件
<a href="https://jayanttripathy.com/addtransient-vs-addscoped-vs-addsingleton-example-in-asp-net-core/" target="_blank">[1] (JAYANT TRIPATHY) AddTransient Vs AddScoped Vs AddSingleton Example in ASP.Net Core</a>

<a href="https://github.com/JayantTripathy/DI-Service-Lifetime" target="_blank">[2] (JAYANT TRIPATHY)(GitHub Repository) AddTransient Vs AddScoped Vs AddSingleton Example in ASP.Net Core</a>

<a href="https://blog.darkthread.net/blog/aspnet-core-di-notes/" target="_blank">[3] (黑暗執行緒) 筆記 - 不可不知的 ASP.NET Core 依賴注入</a>

<a href="https://learn.microsoft.com/zh-tw/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-6.0" target="_blank">[4] (Microsoft Learm) .NET Core 中的相依性插入</a>

