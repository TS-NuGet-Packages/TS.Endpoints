# TS.Endpoints

**TS.Endpoints** is a lightweight and modular endpoint registration library for ASP.NET Minimal APIs, inspired by Carter.  
It lets you organize your API endpoints into clean, maintainable classes without using controllers.

---

## 🚀 Features

- ✅ Minimal API support
- ✅ Modular design with `IEndpoint` interface
- ✅ Automatic discovery via reflection
- ✅ Fluent route mapping with `MapEndpoints()`
- ✅ Support for single or multiple assemblies
- ✅ Compatible with `WithTags`, `WithName`, and Swagger (optional extensions)

---

## 📦 Installation

```bash
dotnet add package TS.Endpoints
```

---

## ⚙️ Usage

### 1. Create an endpoint module:

```csharp
using Microsoft.AspNetCore.Routing;
using TS.Endpoints;

public class ProductEndpoints : IEndpoint
{
    public void AddRoutes(IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("/products").WithTags("Products");

        group.MapGet("/", () => Results.Ok("Get all products"))
              .WithSummary("GetAllProducts"); // => Optional

        group.MapPost("/", () => Results.Ok("Create product"))
              .WithSummary("CreateProduct"); // => Optional
    }
}
```

---

### 2. Register and map endpoints in `Program.cs`:

```csharp
builder.Services.AddEndpoint(); // Scans current assembly

// or specify multiple assemblies
builder.Services.AddEndpoint(
    typeof(ProductEndpoints).Assembly,
    typeof(OtherEndpoints).Assembly
);

var app = builder.Build();
app.MapEndpoints();
```

---

## 🤝 Contributing

Contributions are welcome via pull requests and issues.  
If you find this useful, star the repo and share it ⭐

---

## 📄 License

MIT License
