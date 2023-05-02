# IMockbleGuidGenerator

Interface for a class that provides a mockable `Guid.NewGuid()` method. This is useful for unit testing logic that relies on generated Guids.

## Properties

### `NewGuid() : Guid`

Creates a new `Guid`.

## Example Usage

```csharp
public class MyService
{
    private readonly IMockbleGuidGenerator _guidGenerator;

    public MyService(IMockbleGuidGenerator guidGenerator)
    {
        _guidGenerator = guidGenerator;
    }

    public void SaveItem(Item item)
    {
        item.Id = _guidGenerator.NewGuid();
        // Save the item with the new ID
    }
}
```

n the example above, the `MyService` class takes an instance of `IMockbleGuidGenerator' as a dependency, which allows it to be unit tested more easily. In a production environment, a concrete implementation of `IMockbleGuidGenerator` would be used that generates new Guids using the `Guid.NewGuid()` method. In a test environment, a mock implementation of `IMockbleGuidGenerator` can be used to generate specific Guids to ensure that the SaveItem method behaves correctly.

There is a default implementation `MockbleGuidGenerator` this will return `Guid.NewGuid()`

To use the default implementation `MockbleGuidGenerator` add the following In 
program.cs
```csharp
builder.Services.AddMockbleDateTime();
```
or
```csharp
builder.Services.AddTransient<IMockbleGuidGenerator, MockbleGuidGenerator>();
```

### Note:
The default implementation `MockbleDateTimeDefault` and `MockbleGuidGenerator` is registered as a singleton with.
```csharp
builder.Services.AddMockble();
```