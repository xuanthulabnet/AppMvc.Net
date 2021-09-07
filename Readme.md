# CLI Tools
- Cài đặt lệnh ```dotnet aspnet-codegenerator```
```
dotnet tool install -g dotnet-aspnet-codegenerator

dotnet tool install --global dotnet-ef
dotnet tool update dotnet-ef
```

# Packages
```
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design

dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.Extensions.DependencyInjection
dotnet add package Microsoft.Extensions.Logging
dotnet add package Microsoft.Extensions.Logging.Console
dotnet add package Microsoft.EntityFrameworkCore.Tools.DotNet
```
## Enable local HTTPS
```
dotnet dev-certs https --clean
dotnet dev-certs https --trust
```

## Controller
- Là một lớp kế từ thừa lớp Controller  : Microsoft.AspNetCore.Mvc.Controller
- Action trong controller là một phương public (không được static)
- Action trả về bất kỳ kiểu dữ liệu nào, thường là IActionResult
- Các dịch vụ inject vào controller qua hàm tạo
- Tạo controller bằng CLI
```
dotnet aspnet-codegenerator controller -name Product -namespace App.Controllers -outDir Controllers
```
## View
- Là file .cshtml
- View cho Action lưu tại: /View/ControllerName/ActionName.cshtml
- Thêm thư mục lưu trữ View:
```
// {0} -> ten Action
// {1} -> ten Controller
// {2} -> ten Area

options.ViewLocationFormats.Add("/MyView/{1}/{0}" 
                                + RazorViewEngine.ViewExtension);

options.AreaViewLocationFormats.Add("/MyArea/{1}/View/{1}/{0}.cshtml");
```
## Truyền dữ liệu sang View
- Model
- ViewData
- ViewBag
- TempData

## Areas
- Là tên dùng để routing
- Là cấu trúc thư mục chứa M.V.C
- Thiết lập Area cho controller bằng ```[Area("AreaName")]```
- Tạo cấu trúc thư mục
```
dotnet aspnet-codegenerator area Product 
```

## Route
- endpoints.MapControllerRoute
- endpoints.MapAreaControllerRoute
- [AcceptVerbs("POST", "GET")]
- [Route("pattern")]
- [HttpGet] [HttpPost] 
## Url Generation
### UrlHelper : Action, ActionLink, RouteUrl, Link
```
Url.Action("PlanetInfo", "Planet", 
            new {id = 1}, Context.Request.Scheme);

Url.RouteUrl("default", new {controller= "First", 
                             action="HelloView", 
                            id = 1, 
                            username =  "XuanThuLab"});
```
### HtmlTagHelper: ```<a> <button> <form>```
Sử dụng thuộc tính:
```
asp-area="Area"
asp-action="Action"
asp-controller="Product"
asp-route...="123"
asp-route="default"
```

## Entity Framework, SQL Server
- Chạy SQL Server trên Docker: thư mục ```sql-server-docker```
- Chuỗi kết nối đến SQL Server trong ```appsettings.json```
```json
"ConnectionStrings": {
  "AppMvcConnectionString": "Data Source=localhost,1433; Initial Catalog=appmvc; User ID=SA;Password=Password123"
}
```
- Logger (```appsettings.json```)
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information",
      "Microsoft.EntityFrameworkCore.Query": "Information",
      "Microsoft.EntityFrameworkCore.Database.Command": "Information"
    }
  },
```
### Migrations
```
# Liệt kê
dotnet ef migrations list

# Tạo migration init
dotnet ef migrations add init

# Cập nhật migration cuối lên SQL Server
dotnet ef database update
```