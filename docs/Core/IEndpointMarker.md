# How to use IEndpointMarker and EndpointRouteBuilderExtensions
## Overview
IEndpointMarker is an interface used to mark classes that contain endpoint configuration logic. EndpointRouteBuilderExtensions is a static class that contains an extension method for IEndpointRouteBuilder that scans the assembly for classes implementing IEndpointMarker, and calls their Map method.

# Example Usage
1. Implement the IEndpointMarker interface in a class that will contain the endpoint configuration logic, like so:

```
public class MyEndpoint : IEndpointMarker
{
    public IEndpointRouteBuilder Map(IEndpointRouteBuilder app)
    {
        app.MapGet("/myendpoint", () => "Hello, World!")
            .WithName("MyEndpoint")
            .Produces<string>(200)
            .WithMetadata(new SwaggerOperationAttribute("MyEndpoint", "Returns a greeting message."));
        return app;
    }
}
```

2. Register your endpoint class in EndpointRouteBuilderExtensions by calling the MapEndpoints method on your IEndpointRouteBuilder. This method will scan the calling assembly for classes that implement IEndpointMarker and call their Map methods.

In program.cs
```
var app = builder.Build();
...
//Register your endpoints here
app.MapEndpoints();
--
```

With these steps, your endpoint will be registered in the application's routing table and will be accessible via its configured route.