using Microsoft.AspNetCore.Mvc;

namespace AssafFinkelshtein;

[ApiController]
public class RootController : ControllerBase
{
    [HttpGet("")]
    public ContentResult GetRoot()
    {
        string html = @"
            <html>
                <head>
                    <title>Kittens</title>
                </head>
                <body>
                    <h1 style='text-align: center; margin: 50px'>Kittens REST API on Docker</h1>
                </body>
            </html>
            ";
        return Content(html, "text/html");
    }
}
