using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;

namespace App.ExtendMethods
{
    public static class AppExtends
    {
        public static void AddStatusCodePage(this IApplicationBuilder app)
        {
            app.UseStatusCodePages(appError =>  {
                appError.Run(async context => {
                    var respone = context.Response;
                    var code = respone.StatusCode;
                    

                    var content = @$"<html>
                        <head>
                            <meta charset='UTF-8' />
                            <title>Lỗi {code}</title>
                        </head>
                        <body>
                            <p style='color:red; font-size: 30px'>
                                Có lỗi xảy ra: {code} - {(HttpStatusCode)code}
                            </p>
                        </body>
                    </html>";

                    await respone.WriteAsync(content);
                });
            }); //Code 400  - 599
        }
    }
}