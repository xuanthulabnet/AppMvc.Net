# CLI Tools
- Cài đặt lệnh ```dotnet aspnet-codegenerator```
```
dotnet tool install -g dotnet-aspnet-codegenerator
```

# Packages
```
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
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

options.ViewLocationFormats.Add("/MyView/{1}/{0}" + RazorViewEngine.ViewExtension);

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
Url.Action("PlanetInfo", "Planet", new {id = 1}, Context.Request.Scheme)

Url.RouteUrl("default", new {controller= "First", action="HelloView", id = 1, username =  "XuanThuLab"})
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