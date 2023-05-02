# IMockbleDateTime

Interface for a class that provides a mockable `DateTime.UtcNow` property. This is useful for unit testing time-sensitive logic.

## Properties
- `UtcNow` (`DateTime`): Gets the current UTC date and time.

## Example Usage

```csharp
public class MyService
{
    private readonly IMockbleDateTime _dateTime;

    public MyService(IMockbleDateTime dateTime)
    {
        _dateTime = dateTime;
    }

    public bool IsAfterMidnight()
    {
        return _dateTime.UtcNow.TimeOfDay > TimeSpan.FromHours(24);
    }
}
```

In the example above, the `MyService` class takes an instance of `IMockbleDateTime` as a dependency, which allows it to be unit tested more easily. In a production environment, a concrete implementation of `IMockbleDateTime` would be used that returns the actual current UTC date and time. In a test environment, a mock implementation of IMockbleDateTime can be used to simulate different dates and times to ensure that the IsAfterMidnight method behaves correctly.


To use the default implementation `MockbleDateTimeDefault` add the following In 
program.cs
```csharp
builder.Services.AddMockbleGuidGenerator();
```
or
```csharp
builder.Services.AddTransient<IMockbleDateTime, MockbleDateTimeDefault>();
```

### Note:
The default implementation `MockbleDateTimeDefault` and `MockbleGuidGenerator` is registered as a singleton with.
```csharp
builder.Services.AddMockble();
```
