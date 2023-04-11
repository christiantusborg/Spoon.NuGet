namespace Spoon.NuGet.EitherCore.Extensions.Html;

using System.Net.Mime;
using System.Text;
using Microsoft.AspNetCore.Http;

class HtmlResult : IResult
{
    private readonly string _html;

    public HtmlResult(string html)
    {
        this._html = html;
    }

    public Task ExecuteAsync(HttpContext httpContext)
    {
        httpContext.Response.ContentType = MediaTypeNames.Text.Html;
        httpContext.Response.ContentLength = Encoding.UTF8.GetByteCount(this._html);
        return httpContext.Response.WriteAsync(this._html);
    }
}
