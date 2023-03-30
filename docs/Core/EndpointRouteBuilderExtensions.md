# Using EndpointRouteBuilderExtensions to Register Endpoints

The `EndpointRouteBuilderExtensions` class provides extension methods to register endpoints in ASP.NET Core.
You can use these methods to register endpoints that implement the `IEndpointMarker` interface from multiple assemblies.

## Adding Endpoints

In `Program.cs`

```csharp
    var types = new[]
    {
        typeof(IAssemblyMarkerUniqueNameForAssembly1),
        typeof(IAssemblyMarkerUniqueNameForAssembly2),
        typeof(IAssemblyMarkerUniqueNameForAssembly3),
    };
    
    app.MapEndpoints(types);
```

We recommend using a interface marker in the assemblies you like to add end point from, but any class or interface will work.

```csharp
    public interface IAssemblyMarkerUniqueNameForAssembly
    {
    }
```

## Example Usage

```csharp
    public class MyFirstEndpoint : IEndpointMarker
    {
        public void Map(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/myendpoint1", async context =>
            {
                await context.Response.WriteAsync("Hello from MyFirstEndpoint!");
            });
        }
    }
```



