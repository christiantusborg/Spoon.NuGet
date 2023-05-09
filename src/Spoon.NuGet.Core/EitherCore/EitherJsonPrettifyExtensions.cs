
namespace Spoon.NuGet.Core.EitherCore
{
    using System.Text.Json;
    using Extensions.Html;
    using Microsoft.AspNetCore.Http;

    /// <summary>
/// 
/// </summary>
    public static class EitherJsonPrettifyExtensions
    {
        /// <summary>
        /// return the result as a html page showing the json elements.
        /// </summary>
        /// <typeparam name="TSuccess"></typeparam>
        /// <param name="commandResult"></param>
        /// <returns></returns>
        public static IResult ToResultJsonPrettify<TSuccess>(this Either<TSuccess> commandResult)
        {
            return Results.Extensions.Html(commandResult.JsonPrettify());
        }
        /// <summary>
        /// return the result as a html page showing the json elements.
        /// </summary>
        /// <typeparam name="TSuccess"></typeparam>
        /// <param name="commandResult"></param>
        /// <returns></returns>
        public static string JsonPrettify<TSuccess>(this Either<TSuccess> commandResult)
        {

            var bla = JsonSerializer.Serialize(commandResult.Match(exception => throw exception, result => result));
            var html = $@"
<html><head><meta http-equiv=""Content-Type"" content=""text/html; charset=windows-1252""></head>
<body>
<script> 

function output(inp) {{
    document.body.appendChild(document.createElement('pre')).innerHTML = inp;
}}

function syntaxHighlight(json) {{
    json = json.replace(/&/g, '&amp;').replace(/</g, '&lt;').replace(/>/g, '&gt;');
    return json.replace(/(""(\\u[a-zA-Z0-9]{{4}}|\\[^u]|[^\\""])*""(\s*:)?|\b(true|false|null)\b|-?\d+(?:\.\d*)?(?:[eE][+\-]?\d+)?)/g, function (match) {{
        var cls = 'number';
        if (/^""/.test(match)) {{
            if (/:$/.test(match)) {{
                cls = 'key';
            }} else {{
                cls = 'string';
            }}
        }} else if (/true|false/.test(match)) {{
            cls = 'boolean';
        }} else if (/null/.test(match)) {{
            cls = 'null';
        }}
        return '<span class=""' + cls + '"">' + match + '</span>';
    }});
}}

var obj = {bla}
var str = JSON.stringify(obj, undefined, 4);

output(str);
//output(syntaxHighlight(str));

</script> 
</body></html>
";
            return html;
        }
    }
}
